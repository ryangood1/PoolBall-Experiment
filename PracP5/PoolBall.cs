using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracP5
{
    class PoolBall : MovingBall
    {
        public PoolBall(int x, int y, int dx, int dy) : base(x,y,dx,dy)
        {
        }
        public override void Move()
        {
            base.Move();
            if (xCoord < 0)
            {
                xCoord = 0;
                XSpeed = -XSpeed;
            }
            else if (xCoord > 233)
            {
                xCoord = 233;
                XSpeed = -XSpeed;
            }

            if (yCoord < 0)
            {
                yCoord = 0;
                YSpeed = -YSpeed;
            }
            else if (yCoord > 117)
            {
                yCoord = 117;
                YSpeed = -YSpeed;
            }

        }
    }
}
