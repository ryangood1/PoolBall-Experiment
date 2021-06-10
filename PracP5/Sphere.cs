﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracP5
{
    public class Sphere
    {
        protected int xCoord = 100, yCoord = 100;
        protected const int size = 10;
        protected Pen pen = new Pen(Color.Black);
        
        public int X
        {
            get { return xCoord; }
        }
        public int Y
        {
            get { return yCoord; }
        }

        /// <summary>
        /// Displays the ball 
        /// </summary>
        /// <param name="paper">The Graphics object to use for the drawing</param>
        public virtual void Display(Graphics paper)
        {
            paper.DrawEllipse(pen, xCoord, yCoord, size, size);
        }
    }
}
