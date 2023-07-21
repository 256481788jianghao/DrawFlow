using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public class DF_Circle:DF_Shape
    {
        public DF_Circle() 
        {
            ShapeTpye = DF_ShapeType.Circle;
        }

        public override void PaintCallBack(object obj, PaintEventArgs pe)
        {
            base.PaintCallBack(obj, pe);
            Panel p = (Panel)obj;
            Brush br = new SolidBrush(Color.Blue);
            pe.Graphics.FillEllipse(br, new Rectangle(5, 5, p.Width - 5, p.Height - 5));

            //if (ShapeState == DF_ShapeState.Moving)
            //{
            //    Pen tp = new Pen(Color.Red);
            //    pe.Graphics.DrawRectangle(tp, new Rectangle(0, 0, p.Width, p.Height));
            //}
        }
    }
}
