using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracP5
{
    class ColorPoolBall : PoolBall
    {
        private Color c;
        Random rand = new Random();
        public ColorPoolBall(int x, int y, int dx, int dy) : base(x,y,dx,dy)
        {
            c = GetColour();
        }

        private Color GetColour()
        {
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        public override void Display(Graphics paper)
        {
            base.Display(paper);
            SolidBrush br = new SolidBrush(c);
            
            paper.FillEllipse(br, xCoord, yCoord, size, size);
        }

        public void ChangeColour()
        {
            //c = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }
    }
}
