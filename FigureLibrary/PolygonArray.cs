using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureLibrary
{
    public class PolygonArray
    {
        public Polygon[] polygons;
        public int Counter;
        public PolygonArray()
        {
            polygons = new Polygon[50];
            Counter = 0;
        }

        public void AddPolygon(string type, string color, params int[] coordinates)
        {
            if (string.Equals(type, "Rectangle"))
            {
                polygons[Counter] = new Rectangle(type, color, coordinates);
                Counter++;
            }
            else if (string.Equals(type, "Triangle"))
            {
                polygons[Counter] = new Triangle(type, color, coordinates);
                Counter++;
            }
        }

        public string[] ShowAllPolygones(out string[] colors)
        {
            string[] result = new string[Counter];
            colors = new string[Counter];
            for (int i = 0; i < Counter; i++)
            {
                result[i] = polygons[i].ToString();
                colors[i] = polygons[i].Color;
            }
            Console.Write(result + " ");
            return result;
        }

        public void SortPolygons()
        {
            Array.Sort(polygons, new PolygonComp());
        }

        public string[] FindRectangularTriangle2quater(out string[] colors)
        {
            Triangle[] neededTriangles = new Triangle[Counter];
            string[] result = new string[Counter];
            int resultCounter = 0;
            colors = new string[Counter];
            int triangleCounter = 0;
            for (int i = 0; i < Counter; i++)
            {
                if (polygons[i] is Triangle)
                {
                    neededTriangles[triangleCounter] = (Triangle)polygons[i];
                    triangleCounter++;
                }
            }
            for (int i = 0; i < triangleCounter; i++)
            {
                if (neededTriangles[i].Is2quater() && neededTriangles[i].IsRectangular())
                {
                    result[resultCounter] = neededTriangles[i].ToString();
                    colors[resultCounter] = neededTriangles[i].Color;
                }
            }
            return result;
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Counter; i++)
            {
                result += polygons[i].ToString();
            }
            return result;
        }
    }
}
