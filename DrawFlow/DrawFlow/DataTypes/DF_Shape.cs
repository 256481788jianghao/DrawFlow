using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public enum DF_ShapeType
    {
        None = 0,
        Rect,
        Circle,
        Start_End,
        Line
    }
    public class DF_Shape
    {
        public Guid GID {  get; set; }

        public DF_ShapeType ShapeTpye { get; set; } = DF_ShapeType.None;

        public Panel PanelObj { get; set; }

        public DF_Shape()
        {
            GID = Guid.NewGuid();
            
            PanelObj = new Panel();
            PanelObj.BackColor = Color.Transparent;
            PanelObj.Width = PanelObj.Height = 100;
            PanelObj.Paint += new PaintEventHandler(PaintCallBack);
            PanelObj.MouseClick += new MouseEventHandler(MouseClickCallBack);
        }

        public virtual void PaintCallBack(Object obj, PaintEventArgs pe) { }
        public virtual void MouseClickCallBack(Object obj, MouseEventArgs pe) 
        {
            Console.WriteLine("shape click...");
            
        }
    }
}
