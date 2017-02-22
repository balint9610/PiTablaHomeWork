using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        class PrimeSearcher
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
