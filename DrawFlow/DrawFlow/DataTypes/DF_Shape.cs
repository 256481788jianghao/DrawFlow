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

    public enum DF_ShapeState
    {
        Stop = 0,
        Moving = 1,
        EnterResizeArea = 2,
        ResizeUp,
        ResizeDown,
        ResizeLeft,
        ResizeRight,
        ResizeUpLeft,
        ResizeUpRight,
        ResizeDownLeft,
        ResizeDownRight

    }

    public enum DF_ResizeDir
    {
        UpLeft = 0,
        Up,
        UpRight,
        Left,
        Right,
        DownLeft,
        Down,
        DownRight,
        None
    }

    public class DF_Shape
    {
        public Guid GID {  get; set; }

        public DF_ShapeType ShapeTpye { get; set; } = DF_ShapeType.None;
        public DF_ShapeState ShapeState { get; set;} = DF_ShapeState.Stop;
        public DF_ShapeState LastShapeState { get; set; } = DF_ShapeState.Stop;

        public Panel PanelObj { get; set; }

        public DF_Shape()
        {
            GID = Guid.NewGuid();
            
            PanelObj = new Panel();
            PanelObj.BackColor = Color.Transparent;
            PanelObj.Width = PanelObj.Height = 100;
            PanelObj.Paint += new PaintEventHandler(PaintCallBack);
            PanelObj.MouseClick += new MouseEventHandler(MouseClickCallBack);
            PanelObj.MouseDown += new MouseEventHandler(MouseDownCallBack);
            PanelObj.MouseMove += new MouseEventHandler(MouseMoveCallBack);
            PanelObj.MouseUp += new MouseEventHandler(MouseUpCallBack);
            PanelObj.MouseEnter += new EventHandler(MouseEnterCallBack);
            PanelObj.MouseLeave += new EventHandler(MouseLeaveCallBack);
        }

        public virtual void PaintCallBack(Object obj, PaintEventArgs pe) 
        {
            Panel p = (Panel)obj;
            Brush br = new SolidBrush(Color.Transparent);
            pe.Graphics.FillRectangle(br, new Rectangle(0, 0, p.Width, p.Height));
        }
        public virtual void MouseClickCallBack(Object obj, MouseEventArgs pe) 
        {
            Console.WriteLine("shape click...");
            
        }
        public virtual void MouseDownCallBack(Object obj, MouseEventArgs pe)
        {
            Console.WriteLine("shape Down... "+(pe.Button == MouseButtons.Left));
            Panel p = (Panel)obj;
            if (pe.Button == MouseButtons.Left)
            {
                //状态机
                if(ShapeState == DF_ShapeState.Stop)
                {
                    if (IsMouseInMoveTrigRect(pe.Location))
                    {
                        SetShapeState(DF_ShapeState.Moving);
                    }
                }
                
            }

        }

        public virtual void MouseUpCallBack(Object obj, MouseEventArgs pe)
        {
            Console.WriteLine("shape Up... " + (pe.Button == MouseButtons.Left));
            if (pe.Button == MouseButtons.Left)
            {
                //状态机
                if(ShapeState == DF_ShapeState.Moving)
                {
                    SetShapeState(DF_ShapeState.Stop);
                }
                
            }

        }


        public virtual void MouseMoveCallBack(Object obj, MouseEventArgs pe)
        {
            Console.WriteLine("shape Move... " + pe.X+" "+pe.Y+" "+pe.Button+" "+ShapeState);
            Panel p = (Panel)obj;
            
            //状态变换
            if(ShapeState == DF_ShapeState.Moving)
            {
                p.Top += (pe.Y - (moveTrigRect.Y + moveTrigRect.Height / 2));
                p.Left += (pe.X - (moveTrigRect.X + moveTrigRect.Width / 2));

                if(p.Top < 0)
                {
                    p.Top = 0;
                }
                if(p.Left < 0)
                {
                    p.Left = 0;
                }
            }
            else if(ShapeState == DF_ShapeState.Stop)
            {
                if (IsMouseInMoveTrigRect(pe.Location))
                {
                    p.Cursor = Cursors.SizeAll;
                }
                else
                {
                    p.Cursor = Cursors.Default;
                }
            }
            

        }

        public virtual void MouseEnterCallBack(Object obj, EventArgs pe)
        {
            //Panel p = (Panel)obj;
            //p.Cursor = Cursors.SizeAll;
        }

        public virtual void MouseLeaveCallBack(Object obj, EventArgs pe)
        {
            Panel p = (Panel)obj;
            SetShapeState(DF_ShapeState.Stop);
            p.Invalidate(true);
        }


        Rectangle moveTrigRect = new Rectangle(10, 0, 20, 20);
        public bool IsMouseInMoveTrigRect(Point location)
        {
            return moveTrigRect.Contains(location);
        }

        public void SetShapeState(DF_ShapeState state)
        {
            LastShapeState = ShapeState;
            ShapeState = state;
        }
    }
}
