﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Star_Adventure
{
    public partial class Form1 : Form
    {
        public List<PictureBox> Stars = new List<PictureBox>();
        public List<PictureBox> Asteroids = new List<PictureBox>();
        public int GameSpeed { get; set; }
        public int Points { get; set; }
        public Random Random { get; set; }
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.GameSpeed = 1;
            this.Points = 0;
            this.Random = new Random();
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            moveStars(GameSpeed);
            moveAsteroids(GameSpeed);
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
            int end = Asteroids.Count;
            for (int i = 0; i < end; i++)
            {
                if (Asteroids[i].Visible)
                {
                    if (Asteroids[i].Top >= 550)
                    {
                        Asteroids[i].Top = 0;
                        Asteroids[i].Left = Random.Next(0, 381);
                    }
                    else
                    {
                        Asteroids[i].Top += speed;
                    }
                }
                else
                {
                    Asteroids[i].Visible = true;
                    Asteroids[i].Left = Random.Next(0, 381);
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
    }
}
