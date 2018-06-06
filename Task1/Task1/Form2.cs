using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task1
{
    public partial class Form2 : Form
    {

        public Font drawFont = new Font("Arial", 8); 
        public int xc;
        public int yc; //Координаты центра координатных осей

        public int maxx;
        public int maxy; //Длина осей  (исходя из размеров
        public int step;
        public int start;
        public int end;

        //public double ymin;
        //public double ymax;

        public Form2()
        {
            InitializeComponent();
        }

        //Отрисовка c координатными осями
        public void Draw()
        {
            Graphics g = Graphics.FromHwnd(pictureBox2.Handle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            g.Clear(Color.White);
            Pen mypen = new Pen(Color.Black, 1);
            Pen mypen1 = new Pen(Color.Black, 4);

            g.DrawLine(mypen1, 0, yc, maxx, yc);
            g.DrawLine(mypen1, xc, 0, xc, maxy);

            for (int i = 0; i <= maxx; i += step) // сетка
            {
                g.DrawLine(mypen, i, 0, i, maxx); 
                g.DrawLine(mypen, 0, i, maxx, i); 
            }

            //for (int i = 0; i <= maxx; i += step)
            //{
            //    g.DrawLine(mypen, i, yc-1, i, yc+1); // oy
            //    g.DrawLine(mypen, xc-1, i, xc+1, i); // oy
            //}

        }

        public int ChangeCoordinates(double a, int isY) //Перевод координат из реальных в машинные
        {
            if (isY == 1) return (int)(yc - a * step);
            return (int)(xc + a * step);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(pictureBox2.Handle);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            SolidBrush drawLineNewton = new SolidBrush(Color.Blue);

            start = int.Parse(textBox1.Text);
            end = int.Parse(textBox2.Text);
            var a = int.Parse(textBox3.Text);
            var b = int.Parse(textBox4.Text);
            maxx = int.Parse(textBox5.Text);
            maxy = int.Parse(textBox6.Text);

            step = maxx / Math.Abs(start - end);

            xc = Math.Abs(step * start);
            yc = Math.Abs(step * start);

            var i = (double) 1 / step;

            Draw();

            for (double xx = -maxx/2; xx < maxx/2; xx += 0.001)
            {
                var x = ChangeCoordinates(xx, 0);
                var y = ChangeCoordinates(Functions.Func(a, b, xx), 1);

                g.FillRectangle(drawLineNewton, x, y, 1, 1);

            }

        }

        //private void Form2_ResizeEnd(Object sender, EventArgs e)
        //{
        //    button1_Click(sender, new EventArgs());
        //}


        private void Form2_Load(object sender, EventArgs e)
        {

        }

       
    }
}
