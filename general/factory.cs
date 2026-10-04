
using general;
using System;

namespace factory
{
    public static class Fact
    {

        public static DotData GenZeros(List<int> shape)
        {
            int numel = 1;
            foreach(int dim in shape)
            {
                numel *= dim;
            }

            List<double> matrix = new List<double>(new double[numel]);

            DotData data = new DotData();
            data.matrix = matrix;
            data.numel = numel;
            data.ndim = shape.Count;
            data.shape = shape;
            data.device = "cpu";
            data.stride = Customize.compute_stride(shape);
            return data;
        }

        public static DotData GenOnes(List<int> shape)
        {
            int numel = 1;
            foreach(int dim in shape)
            {
                numel *= dim;
            }

            List<double> matrix = new List<double>(new double[numel]);
            for(int i=0; i<numel; i++)
            {
                matrix[i] = 1.0;
            }

            DotData data = new DotData();
            data.matrix = matrix;
            data.numel = numel;
            data.ndim = shape.Count;
            data.shape = shape;
            data.device = "cpu";
            data.stride = Customize.compute_stride(shape);
            return data;
        }

        public static DotData GenRange(double start, double stop, double step)
        {
            double current = start;
            List<double> matrix = new List<double> {};

            if(step > 0.0)
            {
                while (current < stop)
                {
                    matrix.Add(current);
                    current = current + step;
                }
            }
            else if(step < 0.0)
            {
                while(current > stop)
                {
                    matrix.Append(current);
                    current = current + step;
                }
            }
            else
            {
                throw new Exception("step can not be equal to 0.0");
            }

            DotData data = new DotData();
            data.matrix = matrix;
            data.numel = matrix.Count;
            data.ndim = 1;
            data.shape = new List<int> {matrix.Count};
            data.device = "cpu";
            data.stride = Customize.compute_stride(data.shape);
            return data;
        }

        public static DotData LinSpace(double start=0.0, double stop=1.0, int num=10)
        {
            double step = (stop - 0) / (num -1);
            List<double> array = new List<double> {};

            for(float i=0; i<num; i++)
            {
                array.Add((0+i) * step);
            }
            
            DotData D = new DotData();
            D.matrix = array;
            D.shape = new List<int> {array.Count};
            D.ndim = D.shape.Count;
            D.numel = array.Count;
            D.stride = Customize.compute_stride(D.shape);
            D.device = "cpu";
            return D;
        }
    }
}