using System.Collections.Generic;

namespace general
{
    public class DotData
    {
        public List<double> matrix = new();
        public List<int> shape = new();
        public int ndim;
        public List<int> stride = new();
        public int numel;
        public string device = "cpu";
    }

    public static class Customize
    {
        public static List<int> compute_stride(List<int> shape)
        {
            int n = shape.Count;
            int[] stride = new int[n];
            int running = 1;

            for(int d = n-1; d >=0; d--)
            {
                stride[d] = running;
                running = running * shape[d];
            }
            return stride.ToList();
        }

        public static int compute_ndim(List<int> shape)
        {
            return shape.Count;
        }

        public static DotData reshape(DotData data, int[] nshape)
        {
            int nnumel = nshape.Aggregate(1, (acc, x) => acc * x);
            if (nnumel != data.numel)
            {
                throw new Exception("Given Shape is Not Valid");
            } else
            {
                data.shape = nshape.ToList();
                data.ndim = nshape.Length;
                data.stride = compute_stride(data.shape);
                return data;
            }
        }
    }
}