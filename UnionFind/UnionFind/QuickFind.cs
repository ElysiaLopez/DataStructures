using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnionFind
{
    class QuickFind<T>
    {
        private int[] sets;
        private Dictionary<T, int> map; 

        public QuickFind(IEnumerable<T> items)
        {
            map = new Dictionary<T, int>();
            sets = new int[items.Count()];

            int i = 0;
            foreach(var item in items)
            {
                map.Add(item, i);
                sets[i] = i;
                i++;
            }

            
        }
        public int Find(T p) => sets[map[p]];

        public bool Union(T p, T q)
        {
            #region
            //int pIndex= map[p];
            //int qIndex = map[q]
            //foreach(var item in map)
            //{
            //    if(item.Value == oldSetIndex)
            //    {
            //        item.Value = 
            //    }
            //}
            #endregion

            if (!map.ContainsKey(p) || !map.ContainsKey(q)) return false;
            if (AreConnected(p, q)) return false;
            int oldSet = Find(p);
            int newSet = Find(q);

            for(int i = 0; i < sets.Length; i++)
            {
                if(sets[i] == oldSet)
                {
                    sets[i] = newSet;
                }
            }
            return true;
        }

        public bool AreConnected(T p, T q)
            => Find(p) == Find(q);
    }
}
