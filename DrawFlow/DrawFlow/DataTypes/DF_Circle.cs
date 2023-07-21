using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public class DF_Circle: DF_ResizeShape
    {
        public DF_Circle() 
        {
            ShapeTpye = DF_ShapeType.Circle;
            PanelObj.Width = PanelObj.Height = 30 + 2 * GVL.shape_pad;
        }

        public override void PaintCallBack(object obj, PaintEventArgs pe)
        {
            base.PaintCallBack(obj, pe);
            Panel p = (Panel)obj;
            Brush br = new SolidBrush(Color.Blue);
            pe.Graphics.FillEllipse(br, new Rectangle(GVL.shape_pad, GVL.shape_pad, p.Width - GVL.shape_pad * 2, p.Height - GVL.shape_pad * 2));

            //if (ShapeState == DF_ShapeState.Moving)
            //{
            //    Pen tp = new Pen(Color.Red);
            //    pe.Graphics.DrawRectangle(tp, new Rectangle(0, 0, p.Width, p.Height));
            //}
        }
    }
}
