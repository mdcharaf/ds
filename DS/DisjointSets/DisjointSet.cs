using System;

namespace DS.DisjointSets
{
    public class DisjointSet
    {
        private readonly int[] _roots;
        private readonly int[] _sizes;

        public DisjointSet(int[] roots, int componentsCount)
        {
            _roots = roots ?? throw new ArgumentNullException();
            _sizes = new int[roots.Length];
            
            Array.Fill(_sizes, 1);
            for (int i = 0; i < _roots.Length; i++)
            {
                _roots[i] = i;
            }

            ComponentsCount = componentsCount;
        }
        
        public int ComponentsCount { get; private set; }
        
        public bool Unify(int p, int q)
        {
            var root1 = Find(p);
            var root2 = Find(q);

            if (root1 == root2) 
                return false;

            if (_sizes[root1] < _sizes[root2])
            {
                _roots[root1] = root2;
                _sizes[root2] += _sizes[root1];
                _sizes[root1] = 0;
            }
            else
            {
                _roots[root2] = root1;
                _sizes[root1] += _sizes[root2];
                _sizes[root2] = 0;
            }

            ComponentsCount--;
            return true;
        }

        private int Find(int p)
        {
            var root = p;
            while (root != _roots[root])
            {
                root = _roots[root];
            }

            // Path Compression
            while (p != root)
            {
                int next = _roots[p];
                _roots[p] = root;
                p = next;
            }

            return root;
        }
    }
}