
namespace WindowsFormsApp
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Text;
    using System.IO;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Windows.Media;
    using NobodyExplodesDotNet.Types;
    using NobodyExplodesDotNet.Types.Modules;
    using Module = NobodyExplodesDotNet.Types.Module;

    public partial class BombForm : Form
    {
        internal static Bomb bomb;

        private static Timer beeper;

        public static int volume = 100;

        // updater updates things on a small scale
        private static Timer updater;

        // because windows timers arent very high res, there is a dedicated timer that ticks down the timer at a higher interval.
        private static Timer timer;
        private int detectedStrikes = 0;
        private List<Button> moduleButtons = new List<Button>() { null };

        #region Load font
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private Font digitalSeven;
        private PrivateFontCollection fonts = new PrivateFontCollection();

        private void InitDigitalFont()
        {
            byte[] fontData;
            if (File.Exists(Application.StartupPath + "\\media\\digitalseven.ttf"))
            {
                fontData = File.ReadAllBytes(Application.StartupPath + "\\media\\digitalseven.ttf");
            }
            else
            {
                fontData = Properties.Resources.digitalseven;
            }

            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, fontData.Length);
            AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            digitalSeven = new Font(fonts.Families[0], 42.0F);
        }

        #endregion

        public static void Play(string audioPath)
        {
            if (File.Exists(Application.StartupPath + "\\media\\" + audioPath))
            {
                MediaPlayer myPlayer = new MediaPlayer();
                myPlayer.Open(new System.Uri(Application.StartupPath + "\\media\\" + audioPath));
                myPlayer.Pause();
                myPlayer.Volume = 0.3f;
                myPlayer.Play();
            }
        }

        public BombForm()
        {
            InitializeComponent();

            InitDigitalFont();

            timerLabel.Font = digitalSeven;
            strikeOne.Font = digitalSeven;
            strikeTwo.Font = digitalSeven;

            bomb = new Bomb();
            serialDisplay.Text = $"{bomb.Serial}";

            moduleButtons.Add(module1);
            moduleButtons.Add(module2);
            moduleButtons.Add(module3);
            moduleButtons.Add(module4);

            for (int i = 1; i < bomb.Modules.Count; i++)
            {
                Module module = bomb.Modules[i];
                moduleButtons[i].Text = module.GetType().Name;
            }

            Update(null, null);
            updater = new Timer();
            updater.Interval = 10;
            updater.Tick += Update;
            updater.Start();

            initBeepers();

        }

        private async Task initBeepers()
        {
            beeper = new Timer();
            beeper.Interval = 1000;
            beeper.Tick += Beep;

            timer = new Timer();

            await Task.Delay(4750);
            beeper.Start();
        }

        private void Update(object sender, EventArgs args)
        {
            timerLabel.Text = NobodyExplodesDotNet.CommonFuncs.GetTimerDisplay(bomb);
            if (detectedStrikes < bomb.Strikes)
            {
                detectedStrikes++;
                Play("\\strike.wav");
                beeper.Interval -= 250;
            }

            strikeOne.Text = bomb.Strikes > 0 ? "X" : string.Empty;
            strikeTwo.Text = bomb.Strikes > 1 ? "X" : string.Empty;
            if (bomb.ShouldExplode)
            {
                Application.Exit();
            }
        }

        private async void Beep(object sender, EventArgs args)
        {
            Play("secondarybeep.wav");
            await Task.Delay(beeper.Interval / 4);
            Play("clockbeep.wav");
            bomb.Time -= 1;
        }

        private void OpenModule(int moduleIndex)
        {
            if (bomb.Modules[moduleIndex] is null)
            {
                return;
            }

            Module module = bomb.Modules[moduleIndex];
            switch (module)
            {
                case WiresModule wiresModule:
                    WiresModuleForm wiresModuleForm = new WiresModuleForm(wiresModule);
                    wiresModuleForm.Show();
                    break;
                case ButtonModule buttonModule:
                    ButtonModuleForm buttonModuleForm = new ButtonModuleForm(buttonModule);
                    buttonModuleForm.Show();
                    break;
                case KeypadModule keypadModule:
                    KeypadModuleForm keypadModuleForm = new KeypadModuleForm(keypadModule);
                    keypadModuleForm.Show();
                    break;
            }
        }

        private void module1_Click(object sender, EventArgs e)
        {
            OpenModule(1);
        }

        private void module2_Click(object sender, EventArgs e)
        {
            OpenModule(2);
        }

        private void module3_Click(object sender, EventArgs e)
        {
            OpenModule(3);
        }

        private void module4_Click(object sender, EventArgs e)
        {
            OpenModule(4);
        }
    }
}
 