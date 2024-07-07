using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star_Adventure
{
    public partial class Form1 : Form
    {
        public List<PictureBox> PointStars = new List<PictureBox>();
        public List<PictureBox> Stars = new List<PictureBox>();
        public List<PictureBox> Asteroids = new List<PictureBox>();
        public List<PictureBox> Everything = new List<PictureBox>();
        public List<int> highScores = new List<int>();

        public int GameSpeed { get; set; }
        public int Points { get; set; }
        public Random Random { get; set; }
        public bool IncreaseSpeed;
        public int AsteroidCount;
        public int PointStarsCount;
        public Form1()
        {
            InitializeComponent();
            lblGameOver.Visible = false;
            this.AsteroidCount = 1;
            btnRetry.Visible = false;
            btnViewHighscore.Visible = false;
            IncreaseSpeed = false;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.GameSpeed = 1;
            this.Points = 0;
            this.Random = new Random();
            this.KeyPreview = true;
            this.Focus();
            falcon.BringToFront();
            Stars.Add(pictureBox1);
            Stars.Add(pictureBox2);
            Stars.Add(pictureBox3);
            Stars.Add(pictureBox4);
            Stars.Add(pictureBox5);
            Stars.Add(pictureBox6);
            Stars.Add(pictureBox7);
            Stars.Add(pictureBox8);
            Stars.Add(pictureBox9);
            Stars.Add(pictureBox10);
            Stars.Add(pictureBox11);
            Stars.Add(pictureBox12);
            Stars.Add(pictureBox13);
            Stars.Add(pictureBox14);
            Asteroids.Add(asteroid);
            Asteroids.Add(asteroid2);
            Asteroids.Add(asteroid3);
            Asteroids.Add(asteroid4);
            Asteroids.Add(asteroid5);
            PointStars.Add(pointstar1);
            PointStars.Add(pointstar2);
            PointStars.Add(pointstar3);
            PointStars.Add(pointstar4);
            PointStars.Add(pointstar5);
            foreach (PictureBox pointStar in PointStars)
            {
                Everything.Add(pointStar);
            }
            foreach (PictureBox asteroid in Asteroids)
            {
                Everything.Add(asteroid);
            }
        }
        private void StartRace()
        {
            Points = 0;
            GameSpeed = 1;
            IncreaseSpeed = false;
            lblGameOver.Visible = false;
            lblDescription.Visible = false;
            btnPlay.Visible = false;
            btnRetry.Visible = false;
            btnViewHighscore.Visible = false;
            AsteroidCount = (int)Points / 5;
            PointStarsCount = (int)Points / 2;

            falcon.Left = (this.ClientSize.Width - falcon.Width) / 2;
            falcon.Top = this.ClientSize.Height - falcon.Height - 10;

            for (int i = 0; i < Asteroids.Count; i++)
            {
                Asteroids[i].Visible = false;
            }

            for (int i = 0; i < PointStars.Count; i++)
            {
                PointStars[i].Visible = false;
            }
            timer1.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            moveStars(GameSpeed);
            moveAsteroids(GameSpeed);
            IsGameOver();
            movePointStars(GameSpeed);
            collectedPoints();
        }

        void INvisibility(List<PictureBox> pics)
        {
            foreach (PictureBox pictureBox in pics)
            {
                pictureBox.Visible = false;
            }
        }

        void moveStars(int speed)
        {
            foreach (PictureBox star in Stars)
            {
                if (star.Top >= 550)
                {
                    star.Top = 0;
                }
                else
                {
                    star.Top += speed;
                }
            }

        }

        void moveAsteroids(int speed)
        {
            AsteroidCount = (int)Points / 5;

            if (AsteroidCount >= Asteroids.Count)
            {
                AsteroidCount = Asteroids.Count;
            }

            for (int i = 0; i < AsteroidCount; i++)
            {
                if (!Asteroids[i].Visible)
                {
                    Asteroids[i].Visible = true;
                    Asteroids[i].Top = 0;
                    Asteroids[i].Left = Random.Next(0, 381);
                    Asteroids[i] = checkIntersection(Asteroids[i]);
                }
            }

            for (int i = 0; i < Asteroids.Count; i++)
            {
                if (Asteroids[i].Visible)
                {
                    if (Asteroids[i].Top >= 550)
                    {
                        Asteroids[i].Top = 0;
                        Asteroids[i].Left = Random.Next(0, 381);
                        Asteroids[i] = checkIntersection(Asteroids[i]);
                    }
                    else
                    {
                        Asteroids[i].Top += speed;
                        Asteroids[i] = checkIntersection(Asteroids[i]);
                    }
                }
            }


        }

        public PictureBox checkIntersection(PictureBox e)
        {
            List<PictureBox> list = Everything.Where(v => v != e).ToList();
            foreach (PictureBox anything in list)
            {
                    while (anything.Bounds.IntersectsWith(e.Bounds) && anything.Visible)
                    {
                        e.Left = Random.Next(0, 381);
                    }
            }
            return e;
        }

        void movePointStars(int speed)
        {

            PointStarsCount = (int)Points / 2;

            if (PointStarsCount == 0)
            {
                PointStarsCount = 1;
            }
            else if (PointStarsCount >= PointStars.Count)
            {
                PointStarsCount = PointStars.Count;
            }

            for (int i = 0; i < PointStarsCount; i++)
            {
                if (!PointStars[i].Visible)
                {
                    PointStars[i].Visible = true;
                    PointStars[i].Top = 0;
                    PointStars[i].Left = Random.Next(0, 381);
                    PointStars[i] = checkIntersection(PointStars[i]);
                }
            }

            for (int i = 0; i < PointStars.Count; i++)
            {
                if (PointStars[i].Visible)
                {
                    if (PointStars[i].Top >= 550)
                    {
                        PointStars[i].Top = 0;
                        PointStars[i].Left = Random.Next(0, 381);
                        PointStars[i] = checkIntersection(PointStars[i]);
                    }
                    else
                    {
                        PointStars[i].Top += speed;
                        PointStars[i] = checkIntersection(PointStars[i]);
                    }
                }
            }
        }

        public void collectedPoints()
        {
            foreach (var pictureBox in PointStars)
            {
                if (falcon.Bounds.IntersectsWith(pictureBox.Bounds) && pictureBox.Visible)
                {
                    Points += 1;
                    pictureBox.Visible = false;
                    pictureBox.Top = 0;
                }
            }

            label1.Text = Points.ToString() + " " + GameSpeed.ToString();

            if (Points % 3 == 0 && Points != 0 && !IncreaseSpeed)
            {
                GameSpeed += 1;
                IncreaseSpeed = true;
            }


            if (Points % 3 != 0)
            {
                IncreaseSpeed = false;
            }
        }

        public void IsGameOver()
        {
            Rectangle falconBounds = new Rectangle(
                    falcon.Left + 10,
                    falcon.Top + 10,
                    falcon.Width - 20,
                    falcon.Height - 20
                );
            foreach (var pictureBox in Asteroids)
            {
                if (falconBounds.IntersectsWith(pictureBox.Bounds) && pictureBox.Visible)
                {
                    timer1.Enabled = false;
                    lblGameOver.BringToFront();
                    lblGameOver.Visible = true;
                    btnRetry.Visible = true;
                    btnViewHighscore.Visible = true;
                    btnRetry.BringToFront();
                    btnViewHighscore.BringToFront();

                    highScores.Add(Points);
                }

            }
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (falcon.Left > 2)
                {
                    falcon.Left += -7;
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (falcon.Left < 360)
                {
                    falcon.Left += 7;
                }
            }
            else if (e.KeyCode == Keys.A)
            {
                if (falcon.Left > 2)
                {
                    falcon.Left += -7;
                }
            }
            else if (e.KeyCode == Keys.D)
            {
                if (falcon.Left < 360)
                {
                    falcon.Left += 7;
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (falcon.Top > 6)
                {
                    falcon.Top += -7;
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (falcon.Top < 434)
                {
                    falcon.Top += 7;
                }
                else
                {
                    falcon.Top = 437;
                }
            }
            else if (e.KeyCode == Keys.W)
            {
                if (falcon.Top > 6)
                {
                    falcon.Top += -7;
                }
            }
            else if (e.KeyCode == Keys.S)
            {
                if (falcon.Top < 434)
                {
                    falcon.Top += 7;
                }
                else
                {
                    falcon.Top = 437;
                }
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            StartRace();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            StartRace();
        }

        private void btnViewHighscore_Click(object sender, EventArgs e)
        {
            HighscoresForms hf= new HighscoresForms(highScores);
            hf.Show();
        }
    }
}
