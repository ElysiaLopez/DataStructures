using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace HashMap
{
    class Hashmap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        LinkedList<KeyValuePair<TKey, TValue>>[] Items;
        public IEqualityComparer<TKey> Comparer;
        public int Capacity;
        public Hashmap(int size, IEqualityComparer<TKey> comparer)
        {
            Comparer = comparer;
            Capacity = size;
            Items = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];
        }
        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public ICollection<TKey> Keys => throw new NotImplementedException();

        public ICollection<TValue> Values => throw new NotImplementedException();

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        

        public void Add(TKey key, TValue value)
        {
            int index = key.GetHashCode() % Capacity;
            if(Items[index] == null)
            {
                Items[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }
            var containsKey = false;
            foreach(var kvp in Items[index])
            {
                if(Comparer.Equals(kvp.Key, key))
                {
                    containsKey = true;
                }
            }
            if(!containsKey) Items[index].AddLast(new LinkedListNode<KeyValuePair<TKey, TValue>>(new KeyValuePair<TKey, TValue>(key, value)));
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            Items = new LinkedList<KeyValuePair<TKey, TValue>>[Capacity];
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool ContainsKey(TKey key)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(TKey key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
