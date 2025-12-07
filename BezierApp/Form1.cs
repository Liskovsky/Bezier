using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.IO;
using BezierApp;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing.Text;

namespace BezierApp
{
    public partial class Form1 : Form
    {
        private List<PointF> controlPoints = new List<PointF>();
        private List<PointF> splinePoints = new List<PointF>();
        private float stepSize = 0.01F;

        private System.Drawing.Point p0;
        private System.Drawing.Point p1;
        private System.Drawing.Point p2;
        private System.Drawing.Point p3;

        public Form1()
        {
            InitializeComponent();
        }
        public void Form1_Load(object sender, EventArgs e)
        {
        }
        private void BezierClassic()
        {
            Random random = new Random();
            p0 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p1 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p2 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p3 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));

            Bitmap drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(drawArea);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            Pen blue = new Pen(System.Drawing.Color.Blue);
            Pen red = new Pen(System.Drawing.Color.Red, 2);

            List<System.Drawing.Point> p = new List<System.Drawing.Point> { p0, p1, p2, p3 };
            g.DrawBezier(red, p0, p1, p2, p3);
            foreach (System.Drawing.Point point in p)
            {
                g.DrawRectangle(blue, point.X - 3, point.Y - 3, 2, 2);
            }
            pictureBox.Image = drawArea;
        }
        private void VytvorKrivkuBezier()
        {
            Bitmap drawArea = new Bitmap(pictureBox.Width, pictureBox.Height);
            Graphics g = Graphics.FromImage(drawArea);
            
            Pen red = new Pen(System.Drawing.Color.Red, 2);

            // Definujeme ètyøi body pro Bézierovu køivku
            Random random = new Random();
            p0 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p1 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p2 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));
            p3 = new System.Drawing.Point(random.Next(pictureBox.Width), random.Next(pictureBox.Height));

            PointF[] bezierBody = new PointF[] { p0, p1, p2, p3 };

            // Generujeme kubickou Bézierovu køivku
            for (float t = 0; t <= 1; t += 0.09f)
            {
                PointF point = GenerujBezierBody(p0, p1, p2, p3, t);
                g.FillEllipse(Brushes.Green, point.X - 3, point.Y - 3, 2, 2);
            }

            // Vykreslíme si Bézierovu køivku
            PointF[] curvePoints = new PointF[101]; // 101 bodù pro vyhlazení køivky
            for (int i = 0; i <= 100; i++)
            {
                float t = i / 100.0f;
                curvePoints[i] = GenerujBezierBody(p0, p1, p2, p3, t);
            }
            g.DrawLines(red, curvePoints);

            pictureBox.Image = drawArea;
        }

        private PointF GenerujBezierBody(PointF p0, PointF p1, PointF p2, PointF p3, float t)
        {
            // Implementace generování bodu na Bézierovì køivce na základì ètyø bodù a parametru t

            float x = (float)(Math.Pow(1 - t, 3) * p0.X + 3 * Math.Pow(1 - t, 2) * t * p1.X + 3 * (1 - t) 
                                                         * Math.Pow(t, 2) * p2.X + Math.Pow(t, 3) * p3.X);

            float y = (float)(Math.Pow(1 - t, 3) * p0.Y + 3 * Math.Pow(1 - t, 2) * t * p1.Y + 3 * (1 - t) 
                                                         * Math.Pow(t, 2) * p2.Y + Math.Pow(t, 3) * p3.Y);

            return new PointF(x, y);
        }
        private void buttonDZ_Click(object sender, EventArgs e)
        {
            VytvorKrivkuBezier();
            buttonZ.Visible = true;
        }

        private void button_Click(object sender, EventArgs e)
        {
            BezierClassic();
            buttonZ.Visible = true;
        }

        private void SpojBody()
        {
            // Naèteme existující obrázek s køivkou
            Bitmap drawArea = (Bitmap)pictureBox.Image;
            Graphics g = Graphics.FromImage(drawArea);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Modré zobrazení pøímek
            Pen blue = new Pen(System.Drawing.Color.Blue, 1);

            // Vykreslíme pøímky mezi body
            g.DrawLine(blue, p0, p1);
            g.DrawLine(blue, p1, p2);
            g.DrawLine(blue, p2, p3);

            // Aktualizace obrázku na formuláøi
            pictureBox.Image = drawArea;
        }

        private void buttonZ_Click(object sender, EventArgs e)
        {
            SpojBody();
        }

    }
}