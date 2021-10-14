using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clases
{
    public class Triangulo
    {
        private double perimetro, area;
        public double CalcularPerimetro(double lado1, double lado2, double lado3)
        {
            perimetro = lado1 + lado2 + lado3;
            return perimetro;
        }

        public double CalcularArea(double b, double h)
        {
            area = b * h / 2;
            return area;
        }
    }
}