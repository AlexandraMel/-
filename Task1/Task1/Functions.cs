using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.DataVisualization.Charting;

namespace Task1
{
    public static class Functions
    {
        public static double Func(double a, double b, double x)
        {
            return Math.Asin(a) * x / Math.Sqrt(b * b - x * x);
            //return (a * Math.Pow(x, 4) / (Math.Pow((b + x), 3)));
        }

        public static double Func1(int a, int b, double x)
        {
            return x;
        }
    }
  
}

