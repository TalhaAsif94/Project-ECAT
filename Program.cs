#define DEBUG_NUMBERS

using System;


namespace Talha
{
    class Program
    {
        public static double PI = 3.141592653589793238;


        static void Main()
        {
#if DEBUG_NUMBERS
            Numbers obj = new Numbers("15", Base.Decimal), obj1 = new Numbers("2", Base.Decimal), obj2 = new Numbers("0.5", Base.Decimal);
            Console.WriteLine("Welcome To Debug Numbers Class\n");
            obj.Negate();
            Console.WriteLine("Negate: {0}", obj.Getnumber());
            obj.Negate();
            Console.WriteLine("Percentage: {0}", Numbers.Percentage(obj).Getnumber());
            Console.WriteLine("Factorial: {0}", Numbers.Factorial(obj).Getnumber());
            Console.WriteLine("Power: {0}", Numbers.Power(obj, obj1).Getnumber());
            Console.WriteLine("Square Root: {0}", Numbers.Power(obj, obj2).Getnumber());
            Console.WriteLine("Exponential: {0}", Numbers.Exponential(obj1).Getnumber());
            Console.WriteLine("Logarithm: {0}", Numbers.Logarithm(obj, obj1).Getnumber());
            Console.WriteLine("Natural Logarithm: {0}", Numbers.NaturalLogarithm(obj).Getnumber());
            obj.Setnumber((Program.PI / 2).ToString(), Base.Decimal);
            Console.WriteLine("Sine: {0}", Numbers.Sine(obj).Getnumber());
            Console.WriteLine("Hyperbolic Sine: {0}", Numbers.Sineh(obj).Getnumber());
            Console.WriteLine("Cosine: {0}", Numbers.Cosine(obj).Getnumber());
            Console.WriteLine("Hyperbolic Cosine: {0}", Numbers.Cosineh(obj).Getnumber());
            Console.WriteLine("Tangent: {0}", Numbers.Tangent(obj).Getnumber());
            Console.WriteLine("Hyperbolic Tangent: {0}", Numbers.Tangenth(obj).Getnumber());
            Console.WriteLine("Arc Sine: {0}", Numbers.ArcSine(obj2).Getnumber());
            Console.WriteLine("Hyperbolic Arc Sine: {0}", Numbers.ArcSineh(obj2).Getnumber());
            Console.WriteLine("Arc Cosine: {0}", Numbers.ArcCosine(obj2).Getnumber());
            Console.WriteLine("Hyperbolic Arc Cosine: {0}", Numbers.ArcCosineh(obj2).Getnumber());
            Console.WriteLine("Arc Tangent: {0}", Numbers.ArcTangent(obj2).Getnumber());
            Console.WriteLine("Hyperbolic Arc Tangent: {0}", Numbers.ArcTangenth(obj2).Getnumber());
#endif
        }
    }
}
