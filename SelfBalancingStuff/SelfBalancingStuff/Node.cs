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
                int leftHeight = Left != null ? Left.Height : 1;
                int rightHeight = Right != null ? Right.Height : 1;
                int maxHeight = leftHeight > rightHeight ? leftHeight : rightHeight;
                return maxHeight + 1;
            }
        }
        public Node(T val)
        {
            Value = val;
        }
    }
}
