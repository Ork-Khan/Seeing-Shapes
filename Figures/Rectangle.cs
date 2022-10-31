using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Rectangle : Fig
    {
        public override LinkedList<Point> Points { get; set; }
        public LinkedList<double> Sides;
        public override double area { get; set; }
        public override double perimetr { get; set; }
        public Point Centre;
        public Rectangle(LinkedList<Point> points)
        {
            this.Points = points;
            CalcSides();
            Perimetr();
            Center();
            Area();
        }
        public void CalcSides()
        {
            this.Sides=new LinkedList<double>();
            Point savethis = this.Points.First();
            double distance;
            foreach (Point p in Points)
            {
                if (savethis.X!=p.X || savethis.Y!=p.Y)
                {
                    distance = p.DistanceBetween(savethis);
                    Sides.AddFirst(distance);
                    savethis = p;
                }
            }
            distance = savethis.DistanceBetween(this.Points.First());
            Sides.AddLast(distance);
        }
        public override void Area()
        {
            this.area=Sides.First()*Sides.Last();
        }
        public override void Perimetr()
        {
            perimetr=0;
            foreach (double s in Sides)
            {
                perimetr += s;
            }
        }
        public override void Center()
        {
            double XCor=0,YCor=0;
            foreach(var p in Points)
            {
                XCor += p.X;
                YCor += p.Y;
            }
            this.Centre= new Point(XCor/4,YCor/4);
        }
        public override void MoveFigure(double a, double b)
        {
            foreach(var p in Points)
            {
                p.X += a;
                p.Y += b;
            }
            Centre.X += a;
            Centre.Y += b;
        }

        public override void Scale(double ScaleParam)
        {
            foreach(Point p in Points)
            {
                p.X=ScaleParam*(p.X-Centre.X)+Centre.X;
                p.Y=ScaleParam*(p.Y-Centre.Y)+Centre.Y;
            }
            CalcSides();
            Area();
            Perimetr();
        }

        public override void Rotate(double RotationParam)
        {
            foreach(Point P in Points)
            {
                double oldX = P.X; 
                P.X=Centre.X+Math.Cos(RotationParam)*(P.X-Centre.X)-Math.Sin(RotationParam)*(P.Y-Centre.Y);
                P.Y=Centre.Y+Math.Sin(RotationParam)*(oldX-Centre.X)+Math.Cos(RotationParam)*(P.Y-Centre.Y);
            }
        }
    }
}
