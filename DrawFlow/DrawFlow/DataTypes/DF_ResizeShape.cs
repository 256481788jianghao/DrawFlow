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
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                int Delta = 0;
                if (w_dis[0] < 0)
                {
                    Delta = w_dis[0];
                }
                else if (n_dis[0] > 0)
                {
                    Delta = n_dis[0];
                }

                p.Top += Delta;
                p.Height += -Delta;
            }
            else if (ShapeState == DF_ShapeState.ResizeDown)
            {
                int Delta = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[1] > 0)
                {
                    Delta = w_dis[1];
                }
                else if (n_dis[1] < 0)
                {
                    Delta = n_dis[1];
                }

                p.Height += Delta;
                p.Invalidate();
            }
            else if (ShapeState == DF_ShapeState.ResizeLeft)
            {
                int Delta = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[2] < 0)
                {
                    Delta = w_dis[2];
                }
                else if (n_dis[2] > 0)
                {
                    Delta = n_dis[2];
                }

                p.Left += Delta;
                p.Width += -Delta;
            }
            else if (ShapeState == DF_ShapeState.ResizeRight)
            {
                int Delta = 0;

                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[3] > 0)
                {
                    Delta = w_dis[3];
                }
                else if (n_dis[3] < 0)
                {
                    Delta = n_dis[3];
                }


                p.Width += Delta;
                p.Invalidate();
            }
            else if (ShapeState == DF_ShapeState.ResizeUpLeft)
            {
                int DeltaY = 0;
                int DeltaX = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[0] < 0)
                {
                    DeltaY = w_dis[0];
                }
                else if (n_dis[0] > 0)
                {
                    DeltaY = n_dis[0];
                }

                if (w_dis[2] < 0)
                {
                    DeltaX = w_dis[2];
                }
                else if (n_dis[2] > 0)
                {
                    DeltaX = n_dis[2];
                }


                p.Top += DeltaY;
                p.Left += DeltaX;
                p.Height += -DeltaY;
                p.Width += -DeltaX;
            }
            else if (ShapeState == DF_ShapeState.ResizeUpRight)
            {
                int DeltaY = 0;
                int DeltaX = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[0] < 0)
                {
                    DeltaY = w_dis[0];
                }
                else if (n_dis[0] > 0)
                {
                    DeltaY = n_dis[0];
                }

                if (w_dis[3] > 0)
                {
                    DeltaX = w_dis[3];
                }
                else if (n_dis[3] < 0)
                {
                    DeltaX = n_dis[3];
                }


                p.Top += DeltaY;
                p.Height += -DeltaY;
                p.Width += DeltaX;
            }
            else if (ShapeState == DF_ShapeState.ResizeDownLeft)
            {
                int DeltaY = 0;
                int DeltaX = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[1] > 0)
                {
                    DeltaY = w_dis[1];
                }
                else if (n_dis[1] < 0)
                {
                    DeltaY = n_dis[1];
                }


                if (w_dis[2] < 0)
                {
                    DeltaX = w_dis[2];
                }
                else if (n_dis[2] > 0)
                {
                    DeltaX = n_dis[2];
                }

                p.Left += DeltaX;
                p.Height += DeltaY;
                p.Width += -DeltaX;
            }
            else if (ShapeState == DF_ShapeState.ResizeDownRight)
            {
                int DeltaY = 0;
                int DeltaX = 0;
                int[][] dis = DistanceToRect(p, pe.Location);
                int[] w_dis = dis[0];
                int[] n_dis = dis[1];

                if (w_dis[1] > 0)
                {
                    DeltaY = w_dis[1];
                }
                else if (n_dis[1] < 0)
                {
                    DeltaY = n_dis[1];
                }

                if (w_dis[3] > 0)
                {
                    DeltaX = w_dis[3];
                }
                else if (n_dis[3] < 0)
                {
                    DeltaX = n_dis[3];
                }

                p.Height += DeltaY;
                p.Width += DeltaX;
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

        //计算某个点距离内矩形和外矩形四边的距离，顺序是上下左右
        private int[][] DistanceToRect(Panel p,Point location)
        {
            int[] w_dis = new int[4];
            int[] n_dis = new int[4];

            Rectangle r = new Rectangle(GVL.shape_pad, GVL.shape_pad, p.Width - 2 * GVL.shape_pad, p.Height - 2 * GVL.shape_pad);

            w_dis[0] = location.Y;
            w_dis[1] = location.Y - p.Height;
            w_dis[2] = location.X;
            w_dis[3] = location.X - p.Width;

            n_dis[0] = location.Y - r.Top;
            n_dis[1] = location.Y - r.Bottom;
            n_dis[2] = location.X - r.Left;
            n_dis[3] = location.X - r.Right;

            return new int[2][] { w_dis, n_dis };
        }
    }
}
