using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Floppy : Form
    {
        public Floppy()
        {
            InitializeComponent();
            lbl_over.Hide();
        }
        int score;
        bool top;
        void coins()
        {
            Random rnd = new Random();
            int x;
            foreach (Control j in this.Controls)
            {
                if(j is PictureBox && j.Tag== "coins")
                {
                    j.Left -= 5;
                    if (j.Left < 0)
                    {
                        x = rnd.Next(80,300);
                        j.Location = new Point( 800,x);
                    }
                    if (Player.Bounds.IntersectsWith(j.Bounds))
                    {
                        x = rnd.Next(80, 300);
                        j.Location = new Point(800,x);
                        score += 5;
                        lbl_Score.Text = "Score :" + score;

                    } 
                }
            }
        }

        void stars()
        {
            foreach(Control s in this.Controls) 
            {
                if (s is Label && s.Tag == "stars")
                {
                    s.Left -= 8;
                    if(s.Left < -300)
                    {
                        s.Left = 700;
                    }
                    
                }
            }
        }
        void enemy()
        {
            foreach( Control x in this.Controls) 
            {
                if (x is PictureBox && x.Tag == "Enemy")
                {
                    x.Left -= 5;
                    if (x.Left < -300)
                    {
                        x.Left = 700;
                    }
                    if (Player.Bounds.IntersectsWith(x.Bounds))
                    {
                        timer1.Stop();
                        lbl_over.Show();
                        lbl_over.BringToFront();
                    }
                }
            }
        }


        void player_move()
        { 
            if (top == true)
            {
                Player.Top -= 3;
            }
            if (top == false)
            {
                Player.Top += 3;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space)
            {
                top = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                top = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            player_move();
            stars();
            enemy();
            coins();
        }
    }
}
