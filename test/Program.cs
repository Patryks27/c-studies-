using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Biało_Czarne_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            var r = new Random();
            var A = splitContainer1.Panel1.Controls;
            foreach (var item in Enumerable.Range(1, 5))
            {
                var p = new PictureBox();
                p.Dock = DockStyle.Top;
                p.BorderStyle = BorderStyle.Fixed3D;
                p.BackColor = r.NextDouble() > 0.5 ? Color.White : Color.Black;
                A.Add(p);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var A = splitContainer1.Panel1.Controls;
            var B = splitContainer1.Panel2.Controls;
            var r = new Random();
            if (A.Count > 1)
            {
                var i = r.Next(A.Count);
                var a = A[i] as PictureBox;
                B.Add(a);
                var j = r.Next(A.Count);
                var b = A[j] as PictureBox;
                B.Add(b);
                if (a.BackColor != b.BackColor)
                {
                    if (a.BackColor == Color.Black)
                    {
                        A.Add(a);
                    }
                    else
                    {
                        A.Add(b);
                    }
                }
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Koniec algorytmu");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }
}