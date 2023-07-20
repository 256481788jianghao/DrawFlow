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
            FileTypeForm ftypeForm = new FileTypeForm();
            ftypeForm.ShowDialog();

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "DFFILE|*.dff";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                DF_File file = new DF_File();
                file.fType = ftypeForm.ftype;
                file.FilePath = dlg.FileName;
                file.Name = Path.GetFileNameWithoutExtension(dlg.FileName);
                file.RelativePage = new TabPage(file.Name);
                file.RelativePage.BackColor = Color.White;
                //file.RelativePage.Paint += new PaintEventHandler(PaintEventCallBack_Test);
                //file.RelativePage.MouseMove += new MouseEventHandler(MouseMoveEventCallBack_Test);
                file.RelativePage.MouseClick += new MouseEventHandler(MouseClickEventCallBack_Test);
                tabControl_Context.TabPages.Add(file.RelativePage);
                GVL.df_file_list.Add(file);

                if(tabControl_Context.TabPages.Count == 1)
                {
                    GVL.CurFile = file;
                }

                InitTreeViewLeftMenu();
            }
        }

        void InitTreeViewLeftMenu()
        {
            if(treeView_leftmenu.Nodes.Count != 0)
            {
                treeView_leftmenu.Nodes.Clear();
            }
            TreeNode root = new TreeNode("基本图形");
            root.Nodes.Add(new TreeNode("开始/结束"));
            root.Nodes.Add(new TreeNode("基本处理"));
            root.Nodes.Add(new TreeNode("条件判断"));
            root.Nodes.Add(new TreeNode("连线"));
            root.Nodes.Add(new TreeNode("跳转到"));
            treeView_leftmenu.Nodes.Add(root);
            treeView_leftmenu.ExpandAll();
        }

        private void MouseClickEventCallBack_Test(object obj, MouseEventArgs pe)
        {
            Console.WriteLine("page click....");
        }

        private void MouseMoveEventCallBack_Test(object obj, MouseEventArgs pe)
        {
            TabPage page = (TabPage)obj;
            page.Invalidate();
        }

        private void PaintEventCallBack_Test(object obj,PaintEventArgs pe)
        {
            Pen p = new Pen(Color.Red, 2);
            pe.Graphics.DrawEllipse(p, new RectangleF(0, 0, 100, 100));
            Buttom_Tip.Text = "Paint:" + DateTime.Now.ToString();
        }

        private void treeView_leftmenu_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            switch (e.Node.Text) 
            {
                case "基本处理":
                    {
                        GVL.CurFile.AddRect();
                        break;
                    }
                case "跳转到":
                    {
                        GVL.CurFile.AddCircle();
                        break;
                    }
                default:
                    return;
            }

        }

        private void tabControl_Context_Selected(object sender, TabControlEventArgs e)
        {
            GVL.CurFile = GVL.df_file_list.Find((x) => x.RelativePage == e.TabPage);
        }
    }
}
