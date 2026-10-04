using System;
using System.Collections.Generic;
using general;

namespace PrintMatrix
{
    public static class printMat
    {
        static void print(List<double> m, List<int> shape, string indent, int offset = 0, int track = 0)
        {
            if (offset == shape.Count - 1)
            {
                // at last dimension: print only this row's elements
                Console.Write($"{indent}[");
                for (int i = track; i < track + shape[offset]; i++)
                {
                    Console.Write($"{m[i]} ");
                }
                Console.WriteLine("]");
                return;
            }
            else
            {
                // number of elements in one sub-block of the next dimension
                int stride = 1;
                for (int d = offset + 1; d < shape.Count; d++)
                    stride *= shape[d];

                Console.WriteLine($"{indent}[");
                for (int i = 0; i < shape[offset]; i++)
                {
                    print(m, shape, indent + " ", offset + 1, track + i * stride);
                }
                Console.WriteLine($"{indent}]");
            }
        }

        public static void P(DotData M)
        {
            Console.WriteLine("=========================================");
            print(M.matrix, M.shape, "");
            Console.WriteLine($"device = {M.device}");
            Console.WriteLine($"ndim = {M.ndim}");
            Console.WriteLine($"numel = {M.numel}");
            Console.Write("shape = ");
            M.shape.ForEach(x => Console.Write($" {x}"));
            Console.WriteLine("");
            Console.Write("stride = ");
            M.stride.ForEach(x => Console.Write($" {x}"));
            Console.WriteLine("");
            Console.WriteLine("=========================================");
        }
    }
}