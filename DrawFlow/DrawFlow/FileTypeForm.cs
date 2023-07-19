using DrawFlow.DataTypes;
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
    public partial class FileTypeForm : Form
    {
        public DF_FileType ftype { get;set; }

        public FileTypeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                ftype = DF_FileType.MindFile;
            }
            else
            {
                ftype = DF_FileType.BaseFlowFile;
            }
            this.Close();
        }
    }
}
