using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    static class PrimeSearcher
    {
        static bool prim1(int p)
        {
            for (int i = 2; i < p; i++)
            {
                if (p % i == 0)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
