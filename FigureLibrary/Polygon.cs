using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FigureLibrary
{
    public abstract class Polygon
    {
        public string Type;
        public int[] CoordinatesArray;
        public string Color { get; protected set; }

        public abstract double GetSquare();

        public abstract double GetPerimeter();

        public string GetType()
        {
            return this.Type;
        }

        public override string ToString()
        {
            return GetType() +  " of the perimeter " + GetPerimeter() + " and the square " + GetSquare();
        }
    }

    public class Rectangle : Polygon
    {
        public Rectangle(string type, string color, int[] coordinates)
        {
            this.Type = type;
            this.Color = color;
            this.CoordinatesArray = coordinates;
        }
        public override double GetPerimeter()
        {
            int length = CoordinatesArray[2] - CoordinatesArray[0];
            int width = CoordinatesArray[3] - CoordinatesArray[1];
            int perimeter = 2 * (length + width);
            return perimeter;
        }

        public override double GetSquare()
        {
            int length = CoordinatesArray[2] - CoordinatesArray[0];
            int width = CoordinatesArray[3] - CoordinatesArray[1];

            int square = length * width;
            square = Math.Abs(square);
            return square;
        }
    }

    public class Triangle : Polygon
    {
        public Triangle(string type, string color, int[] coordinates)
        {
            this.Type = type;
            this.Color = color;
            this.CoordinatesArray = coordinates;
        }
        public override double GetPerimeter()
        {
            double sideA = GetSideLength(CoordinatesArray[0], CoordinatesArray[1], CoordinatesArray[2], CoordinatesArray[3]);
            double sideB = GetSideLength(CoordinatesArray[2], CoordinatesArray[3], CoordinatesArray[4], CoordinatesArray[5]);
            double sideC = GetSideLength(CoordinatesArray[4], CoordinatesArray[5], CoordinatesArray[0], CoordinatesArray[1]);
            double perimeter = sideA + sideB + sideC;
            return perimeter;
        }

        public double GetSideLength(int x1, int y1, int x2, int y2)
        {

            double side1 = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            double a = Math.Sqrt(side1);
            return a;
        }

        public override double GetSquare()
        {
            double square;

            square = 0.5 * ((CoordinatesArray[0] - CoordinatesArray[4]) * (CoordinatesArray[3] - CoordinatesArray[5]) -
                     (CoordinatesArray[3] - CoordinatesArray[4]) * (CoordinatesArray[1] - CoordinatesArray[5]));
            square = Math.Abs(square);

            return square;
        }

        public bool Is2quater()
        {
            bool is2quater = false;
            if (CoordinatesArray[0] < 0 && CoordinatesArray[1] > 0 && CoordinatesArray[2] < 0 && CoordinatesArray[3] > 0 &&
                    CoordinatesArray[4] < 0 && CoordinatesArray[5] > 0)
            {
                is2quater = true;
            }
            return is2quater;
        }

        public bool IsRectangular()
        {
            double sideA = GetSideLength(CoordinatesArray[0], CoordinatesArray[1], CoordinatesArray[2], CoordinatesArray[3]);
            double sideB = GetSideLength(CoordinatesArray[2], CoordinatesArray[3], CoordinatesArray[4], CoordinatesArray[5]);
            double sideC = GetSideLength(CoordinatesArray[4], CoordinatesArray[5], CoordinatesArray[0], CoordinatesArray[1]);
            if (Pyf(sideA, sideB, sideC) || Pyf(sideC, sideA, sideB) || Pyf(sideB, sideC, sideA))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Pyf(double a, double b, double c)
        {
            bool isPyf = false;
            if (a*a + b*b == c*c)
            {
                isPyf = true;
            }
            return isPyf;
        }
    }

    public class PolygonComp : IComparer<Polygon>
    {

        int IComparer<Polygon>.Compare(Polygon x, Polygon y)
        {
            return (Int32)x.GetSquare() - (Int32)y.GetSquare();
        }
    }

}
