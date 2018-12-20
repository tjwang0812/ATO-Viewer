using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

struct Pt
{
    public int x;
    public int y;

};


namespace ATO_Viewer
{
    public partial class TD : UserControl
    {
        Pen[] myPENS = new Pen[5];
        Pen pen_White = new Pen(Color.White, 1);
        Pen pen_red = new Pen(Color.Red, 1);
        Pen pen_orange = new Pen(Color.Orange, 1);
        Pen pen_gray = new Pen(Color.Gray, 1);
        Pen pen_green = new Pen(Color.Green, 1);
        private Graphics g1;
        private Graphics g2;
        public TD()
        {
            InitializeComponent();
            myPENS[0] = pen_White;
            myPENS[1] = pen_red;
            myPENS[2] = pen_orange;
            myPENS[3] = pen_gray;
            myPENS[4] = pen_green;
        }


        public void DrawCurveArea()
        {
            //该控件未被释放，且可见
            if (!this.IsDisposed && this.Visible)
            {
                BufferedGraphicsContext myContext = BufferedGraphicsManager.Current;
                BufferedGraphics buffer = myContext.Allocate(this.splitContainer1.Panel1.CreateGraphics(), this.splitContainer1.Panel1.ClientRectangle);
                if (buffer.Graphics != null)
                {
                    //将整个“图形显示区”绘制成黑色
                    buffer.Graphics.Clear(Color.Black);
                    g1 = buffer.Graphics;
                    DrawSpeedCurve();
                }
                buffer.Render();
                buffer.Dispose();
            }
        }

        //提取数据的点x，y坐标
        private void DrawSpeedCurve()
        { 
            Pt[] pt = new Pt[100];
            Pt pt_first,pt_curr, pt_last;

            //初始化点，用这些点组成线
            for (int i = 0; i < 100; i++)
            {
                pt[i].x = i;
                pt[i].y = i + 5;
            }
            //起点
            pt_first = pt[0];

            for (int i = 1; i < 100; i++)
            { 
                pt_curr = pt[i];
                pt_last = pt[i - 1];
                DrawPointToLine(pt_last.x, pt_last.y, pt_curr.x, pt_curr.y);   
            }
        }

        //根据当前点和上一点画线
        private void DrawPointToLine(int LastPointX,int LastPointY,int CurrentPointX,int CurrentPointY)
        {
            Point plast = new Point(LastPointX, LastPointY);
            Point pcurr = new Point(CurrentPointX, CurrentPointY);
            g1.DrawLine(pen_White, plast, pcurr);
        }


    }
}
