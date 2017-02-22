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

        static int szam;
        //static int aze;




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
        static int x = 0;
        static int y = 0;
        static int h;
        static int w;
        public void szal()
        {
            // bufferg.Clear(Color.White);

            

            lock (buffer)
            {
                h = buffer.Height;
                w = buffer.Width;
            }
            for (y = 0; y < h; y++) //sor 
            {
                for (x = 0; x < w; x++) //oszlop
                {
                    
                    szam = (y*w)+x;
                    
                    if (isPrime(szam)==true)
                    {
                        lock (buffer)
                        {
                            buffer.SetPixel(x, y, Color.Black);
                        }
                    }
                    else
                    {
                        
                            lock (buffer)
                            {
                                buffer.SetPixel(x, y, Color.White);
                            }

                        }
                    }
                }

                this.Invoke(new Action(() => { button1.Enabled = true; }));
            }  

           
        }
       // static int aze = 1;
        /*     static void prim1()
             {
                 for (int i = 2; i < szam /2; i++)
                 {
                     if (szam % i == 0)
                     {
                         aze = 1;

                     }
                     else
                     {
                         aze = 0;
                     }
                     }


             } */
        public static bool isPrime(int szam)
        {
            if (szam == 1) return false;
            if (szam== 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(szam));

            for (int i = 2; i <= boundary; ++i)
            {
                if (szam % i == 0) return false;
            }

            return true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (buffer == null)
                return;

           
        }

    }
}
