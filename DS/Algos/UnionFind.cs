using System;

namespace DS.Algos
{
    public class UnionFind
    {
        private readonly int[] _elements;
        private readonly int[] _sz;

        public UnionFind(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("n should be greater than zero");
            }

            _elements = new int[n];
            _sz = new int[n];

            for (int i = 0; i < n; i++)
            {
                _elements[i] = i;
            }

            for (int i = 0; i < n; i++)
            {
                _sz[i] = 0;
            }
        }
    }
}