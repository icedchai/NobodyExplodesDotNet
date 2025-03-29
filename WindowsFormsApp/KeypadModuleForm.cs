
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
    using NobodyExplodesDotNet.Types.Modules;

    public partial class KeypadModuleForm : Form
    {
        private KeypadModule keypadModule;

        public KeypadModuleForm(KeypadModule keypadModule)
        {
            InitializeComponent();
            this.keypadModule = keypadModule;

            button1.Text = $"{keypadModule.Buttons[0]}";
            button2.Text = $"{keypadModule.Buttons[1]}";
            button3.Text = $"{keypadModule.Buttons[2]}";
            button4.Text = $"{keypadModule.Buttons[3]}";
        }

        private void UpdateDisplay()
        {
            button1.BackColor = keypadModule.ButtonIsPressed(0) ? Color.DarkGray : Color.White;
            button2.BackColor = keypadModule.ButtonIsPressed(1) ? Color.DarkGray : Color.White;
            button3.BackColor = keypadModule.ButtonIsPressed(2) ? Color.DarkGray : Color.White;
            button4.BackColor = keypadModule.ButtonIsPressed(3) ? Color.DarkGray : Color.White;
            solveIndicator.Text = keypadModule.IsSolved ? "Solved Module" : "Unsolved Module";
        }

        private void CommonPressFunc()
        {
            BombForm.Play("press_in.wav");
            UpdateDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            keypadModule.PressButton(0);
            CommonPressFunc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            keypadModule.PressButton(1);
            CommonPressFunc();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            keypadModule.PressButton(2);
            CommonPressFunc();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            keypadModule.PressButton(3);
            CommonPressFunc();
        }
    }
}
 