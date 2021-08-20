using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Labrador
{
    public partial class Form1 : Form
    {


        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void pipeTop_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyLab.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (pipeBottom.Left < -170)
            {
                pipeBottom.Left = 800;
                score++;

            }

            if (pipeTop.Left < - 140)
            {
                pipeTop.Left = 950;
                score++;

            }

            if (flappyLab.Bounds.IntersectsWith(pipeBottom.Bounds)  ||
                flappyLab.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyLab.Bounds.IntersectsWith(ground.Bounds) ||
                flappyLab.Top < -25

                )
            {
                endGame();                

            }

            if (score > 5)
            {
                pipeSpeed = 12;

            }
           
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = -12;

            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {

                gravity = 12;

            }

        }

        private void endGame()
        {

            gameTimer.Stop();
            scoreText.Text += " Game Over...!";        
        
        }
                
    }
}
