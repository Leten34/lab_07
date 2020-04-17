using System;
namespace lab07_06
{
    class Program
    {
        static void Main(string[] args)
        {
            ArithmeticProgression arProg = new ArithmeticProgression(3, 12);
            GeometricProgression geoProg = new GeometricProgression(2, 3);
            Console.Write("Enter number of element: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Element in arithmetic progression is {0}\nElement in geometric progression is {1}", arProg.GetElement(n), geoProg.GetElement(n));
        }
    }
    interface IProgression
    {
        double GetElement(int k);
    }

    abstract class Progression
    {
        public abstract double GetElement(int k);
    }
    class ArithmeticProgression : IProgression
    {
        public int a1 { get; private set; }
        public int d { get; private set; }

        public ArithmeticProgression(int a1, int d)
        {
            this.a1 = a1;
            this.d = d;
        }

        public double GetElement(int k)
        {
            double element = this.a1 + this.d * (k - 1);
            return element;
        }
    }
    class GeometricProgression : IProgression
    {
        public int b1 { get; private set; }
        public int q { get; private set; }

        public GeometricProgression(int b1, int q)
        {
            this.b1 = b1;
            this.q = q;
        }

        public double GetElement(int k)
        {
            double element = this.b1 * Math.Pow(this.q, k - 1);
            return element;
        }
    }

}
