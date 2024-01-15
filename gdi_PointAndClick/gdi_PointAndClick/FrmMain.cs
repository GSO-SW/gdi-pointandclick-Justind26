using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace gdi_PointAndClick
{
    public partial class FrmMain : Form
    {
        List<Rectangle> rectangles = new List<Rectangle>();

        public FrmMain()
        {
            InitializeComponent();
            ResizeRedraw = true;
        }

        private void FrmMain_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Brush b = new SolidBrush(Color.Blue);

            foreach (Rectangle rect in rectangles)
            {
                g.FillRectangle(b, rect);
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Random random = new Random();

            Point mausPosition = e.Location;

            Rectangle newRect = new Rectangle(mausPosition.X - 20, mausPosition.Y - 20, random.Next(1, 99), random.Next(1, 99));

            bool overlap = false;
            foreach (Rectangle existingRect in rectangles)
            {
                if (existingRect.IntersectsWith(newRect))
                {
                    overlap = true;
                    break;
                }
            }

            if (!overlap)
            {
                rectangles.Add(newRect);
                Refresh();
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                rectangles.Clear();
                Refresh();
            }
        }
    }
}
