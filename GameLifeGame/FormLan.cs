using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameLifeGame
{
    public partial class FormLan : Form
    {
        public FormLan()
        {
            InitializeComponent();
        }

        private Graphics graphics;
        private bool[,] field;
        private int resulution = 3;
        private int rows;
        private int cols;
        public int antX;
        public int antY;
        public int antDirection = 0; // 0 - up, 1 - right, 2 - down, 3 - left
        public bool work = true;
        private void startGame()
        {
            if (timer1.Enabled)
                return;
            rows = pictureBox1.Height / resulution;
            cols = pictureBox1.Width / resulution;
            antX = cols / 2;
            antY = rows / 2;
            Random random = new Random();
            field = new bool[cols, rows];
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    field[x, y] = false;
                }
            }


            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);
            timer1.Start();
            //while(work==true)
            //{
            //    NextGeneration();
            //}

        }
        private void NextGeneration()
        {
            graphics.Clear(Color.Black);
            var newField = new bool[cols, rows];
            try
            {
                if (field[antX, antY] == false)
                {
                    field[antX, antY] = true;
                    antDirection++;
                    if (antDirection > 3)
                    {
                        antDirection = 0;
                    }
                    StepAnt(antDirection);
                }
                if (field[antX, antY] == true)
                {
                    field[antX, antY] = false;
                    antDirection--;
                    if (antDirection < 0)
                    {
                        antDirection = 3;
                    }
                    StepAnt(antDirection);
                }
            }
            catch
            {
                timer1.Stop();
            }
            
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    if (field[x, y])
                    {
                        graphics.FillRectangle(Brushes.White, x * resulution, y * resulution, resulution, resulution);
                    }


                }
            }





            pictureBox1.Refresh();

        }

        private void StepAnt(int antderection)
        {

            switch (antderection)
            {
                case 0: // up
                    antY = antY + 1;

                    break;
                case 1: // right
                    antX = antX + 1;
                    break;
                case 2: // down
                    antY = antY - 1;
                    break;
                case 3: // left
                    antX = antX - 1;
                    break;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            startGame();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }
    }
}
