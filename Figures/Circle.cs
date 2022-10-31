using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Fig
    {
        public override LinkedList<Point> Points { get ; set ; }
        public override double area { get ; set ; }
        public override double perimetr { get ; set ; }
        public double radius;
        public Point Centre;
        public Circle(LinkedList<Point> points)
        {
            this.Points = points;
            Center();
            CalcRad();
            Area();
            Perimetr();
        }
        public void CalcRad()
        {
            this.radius = this.Points.First().DistanceBetween(this.Points.Last());
        }
        public override void Area()
        {
            this.area= Math.PI*Math.Pow(radius,2);
        }

        public override void Center()
        {
            this.Centre=this.Points.First();
        }

        public override void MoveFigure(double a, double b)
        {
            foreach(Point p in this.Points)
            {
                p.X += a;
                p.Y += b;
            }
        }

        public override void Perimetr()
        {
            this.perimetr = 2 * Math.PI * radius;
        }

        public override void Rotate(double RotationParam)
        {
        }

        public override void Scale(double ScaleParam)
        {
            this.Points.Last().X = ScaleParam * (this.Points.Last().X - Centre.X) + Centre.X;
            this.Points.Last().Y = ScaleParam * (this.Points.Last().Y - Centre.Y) + Centre.Y;
            CalcRad();
            Area();
            Perimetr();
        }
    }
}
