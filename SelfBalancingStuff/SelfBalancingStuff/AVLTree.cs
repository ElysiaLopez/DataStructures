using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class AVLTree<T>
        where T : IComparable<T>
    {
        Node<T> Root { get; set; }
        public AVLTree()
        {
            Root = null;
        }

        public void Insert(T val)
        {
            var node = new Node<T>(val);
            if(Root == null)
            {
                Root = node;
                return;
            }
            var temp = Root;
            while(true)
            {
                if(val.CompareTo(temp.Value) < 0)
                {
                    if(temp.Left == null)
                    {
                        temp.Left = node;
                        return;
                    }
                    temp = temp.Left;
                }
                else
                {
                    if(temp.Right == null)
                    {
                        temp.Right = node;
                        return;
                    }
                    temp = temp.Right;
                }
            }

        }
    }
}
