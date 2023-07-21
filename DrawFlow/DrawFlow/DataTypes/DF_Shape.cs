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
        EnterResizeArea = 2
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
        }

        public virtual void PaintCallBack(Object obj, PaintEventArgs pe) 
        {
            Panel p = (Panel)obj;
            Brush br = new SolidBrush(Color.Transparent);
            pe.Graphics.FillRectangle(br, new Rectangle(0, 0, p.Width, p.Height));

            Brush resizeBr = new SolidBrush(Color.Red);
            if(ShapeState == DF_ShapeState.EnterResizeArea)
            {
                DrawResizePoints(resizeBr, pe.Graphics);
            }
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
                if (IsMouseInMoveTrigRect(pe.Location))
                {
                    ShapeState = DF_ShapeState.Moving;
                }
            }

        }

        public virtual void MouseUpCallBack(Object obj, MouseEventArgs pe)
        {
            Console.WriteLine("shape Up... " + (pe.Button == MouseButtons.Left));
            if (pe.Button == MouseButtons.Left)
            {
                ShapeState = DF_ShapeState.Stop;
            }

        }


        public virtual void MouseMoveCallBack(Object obj, MouseEventArgs pe)
        {
            Console.WriteLine("shape Move... " + pe.X+" "+pe.Y+" "+pe.Button);
            Panel p = (Panel)obj;
            if (IsMouseInMoveTrigRect(pe.Location))
            {
                p.Cursor = Cursors.SizeAll;
            }
            else if (IsInResizeArea(p, pe.Location))
            {
                ShapeState = DF_ShapeState.EnterResizeArea;
                InitResizeRects(p);

                p.Invalidate();

                switch (GetResizeDirection(pe.Location))
                {
                    case DF_ResizeDir.UpLeft:
                    case DF_ResizeDir.DownRight:
                        p.Cursor = Cursors.SizeNWSE; break;
                    case DF_ResizeDir.UpRight:
                    case DF_ResizeDir.DownLeft:
                        p.Cursor = Cursors.SizeNESW; break;
                    case DF_ResizeDir.Up:
                    case DF_ResizeDir.Down:
                        p.Cursor = Cursors.SizeNS; break;
                    case DF_ResizeDir.Left:
                    case DF_ResizeDir.Right:
                        p.Cursor = Cursors.SizeWE; break;
                    default:
                        break;
                }
            }
            else
            {
                if(ShapeState == DF_ShapeState.EnterResizeArea)
                {
                    p.Invalidate(true);
                }
                ShapeState = DF_ShapeState.Stop;
                p.Cursor = Cursors.Default;
            }

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

        }

        public virtual void MouseEnterCallBack(Object obj, EventArgs pe)
        {
            //Panel p = (Panel)obj;
            //p.Cursor = Cursors.SizeAll;
        }


        Rectangle moveTrigRect = new Rectangle(10, 0, 10, 10);
        private bool IsMouseInMoveTrigRect(Point location)
        {
            return moveTrigRect.Contains(location);
        }

        List<Rectangle> resizeTrigRects = new List<Rectangle>();
        private bool IsInResizeArea(Panel p, Point Location)
        {
            Rectangle r1 = new Rectangle(0, 0, p.Width, p.Height);
            Rectangle r2 = new Rectangle(5, 5, p.Width - 5, p.Height - 5);
            return r1.Contains(Location) && !r2.Contains(Location) && !moveTrigRect.Contains(Location);
        }


        private void InitResizeRects(Panel p)
        {
            resizeTrigRects.Clear();
            int w0 = p.Width;
            int h0 = p.Height;

            resizeTrigRects.Add(new Rectangle(0, 0, 5, 5));
            resizeTrigRects.Add(new Rectangle(w0 / 2, 0, 5, 5));
            resizeTrigRects.Add(new Rectangle(w0 - 5, 0, 5, 5));
            resizeTrigRects.Add(new Rectangle(0, h0 / 2, 5, 5));
            resizeTrigRects.Add(new Rectangle(w0 - 5, h0 / 2, 5, 5));
            resizeTrigRects.Add(new Rectangle(0, h0 - 5, 5, 5));
            resizeTrigRects.Add(new Rectangle(w0 / 2, h0 - 5, 5, 5));
            resizeTrigRects.Add(new Rectangle(w0 - 5, h0 - 5, 5, 5));
        }

        private DF_ResizeDir GetResizeDirection(Point Location)
        {
            for(int i = 0;i<resizeTrigRects.Count;i++)
            {
                if (resizeTrigRects[i].Contains(Location))
                {
                    return (DF_ResizeDir)i;
                }
            }
            return DF_ResizeDir.None;
        }

        private void DrawResizePoints(Brush br, Graphics g)
        {
            if(resizeTrigRects.Count > 0)
            {
                g.FillRectangles(br, resizeTrigRects.ToArray());
            }
        }
    }
}
