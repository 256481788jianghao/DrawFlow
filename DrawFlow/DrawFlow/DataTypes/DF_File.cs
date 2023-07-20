using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public enum DF_FileType
    {
        MindFile,
        BaseFlowFile
    }
    public class DF_File
    {
        public DF_FileType fType { get; set; }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public TabPage RelativePage { get; set; }
        public List<DF_Shape> Shapes { get; set; } = new List<DF_Shape>();

        public void AddRect()
        {
            DF_Rect rect = new DF_Rect();
            Shapes.Add(rect);
            RelativePage.Controls.Add(rect.PanelObj);
        }
        
        public void AddCircle()
        {
            DF_Circle circle = new DF_Circle();
            Shapes.Add(circle);
            RelativePage.Controls.Add(circle.PanelObj);
        }
    }
}
