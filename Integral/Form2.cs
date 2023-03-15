using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integral
{
    public partial class Form2 : Form
    {
        Bitmap picture;
        public Form2()
        {
            InitializeComponent();
            picture = new Bitmap(600, 300);
        }
        double function(double x)
        {


            return x; // tyta funcia budet;
        }


        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            double a = -10, b = 2;
            double max = 5, min = -10;//Границы интеграла
            Graphics graphics = Graphics.FromImage(picture);

            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.SmoothingMode = SmoothingMode.HighQuality;


            Pen pen = new Pen(Color.Red, 1f);
            Pen pen2 = new Pen(Color.Black, 3f);
            Pen pen3 = new Pen(Color.Black, 9f);
            Pen pen4 = new Pen(Color.DarkRed, 1f);
            Pen pen5 = new Pen(Color.Gray, 1f);


            
            double c = 600 / ((b - a));


            Point abs = new Point((int)(-a * c), 0);
            Point abs2 = new Point((int)(-a * c), 300);
            Point ord = new Point(0, 150);
            Point ord2 = new Point(600, 150);
            Point[] points = new Point[600];
            Point[] points2 = new Point[600];

            double k1 = (1 + (int)(b - a) / 20);
            int k = (int)(k1);
            double massh2 = max - 0;
            double massh3 = 0 - min;
            double massh;
            if (massh2 >= massh3)
            {
                massh = massh2;
            }
            else massh = massh3;




            for (int i = 0; i < 600; i++)
            {

                Point ord3 = new Point(i, 150);
                double d = a + i / c;
                points[i] = new Point(i, (int)(-function(d) / massh * 100 + 150));
                points2[i] = new Point(i, 150);
                graphics.DrawLine(pen, points2[i], points[i]);

                if (i == -a * c - 1)
                {
                    graphics.DrawLine(pen2, abs, abs2);
                    graphics.DrawLine(pen2, ord, ord3);
                    i++;
                    graphics.DrawLine(pen2, ord, ord3);
                    i++;

                }
                graphics.DrawLine(pen2, ord, ord3);
                graphics.DrawRectangle(pen4, points[i].X, points[i].Y, 1, 1);


                //Thread.Sleep(5);
                pictureBox1.Image = picture;
                pictureBox1.Refresh();
            }
            for (int i = 0; i <= ((b - a) / k) + 1; i++)
            {
                int g = (int)(-a * c);
                double h = 600 / (b - a);
                int j = (int)(h);
                double a1 = Math.Abs(a);
                int o = 0;

                if (a >= 0)
                    o = (int)(1 - a1 % 1 * c);
                if (a < 0)
                    o = (int)(a1 % 1 * c);
                if (a % 2 != 0)
                    o = o + j;

                Point set = new Point(o + j * (int)(k) * i, 0);
                Point set2 = new Point(o + j * (int)(k) * i, 300);
                graphics.DrawLine(pen5, set, set2);
            }

            for (int i = 0; i < 150; i++)
            {
                Point set = new Point(0, i);
                Point set2 = new Point(600, i);
                double max1 = max;
                int y = 0;
                while ((int)(max1) % 10 != 0)
                {
                    max1 = max1 + 1;

                }
                double max2 = (100 / max) * max1;
                double max3 = max2 / 10;




                /*double v = max / Math.Pow(10, y);
                double max2 = (Math.Round(v) * Math.Pow(10, y) - max) * Math.Pow(10, y);
                double max3 = ((100 / max) * max2)/10;//5.56*/
                Point setx = new Point(0, 150 - i);
                Point setx2 = new Point(600, 150 - i);
                Point setx3 = new Point(0, 150 + i);
                Point setx4 = new Point(600, 150 + i);
                graphics.DrawLine(pen5, setx, setx2);
                graphics.DrawLine(pen5, setx3, setx4);



                i = i + (int)(max3) - 1;

            }
            pictureBox1.Image = picture;
            pictureBox1.Refresh();
            //pictureBox1.Refresh();
        }
    }
}
