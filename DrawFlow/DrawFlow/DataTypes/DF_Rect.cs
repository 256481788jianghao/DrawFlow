using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public class DF_Rect: DF_ResizeShape
    {
        public DF_Rect() 
        { 
            ShapeTpye = DF_ShapeType.Rect;
            PanelObj.Height = 80;
        }

        public override void PaintCallBack(object obj, PaintEventArgs pe)
        {
            base.PaintCallBack(obj, pe);
            Panel p = (Panel)obj;
            Brush br = new SolidBrush(Color.Blue);
            pe.Graphics.FillRectangle(br, new Rectangle(GVL.shape_pad, GVL.shape_pad, p.Width - GVL.shape_pad * 2, p.Height - GVL.shape_pad * 2));

            //if(ShapeState == DF_ShapeState.Moving)
            //{
            //    Pen tp = new Pen(Color.Red);
            //    pe.Graphics.DrawRectangle(tp, new Rectangle(0, 0, p.Width, p.Height));
            //}
        }
    }
}
