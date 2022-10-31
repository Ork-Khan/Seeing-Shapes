using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : Fig
    {
        public override LinkedList<Point> Points { get; set; }
        public LinkedList<double> Sides;
        public override double area { get; set; }
        public override double perimetr { get; set; }
        public Point Centre;
        public Triangle(LinkedList<Point> points)
        {
            this.Points = points;
            Center();
            CalcSides();
            Perimetr();
            Area();
        }

        public void CalcSides()
        {
            this.Sides = new LinkedList<double>();
            Point savethis = this.Points.First();
            double distance;
            foreach (Point p in Points)
            {
                if (savethis.X != p.X || savethis.Y != p.Y)
                {
                    distance = p.DistanceBetween(savethis);
                    Sides.AddFirst(distance);
                    savethis = p;
                }
            }
            distance = savethis.DistanceBetween(this.Points.First());
            Sides.AddLast(distance);
        }
        public override void Perimetr()
        {
            perimetr = 0;
            foreach(double s in Sides)
            {
                this.perimetr += s;
            }
        }
        public override void Area()
        {
            double SemiPerimetr=perimetr/2;
            double zad=SemiPerimetr;
            foreach(double s in Sides)
            {
                zad *= SemiPerimetr - s;
            }
            this.area = Math.Sqrt(zad);
        }

        public override void Center()
        {
            double XCor = 0, YCor = 0;
            foreach (Point p in Points)
            {
                XCor += p.X;
                YCor += p.Y;
            }
            this.Centre = new Point(XCor / 3, YCor / 3);
        }

        public override void MoveFigure(double a, double b)
        {
            foreach (var p in Points)
            {
                p.X += a;
                p.Y += b;
            }
            Centre.X += a;
            Centre.Y += b;
        }
        public override void Rotate(double RotationParam)
        {
            foreach (Point P in Points)
            {
                double oldX = P.X;
                P.X = Centre.X + Math.Cos(RotationParam) * (P.X - Centre.X) - Math.Sin(RotationParam) * (P.Y - Centre.Y);
                P.Y = Centre.Y + Math.Sin(RotationParam) * (oldX - Centre.X) + Math.Cos(RotationParam) * (P.Y - Centre.Y);
            }
        }

        public override void Scale(double ScaleParam)
        {
            foreach (Point p in Points)
            {
                p.X = ScaleParam * (p.X - Centre.X) + Centre.X;
                p.Y = ScaleParam * (p.Y - Centre.Y) + Centre.Y;
            }
            CalcSides();
            Perimetr();
            Area();
        }
    }
}
