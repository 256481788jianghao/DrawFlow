using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawFlow.DataTypes
{
     public  class DF_ResizeShape:DF_Shape
    {
        public DF_ResizeShape() { }

        public override void PaintCallBack(Object obj, PaintEventArgs pe)
        {
            base.PaintCallBack(obj, pe);
            Brush resizeBr = new SolidBrush(Color.Red);
            if (ShapeState == DF_ShapeState.EnterResizeArea)
            {
                DrawResizePoints(resizeBr, pe.Graphics);
            }
        }

        public override void MouseDownCallBack(Object obj, MouseEventArgs pe)
        {
            base.MouseDownCallBack(obj, pe);
            if (pe.Button == MouseButtons.Left)
            {
                if(ShapeState == DF_ShapeState.EnterResizeArea)
                {
                    switch (GetResizeDirection(pe.Location))
                    {
                        case DF_ResizeDir.Up:ShapeState = DF_ShapeState.ResizeUp; break;
                        case DF_ResizeDir.Down: ShapeState = DF_ShapeState.ResizeDown; break;
                        case DF_ResizeDir.Left: ShapeState = DF_ShapeState.ResizeLeft; break;
                        case DF_ResizeDir.Right: ShapeState = DF_ShapeState.ResizeRight; break;
                        case DF_ResizeDir.UpLeft: ShapeState = DF_ShapeState.ResizeUpLeft; break;
                        case DF_ResizeDir.UpRight: ShapeState = DF_ShapeState.ResizeUpRight; break;
                        case DF_ResizeDir.DownLeft: ShapeState = DF_ShapeState.ResizeDownLeft; break;
                        case DF_ResizeDir.DownRight: ShapeState = DF_ShapeState.ResizeDownRight; break;
                        default:
                            break;
                    }
                }
            }
        }

        public override void MouseUpCallBack(Object obj, MouseEventArgs pe)
        {
            base.MouseUpCallBack(obj, pe);
            if (pe.Button == MouseButtons.Left)
            {
                if(ShapeState == DF_ShapeState.ResizeUp 
                    || ShapeState == DF_ShapeState.ResizeDown
                    || ShapeState == DF_ShapeState.ResizeLeft
                    || ShapeState == DF_ShapeState.ResizeRight
                    || ShapeState == DF_ShapeState.ResizeUpLeft
                    || ShapeState == DF_ShapeState.ResizeUpRight
                    || ShapeState == DF_ShapeState.ResizeDownLeft
                    || ShapeState == DF_ShapeState.ResizeDownRight)
                {
                    SetShapeState(DF_ShapeState.Stop);
                }
            }
        }

        public override void MouseMoveCallBack(Object obj, MouseEventArgs pe)
        {
            base.MouseMoveCallBack(obj, pe);

            Panel p = (Panel)obj;
            if (ShapeState == DF_ShapeState.Stop)
            {
                if (IsInResizeArea(p, pe.Location) && !IsMouseInMoveTrigRect(pe.Location))
                {
                    SetShapeState(DF_ShapeState.EnterResizeArea);
                    InitResizeRects(p);
                    p.Invalidate();
                }
            }
            else if (ShapeState == DF_ShapeState.EnterResizeArea)
            {
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

                if (!IsInResizeArea(p, pe.Location))
                {
                    SetShapeState(DF_ShapeState.Stop);
                    p.Invalidate(true);
                }
            }
            else if(ShapeState == DF_ShapeState.ResizeUp)
            {
                int Delta = pe.Y - GVL.shape_pad;
                p.Top += Delta;
                p.Height += Math.Abs(Delta);
            }
            else if (ShapeState == DF_ShapeState.ResizeDown)
            {
                int Delta = pe.Y - (p.Height - GVL.shape_pad);
                p.Height += Math.Abs(Delta);
                p.Invalidate();
            }
            else if (ShapeState == DF_ShapeState.ResizeLeft)
            {
                int Delta = pe.X - GVL.shape_pad;
                p.Left += Delta;
                p.Width += Math.Abs(Delta);
            }
            else if (ShapeState == DF_ShapeState.ResizeRight)
            {
                int Delta = pe.X - (p.Width - GVL.shape_pad);
                p.Width += Math.Abs(Delta);
                p.Invalidate();
            }
            else if (ShapeState == DF_ShapeState.ResizeUpLeft)
            {
                int DeltaY = pe.Y - GVL.shape_pad;
                int DeltaX = pe.X - GVL.shape_pad;
                p.Top += DeltaY;
                p.Left += DeltaX;
                p.Height += Math.Abs(DeltaY);
                p.Width += Math.Abs(DeltaX);
            }
            else if (ShapeState == DF_ShapeState.ResizeUpRight)
            {
                int DeltaY = pe.Y - GVL.shape_pad;
                int DeltaX = pe.X - (p.Width - GVL.shape_pad);
                p.Top += DeltaY;
                p.Height += Math.Abs(DeltaY);
                p.Width += Math.Abs(DeltaX);
            }
            else if (ShapeState == DF_ShapeState.ResizeDownLeft)
            {
                int DeltaY = pe.Y - (p.Height - GVL.shape_pad);
                int DeltaX = pe.X - GVL.shape_pad;
                p.Left += DeltaX;
                p.Height += Math.Abs(DeltaY);
                p.Width += Math.Abs(DeltaX);
            }
            else if (ShapeState == DF_ShapeState.ResizeDownRight)
            {
                int DeltaY = pe.Y - (p.Height - GVL.shape_pad);
                int DeltaX = pe.X - (p.Width - GVL.shape_pad) ;
                p.Height += Math.Abs(DeltaY);
                p.Width += Math.Abs(DeltaX);
                p.Invalidate();
            }
        }


        List<Rectangle> resizeTrigRects = new List<Rectangle>();
        private bool IsInResizeArea(Panel p, Point Location)
        {
            Rectangle r1 = new Rectangle(0, 0, p.Width, p.Height);
            Rectangle r2 = new Rectangle(GVL.shape_pad, GVL.shape_pad, p.Width - GVL.shape_pad * 2, p.Height - GVL.shape_pad * 2);
            return r1.Contains(Location) && !r2.Contains(Location);
        }


        private void InitResizeRects(Panel p)
        {
            resizeTrigRects.Clear();
            int w0 = p.Width;
            int h0 = p.Height;

            resizeTrigRects.Add(new Rectangle(0, 0, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(w0 / 2, 0, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(w0 - GVL.shape_pad, 0, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(0, h0 / 2, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(w0 - GVL.shape_pad, h0 / 2, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(0, h0 - GVL.shape_pad, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(w0 / 2, h0 - GVL.shape_pad, GVL.shape_pad, GVL.shape_pad));
            resizeTrigRects.Add(new Rectangle(w0 - GVL.shape_pad, h0 - GVL.shape_pad, GVL.shape_pad, GVL.shape_pad));
        }

        private DF_ResizeDir GetResizeDirection(Point Location)
        {
            for (int i = 0; i < resizeTrigRects.Count; i++)
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
            if (resizeTrigRects.Count > 0)
            {
                g.FillRectangles(br, resizeTrigRects.ToArray());
            }
        }
    }
}
