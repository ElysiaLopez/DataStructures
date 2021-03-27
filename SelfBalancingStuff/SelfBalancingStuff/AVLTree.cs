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
            if(Root == null)
            {
                Root = new Node<T>(val);
                return;
            }
            Root = RecursiveInsert(Root, val);
        }

        private Node<T> RecursiveInsert(Node<T> node, T val)
        {
            if (node == null)
            {
                return new Node<T>(val);
            }
            if(val.CompareTo(node.Value) < 0)
            {
                node.Left = RecursiveInsert(node.Left, val);
            }
            else
            {
                node.Right = RecursiveInsert(node.Right, val);
            }
            return Balance(node);
        }

        private Node<T> Balance(Node<T> node)
        {
            if(node.Balance < -1)
            {
                if(node.Left.Balance > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }
                node = RotateRight(node);
            }
            else if(node.Balance > 1)
            {
                if(node.Right.Balance < 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                node = RotateLeft(node);
            }
            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            var pivot = node.Right;
            var tempLeft = pivot.Left;
            pivot.Left= node;
            node.Right = tempLeft;
            return pivot;
        }

        private Node<T> RotateRight(Node<T> node)
        {
            var pivot = node.Left;
            var tempRight = pivot.Right;
            pivot.Right = node;
            node.Left = tempRight;
            return pivot;

        }

        //delete :)
        public void Delete(T val)
        {
            if (Root == null) throw new Exception("Tree is empty");
            Root = RecursiveDelete(Root, val);
        }
        private Node<T> RecursiveDelete(Node<T> node, T val)
        {
            if(node.Value.CompareTo(val) == 0)
            {
                return null;
            }
            if(val.CompareTo(node.Value) < 0)
            {
                if(node.Left != null)
                {
                    return RecursiveDelete(node.Left, val);
                }
            }
            else
            {
                if(node.Right != null)
                {
                    return RecursiveDelete(node.Right, val);
                }
            }
        }
    }
}
