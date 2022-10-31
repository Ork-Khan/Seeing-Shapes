using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    internal class Program
    {
        static void ReadingFile(string Path,LinkedList<Fig> Figs)
        {
            using(StreamReader sr = new StreamReader(Path))
            {
                string line;
                line = sr.ReadLine();
                while(line != null)
                {
                    string[] str = line.Split(';');
                    line = str[1];
                    char[] c = { ' ', '(', ')' };
                    string[] str2 = line.Split(c, StringSplitOptions.RemoveEmptyEntries);
                    LinkedList<Point> ps = new LinkedList<Point>();
                    foreach (string s in str2)
                    {
                        char[] coma = { ',' };
                        string[] str3 = s.Split(coma, StringSplitOptions.RemoveEmptyEntries);
                        ps.AddLast(new Point(double.Parse(str3[0]), double.Parse(str3[1])));
                    }
                    int amount = ps.Count();
                    switch (amount)
                    {
                        case 4:
                            {
                                Rectangle rec = new Rectangle(ps);
                                Figs.AddLast(rec);
                                break;
                            }
                        case 3:
                            {
                                Triangle tri = new Triangle(ps);
                                Figs.AddLast(tri);
                                break;
                            }
                        case 2:
                            {
                                Circle circ = new Circle(ps);
                                Figs.AddLast(circ);
                                break;
                            }
                    }
                    line=sr.ReadLine();
                }
                
            }
        }
        static void Main(string[] args)
        {
            string Path = "C:\\Users\\user\\source\\repos\\Figures\\Figures\\FigureData.txt";
            LinkedList<Fig> Figures=new LinkedList<Fig>();
            int MenuInput;
            ReadingFile(Path,Figures);
            while (true)
            {
                Console.WriteLine("1) show all figures\r\n2) create a figure\r\n3) change figure:\r\n4)save to file\r\n0) exit\r\n");
                bool IsItInt=int.TryParse(Console.ReadLine(), out MenuInput);
                switch (MenuInput)
                {
                    case 1:
                        {
                            using (StreamReader sr=new StreamReader(Path))
                            {
                                string line=sr.ReadLine();
                                while (line != null)
                                {
                                    string[] str=line.Split(';');
                                    Console.WriteLine(str[0]);
                                    line=sr.ReadLine();
                                }
                            }
                            
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Please choose figure you want to create: 1)rectangle 2)circle 3)triangle");
                            int Menu1;
                            int.TryParse(Console.ReadLine(), out Menu1);
                            LinkedList<Point> Ps = new LinkedList<Point>();
                            double x, y;
                            switch (Menu1)
                            {
                                case 1:
                                    {
                                        for (int i = 0; i < 4; i++)
                                        {
                                            x = Convert.ToDouble(Console.ReadLine());
                                            y = Convert.ToDouble(Console.ReadLine());
                                            Point p = new Point(x, y);
                                            Ps.AddFirst(p);
                                        }
                                        Rectangle rec = new Rectangle(Ps);
                                        Figures.AddLast(rec);
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Please enter Center of Circle");
                                        for(int i=0; i < 2; i++)
                                        {
                                            x = Convert.ToDouble(Console.ReadLine());
                                            y = Convert.ToDouble(Console.ReadLine());
                                            Point p = new Point(x, y);
                                            Ps.AddLast(p);
                                        }
                                        Circle circ= new Circle(Ps);
                                        Figures.AddLast(circ);
                                        break;
                                    }
                                case 3:
                                    {
                                        for (int i = 0; i < 3; i++)
                                        {
                                            x = Convert.ToDouble(Console.ReadLine());
                                            y = Convert.ToDouble(Console.ReadLine());
                                            Point p = new Point(x, y);
                                            Ps.AddFirst(p);
                                        }
                                        Triangle tri=new Triangle(Ps);
                                        Figures.AddLast(tri);
                                        break;
                                    }
                            }
                            break;
                        }
                    case 3:
                        {
                            int FigNumber;
                            Console.WriteLine("enter number of figure");
                            int.TryParse(Console.ReadLine(), out FigNumber);
                            int Menu2;
                            Console.WriteLine("1) move 2) scale 3) rotate");
                            int.TryParse(Console.ReadLine(), out Menu2);
                            switch (Menu2)
                            {
                                case 1:
                                    {
                                        double a, b;
                                        a = double.Parse(Console.ReadLine());
                                        b = double.Parse(Console.ReadLine());
                                        Figures.ElementAt(FigNumber).MoveFigure(a, b);
                                        break;
                                    }
                                case 2:
                                    {
                                        double a;
                                        a= double.Parse(Console.ReadLine());
                                        Figures.ElementAt(FigNumber).Scale(a);
                                        break;
                                    }
                                case 3:
                                    {
                                        double rotation;
                                        rotation = double.Parse(Console.ReadLine());
                                        Figures.ElementAt(FigNumber).Rotate(rotation);
                                        break;
                                    }
                            }                            
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("saving...");
                            using(StreamWriter sw=new StreamWriter(Path))
                            {
                                int Index = 0;
                                foreach (Fig f in Figures)
                                {
                                    int AmountOfPoints = 0;
                                    sw.Write($"Fig[{Index}] ");
                                    Index++;
                                    foreach (Point p in f.Points)
                                    {
                                        AmountOfPoints++;
                                    }
                                    switch (AmountOfPoints)
                                    {
                                        case 2: sw.Write("Circle "); break;
                                        case 3: sw.Write("Triangle "); break;
                                        case 4: sw.Write("Rectangle "); break;
                                    }

                                    sw.Write($"Area={f.area} Perimeter={f.perimetr} ;");
                                    foreach(Point p in f.Points)
                                    {
                                        sw.Write($"({p.X},{p.Y}) ");
                                    }
                                    sw.WriteLine("");
                                }
                            }
                            break;
                        }
                    default:
                        {
                            if (IsItInt && MenuInput == 0)
                            {
                                Console.WriteLine("byee");
                                Environment.Exit(0);
                            } ///user wants to exit
                            if (IsItInt && MenuInput != 0 || !IsItInt)
                            {
                                Console.WriteLine("Please Enter a number from menu.");
                            } ///user entered wrong input
                            break;
                        }
                }
            }
        }
    }
}
