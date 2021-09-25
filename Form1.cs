using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funktion__Diagramm
{
    public partial class Form1 : Form
    {

        Graphics z;
        Pen stift = new Pen(Color.Black,2);
        SolidBrush pinsel = new SolidBrush(Color.Black);
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        private double Nullstelle(double d,double f)
        {
            double a = Convert.ToDouble(textBox2.Text);
            d = d / a;
            f = f / a;
            double Nullstelle = -(d / 2) + Math.Sqrt(((d * d) / 4) - f);
            Nullstelle = Math.Round(Nullstelle, 3);
            return Nullstelle;
        }
        private double Nullstelle2(double d,double f)
        {
            double a = Convert.ToDouble(textBox2.Text);
            d = d / a;
            f = f / a;
            double Nullstelle = -(d / 2) - Math.Sqrt(((d * d) / 4) - f);
            Nullstelle = Math.Round(Nullstelle, 3);
            return Nullstelle;
        }
        private double Scheitelstelle(double d,double f)
        {
            double a = Convert.ToDouble(textBox2.Text);
            double x = -(d / (2 * a));
            x = Math.Round(x, 3);
            return x;
        }
        private double Scheitelstelle2(double d,double f)
        {
            double a = Convert.ToDouble(textBox2.Text);
            double y = ((4 * a * f) - (d * d)) / (4 * a);
            y = Math.Round(y, 3);
            return y;
        }
        private void Wertetabelle(double d,double f)
        {
            double a = Convert.ToDouble(textBox2.Text);
            double[] x = { -10, -9.5, -9, -8.5, -8, -7.5, -7, -6.5, -6, -5.5, -5, -4.5, -4, -3.5, -3, -2.5, -2, -1.5, -1, -0.5, 0, 0.5, 1, 1.5, 2, 2.5, 3, 3.5, 4, 4.5, 5, 5.5, 6, 6.5, 7, 7.5, 8, 8.5, 9, 9.5, 10 };//41
            for (int i = 0; i < 41; i++)
            {
                int n = 0;
                double[] y = { a * (x[i] * x[i]) + d * x[i] + f };
                listView1.Items.Add(Convert.ToString(x[i]));
                listView1.Items.Add(Convert.ToString(y[n]));
                n++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) | string.IsNullOrEmpty(textBox2.Text) | string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Felder bitte füllen");
            }
            else
            {
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(textBox3.Text);
                double c = Convert.ToDouble(textBox1.Text);
                listView1.Clear();
                if (a == 0)
                {
                    MessageBox.Show("keine Quadratische Funktion");
                }
                else
                {
                    Nullstelle(b, c);
                    Nullstelle2(b, c);
                    Scheitelstelle(b, c);
                    Scheitelstelle2(b, c);
                    Wertetabelle(b, c);

                    label7.Text = "=" + Convert.ToString(Nullstelle(b, c)) + ";" + Convert.ToString(Nullstelle2(b, c));
                    label6.Text = "Scheitelpunkt=(" + Convert.ToString(Scheitelstelle(b, c)) + ";" + Convert.ToString(Scheitelstelle2(b, c)) + ")";
                    label10.Text = "(0;" + Convert.ToString(c) + ")";
                }
                
            }
           
        }

      
    }
}
