using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
    public class DF_Text : DF_Shape
    {
        public TextBox tBox;

        public Font font;
        public Brush brush;

        public String TextStr = "注释";

        //private bool IsInit = false;

        public DF_Text()
        {
            ShapeTpye = DF_ShapeType.Text;
            font = PanelObj.Font;
            brush = new SolidBrush(PanelObj.ForeColor);
            PanelObj.MouseDoubleClick += new MouseEventHandler(MouseDoubleClickCallBack);
            //IsInit = true;
        }

        public override void PaintCallBack(object obj, PaintEventArgs pe)
        {
            base.PaintCallBack(obj, pe);
            DrawText(obj, pe);
        }

        public void DrawText(object obj, PaintEventArgs pe)
        {
            Panel p = (Panel)obj;
            pe.Graphics.DrawString(TextStr, font, brush, new Rectangle(GVL.text_pad, GVL.text_pad, p.Width - 2 * GVL.text_pad, p.Height - 2 * GVL.text_pad));
        }

        public virtual void MouseDoubleClickCallBack(object obj, MouseEventArgs e)
        {
            InputForm form = new InputForm();
            form.Init(TextStr);
            form.InputEvent += new InputForm.InputHandler(InputCallBack);
            //ShapeState = DF_ShapeState.InputText;
            form.ShowDialog();
        }

        private void InputCallBack(string txt)
        {
            TextStr = txt;
            PanelObj.Invalidate();
        }
    }
}
