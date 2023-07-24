using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow
{
    public partial class InputForm : Form
    {
        public delegate void InputHandler(string txt);
        public event InputHandler InputEvent;

        public InputForm()
        {
            InitializeComponent();
        }

        public void Init(string txt)
        {
            textBox1.Text = txt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputEvent?.Invoke(textBox1.Text);
            Close();
        }
    }
}
