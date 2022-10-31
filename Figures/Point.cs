using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }   
        public double DistanceBetween(Point a)
        {
            return Math.Sqrt((X - a.X) * (X - a.X) + (Y - a.Y) * (Y - a.Y));
        }
    }
}
