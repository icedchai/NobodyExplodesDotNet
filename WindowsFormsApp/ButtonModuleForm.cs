namespace WindowsFormsApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using NobodyExplodesDotNet.Enums;
    using NobodyExplodesDotNet.Types.Modules;

    public partial class ButtonModuleForm : Form
    {
        private ButtonModule ButtonModule;

        private Dictionary<ModuleColor, Color> moduleToButtonColor = new Dictionary<ModuleColor, Color>
        {
            { ModuleColor.Blue, Color.Blue },
            { ModuleColor.Red, Color.Red },
            { ModuleColor.White, Color.White },
            { ModuleColor.Yellow, Color.Yellow },
            { ModuleColor.Black, Color.Black },
        };

        public ButtonModuleForm(ButtonModule buttonModule)
        {
            InitializeComponent();
            ButtonModule = buttonModule;
            button.BackColor = moduleToButtonColor[ButtonModule.Color];
            if (button.BackColor == Color.Black)
            {
                button.ForeColor = Color.White;
            }

            button.Text = ButtonModule.Label.ToString();
            sidePanel.BackColor = Color.Black;

            Timer timer = new Timer();
            timer.Tick += UpdateDisplay;
            timer.Interval = 10;
            timer.Start();
        }

        private void UpdateDisplay(object sender, EventArgs e)
        {
            if (ButtonModule.ShouldLightStrip)
            {
                sidePanel.BackColor = moduleToButtonColor[ButtonModule.Color];
            }
            else
            {
                sidePanel.BackColor = Color.Black;
            }

            solveIndicator.Text = ButtonModule.IsSolved ? "Solved Module" : "Unsolved Module";
        }

        private void button_Click(object sender, EventArgs e)
        {
            ButtonModule.PressDown();
            BombForm.Play("press_in.wav");
            Console.WriteLine("Clicked");
        }

        private void button_Up(object sender, EventArgs e)
        {
            if (ButtonModule.IsPressed)
            {
                BombForm.Play("press_release.wav");
            }

            ButtonModule.Release();
            Console.WriteLine("Up");
        }
    }
}