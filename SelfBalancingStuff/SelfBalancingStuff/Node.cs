using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfBalancingStuff
{
    class Node<T>
        where T : IComparable<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }
        public int Balance
        {
            get
            {
                int leftHeight = 0;
                int rightHeight = 0;
                if (Left != null) leftHeight = Left.Height;
                if (Right != null) rightHeight = Right.Height;
                return rightHeight - leftHeight;
            }
        }
        public int Height
        {
            get
            {
                if (Left == null && Right == null) return 1;
                int maxHeight = Left.Height.CompareTo(Right.Height) >= 0 ? Left.Height : Right.Height;
                return maxHeight;
            }
        }
        public Node(T val)
        {
            Value = val;
        }
    }
}
