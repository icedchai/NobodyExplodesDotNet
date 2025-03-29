
namespace WindowsFormsApp
{
    using NobodyExplodesDotNet.Enums;
    using NobodyExplodesDotNet.Types.Modules;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Media;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    public partial class WiresModuleForm : Form
    {
        private WiresModule WiresModule;

        private static Dictionary<ModuleColor, Image> wireColorToImageCut = new Dictionary<ModuleColor, Image>
        {
            { ModuleColor.Black, Properties.Resources.black_cut },
            { ModuleColor.White, Properties.Resources.white_cut },
            { ModuleColor.Red, Properties.Resources.red_cut },
            { ModuleColor.Yellow, Properties.Resources.yellow_cut },
            { ModuleColor.Blue, Properties.Resources.blue_cut },
        };

        private static Dictionary<ModuleColor, Image> wireColorToImageUncut = new Dictionary<ModuleColor, Image>
        {
            { ModuleColor.Black, Properties.Resources.black_uncut },
            { ModuleColor.White, Properties.Resources.white_uncut },
            { ModuleColor.Red, Properties.Resources.red_uncut },
            { ModuleColor.Yellow, Properties.Resources.yellow_uncut },
            { ModuleColor.Blue, Properties.Resources.blue_uncut },
        };
        private static Dictionary<ModuleColor, string> wireColorToFileCut = new Dictionary<ModuleColor, string>
        {
            { ModuleColor.Black, Application.StartupPath + "\\media\\black_cut.png" },
            { ModuleColor.White, Application.StartupPath + "\"\\\\media\\white_cut.png" },
            { ModuleColor.Red, Application.StartupPath + "\\media\\red_cut.png" },
            { ModuleColor.Yellow, Application.StartupPath + "\\media\\yellow_cut.png" },
            { ModuleColor.Blue, Application.StartupPath + "\\media\\blue_cut.png" },
        };

        private static Dictionary<ModuleColor, string> wireColorToFileUncut = new Dictionary<ModuleColor, string>
        {
            { ModuleColor.Black, Application.StartupPath + "\\media\\black_uncut.png" },
            { ModuleColor.White, Application.StartupPath + "\"\\\\media\\white_uncut.png" },
            { ModuleColor.Red, Application.StartupPath + "\\media\\red_uncut.png" },
            { ModuleColor.Yellow, Application.StartupPath + "\\media\\yellow_uncut.png" },
            { ModuleColor.Blue, Application.StartupPath + "\\media\\blue_uncut.png" },
        };

        private List<PictureBox> wires = new List<PictureBox>();

        public WiresModuleForm(WiresModule wiresModule)
        {
            this.InitializeComponent();
            wires.Add(wire0);
            wires.Add(wire1);
            wires.Add(wire2);
            wires.Add(wire3);
            wires.Add(wire4);
            wires.Add(wire5);
            WiresModule = wiresModule;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            for (int i = 0; i < 6; i++)
            {
                if (WiresModule.Wires.Count > i)
                {
                    Wire wire = WiresModule.Wires[i];
                    if (wire.IsCut)
                    {
                        if (!File.Exists(wireColorToFileCut[wire.Color]))
                        {
                            wires[i].Image = wireColorToImageCut[wire.Color];
                        }
                        else
                        {
                            wires[i].Image = Image.FromFile(wireColorToFileCut[wire.Color]);
                        }
                    }
                    else
                    {
                        if (!File.Exists(wireColorToFileUncut[wire.Color]))
                        {
                            wires[i].Image = wireColorToImageUncut[wire.Color];
                        }
                        else
                        {
                            wires[i].Image = Image.FromFile(wireColorToFileUncut[wire.Color]);
                        }
                    }
                }
                else
                {
                    wires[i].Image = null;
                }
            }

            solveIndicator.Text = WiresModule.IsSolved ? "Solved Module" : "Unsolved Module";
        }

        private void wire0_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(0);
            UpdateDisplay();
        }

        private void wire1_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(1);
            UpdateDisplay();
        }

        private void wire2_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(2);
            UpdateDisplay();
        }

        private void wire3_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(3);
            UpdateDisplay();
        }

        private void wire4_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(4);
            UpdateDisplay();
        }

        private void wire5_Click(object sender, EventArgs e)
        {
            WiresModule.CutWire(5);
            UpdateDisplay();
        }
    }
}
 