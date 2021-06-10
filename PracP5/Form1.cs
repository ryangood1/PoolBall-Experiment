using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PracP5
{
    public partial class Form1 : Form
    {
        // The number of balls to display
        private const int NUM_BALLS = 16;

        // List to hold the balls
        private List<ColorPoolBall> balls = new List<ColorPoolBall>();

        // Random object
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        /// <summary>
        /// Initialize the ball list and start the timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonGo_Click(object sender, EventArgs e)
        {
            balls = new List<ColorPoolBall>();
          
            //generate balls in random positions, at random speeds
            //while loop since we don't want to generate two balls that overlap
            int i = 0;
            while (i < NUM_BALLS)
            {
                //new ball position is inside table, and speed is in range -3 to +3
                ColorPoolBall newBall = new ColorPoolBall(random.Next(233), random.Next(117), random.Next(7) - 3, random.Next(7) - 3);
                //check if overlaps any existing balls
                if (!CheckOverlaps(newBall))
                { //ball position is good, so add it
                    balls.Add(newBall);
                    i++; //add 1 to ball count
                }
                
            }

            //start timer for movement
            timerTime.Enabled = true;
        }

        /// <summary>
        /// Update the positions of the balls randomly
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTime_Tick(object sender, EventArgs e)
        {
            Graphics paper = pictureBoxTable.CreateGraphics();
            pictureBoxTable.Refresh();


            // Update position of each ball
            foreach (ColorPoolBall b in balls)
            {
                //move the ball
                b.Move();

                //check if ball is colliding to change their direction
                CheckCollisions(b);

                // draw the ball
                b.Display(paper);
                Console.Write(b.ToString());
            }
        }

        private void CheckCollisions(ColorPoolBall ball)
        {
            // Make list of balls to check collisions against
            List<ColorPoolBall> collisionList = new List<ColorPoolBall>();
            foreach (ColorPoolBall b in balls)
            {
                collisionList.Add(b);
            }

            // Remove ball as we don't need to see if ball collides with itself
            collisionList.Remove(ball);

            // Check for collision with every other ball
            foreach (ColorPoolBall b2 in collisionList)
            {
                if (ball.CollidesWith(b2))
                {
                    ball.Touching(b2);
                    //bounce both balls - this is not very accurate :-(
                    ball.XSpeed *= -1;
                    ball.YSpeed *= -1;

                    b2.XSpeed *= -1;
                    b2.YSpeed *= -1;
                }
            }
        }

        private bool CheckOverlaps(ColorPoolBall ball)
        {
            //check if overlaps any existing balls
            foreach (ColorPoolBall b in balls)
            {
                if (ball.CollidesWith(b))
                {
                    ball.Touching(b);
                    return true; //found an overlap
                }
            }
            return false; //got to end of loop, so no overlaps
        }
    }
}

