using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap buffer;
        Graphics bufferg;


        Thread t;
        PrimeSearcher.prim1();

        private void Form1_Load(object sender, EventArgs e)
        {
            buffer = new Bitmap(panel2.Width, panel2.Height);
            lock (buffer)
                bufferg = Graphics.FromImage(buffer);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;

            t = new Thread(new ThreadStart(szal));
            t.Start();

        }
        void szal()
        {
            bufferg.Clear(Color.White);

            int h, w;

            lock (buffer)
            {
                h = buffer.Height;
                w = buffer.Width;
            }

           

            this.Invoke(new Action(() => { button1.Enabled = true; }));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer == null)
                return;

            using (Graphics g = panel2.CreateGraphics())
            {
                lock (buffer)
                    g.DrawImage(buffer, 0, 0);
            }
        }
       static  class  PrimeSearcher
        {
            static bool prim1(int p)
            {
                for (int i = 2; i < p; i++)
                {
                    if (p%i ==0)
                    {
                        return true;
                    }
                }return false;
            }

        }
    }
}
