using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird223
{
    public partial class Form1 : Form
    {
        int gravity = 10;
        int pipeSpeed = 6;
        int score = 0;
        private object scoreLabel;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bird.Top += gravity;
            pipeTop.Left -= pipeSpeed;
            pipeBottom.Left -= pipeSpeed;
            scoreLabel.Text = $"Score: {score}";

            if(pipeTop.Left < -100)
            {
                pipeTop.Left = 500;
                score++;
            }

            if(pipeBottom.Left < -100)
            {
                pipeBottom.Left = 600;
                score++;
            }

            if(Bird.Top < -25)
            {
                gameOver();
            }


            if (Bird.Bounds.IntersectsWith(pipeTop.Bounds) || Bird.Bounds.IntersectsWith(pipeBottom.Bounds) || Bird.Bounds.IntersectsWith(grounds.Bounds))
            {
                gameOver();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -5;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void gameOver()
        {
            timer1.Stop();
            scoreLabel.Text = $"Game Over!";
            playAgain.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();
            NewForm.Show();
            this.Dispose(false);
        }
    }
}
