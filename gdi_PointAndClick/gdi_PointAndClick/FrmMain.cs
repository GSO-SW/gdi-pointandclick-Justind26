using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.ConstrainedExecution;
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

            Random rnd = new Random();

            Brush b1 = new SolidBrush(Color.Blue);
            Brush b2 = new SolidBrush(Color.Red);
            Brush b3 = new SolidBrush(Color.Green);

            int rndInt = rnd.Next(1, 3);

            foreach (Rectangle rect in rectangles)
            {
                if(rndInt == 1)
                { 
                    g.FillRectangle(b1, rect);
                }
                else if( rndInt == 2)
                {
                    g.FillRectangle(b2, rect);
                }
                else if( rndInt == 3)
                {
                    g.FillRectangle(b3, rect);
                }
            }
        }

        private void FrmMain_MouseClick(object sender, MouseEventArgs e)
        {
            Random random = new Random();

            Point mausPosition = e.Location;

            Rectangle r = new Rectangle(mausPosition.X - 20, mausPosition.Y - 20, random.Next(1, 99), random.Next(1, 99));

            if (!rectangles.Contains(r))
            {
                rectangles.Add(r);
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
