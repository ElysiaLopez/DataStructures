using System;
using System.Collections.Generic;
using System.Text;

namespace UnionFind
{
    class QuickUnion<T>
    {
        private int[] parents;
        private Dictionary<T, int> map;
        public QuickUnion(IEnumerable<T> items)
        {
            map = new Dictionary<T, int>();
            parents = new int[items.Count()];
            
            int i = 0;
            foreach (var item in items)
            {
                map.Add(item, i);

                i++;
            }
        }

        public int Find(T p)
        {
            var index = map[p];
            while(parents[index] != index)
            {
                index = parents[index];
            }
            return index;
        }

        public bool Union(T p, T q)
        {
            if (!map.ContainsKey(p) || !map.ContainsKey(q)) return false;
            parents[map[p]] = map[q];
            return true;
        }

        public bool AreConnected(T p, T q)
            => Find(p) == Find(q);
    }
}
