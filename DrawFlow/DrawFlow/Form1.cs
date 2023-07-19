using DrawFlow.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "DFFILE|*.dff";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                DF_File file = new DF_File();
                file.FilePath = dlg.FileName;
                file.Name = Path.GetFileNameWithoutExtension(dlg.FileName);
                file.RelativePage = new TabPage(file.Name);
                file.RelativePage.BackColor = Color.White;
                file.RelativePage.Paint += new PaintEventHandler(PaintEventCallBack_Test);
                tabControl_Context.TabPages.Add(file.RelativePage);
                GVL.df_file_list.Add(file);
            }
        }

        private void PaintEventCallBack_Test(object obj,PaintEventArgs pe)
        {
            Pen p = new Pen(Color.Red, 2);
            pe.Graphics.DrawEllipse(p, new RectangleF(0, 0, 100, 100));
        }
    }
}
