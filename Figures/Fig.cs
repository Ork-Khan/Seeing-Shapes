using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Fig
    {
        public abstract LinkedList<Point> Points { get; set; }
        //public abstract LinkedList<double> Sides { get; set; }
        public abstract double area { get; set; }
        public abstract double perimetr { get; set; }
        public abstract void MoveFigure(double a, double b);
        public abstract void Area();
        public abstract void Perimetr();
        public abstract void Center();
        public abstract void Scale(double ScaleParam);
        public abstract void Rotate(double RotationParam);

    }
}
