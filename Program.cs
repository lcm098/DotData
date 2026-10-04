using System;
using factory;
using general;
using PrintMatrix;

namespace Simple
{
    class Program
    {
        public static void Main(string[] args)
        {
            // DotData d = Fact.GenRange(0, 6, 1);
            // DotData d1 = Customize.reshape(d, [1, 2, 3]);
            // printMat.P(d1);

            // DotData d2 = Fact.LinSpace(1, 5, 32);
            // printMat.P(d2);

            // d2 = Customize.reshape(d2, [2, 2, 2, 4]);
            // printMat.P(d2);

            DotData d3 = Fact.GenOnes(new List<int> { 2, 3, 4 });
            printMat.P(d3);

            DotData d4 = Fact.GenZeros(new List<int> { 2, 3, 4 });
            printMat.P(d4);
        }
    }
}