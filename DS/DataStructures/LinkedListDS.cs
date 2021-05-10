using System;
using System.Text;

namespace DS.DataStructures
{
    public class Node<T>
    {
        public Node(T val)
        {
            Val = val;
            Next = null;
        }

        public T Val { get; set; }
        public Node<T> Next { get; set; }
    }

    public class LinkedListDS<T>
    {
        private Node<T> _head;
        
        public LinkedListDS()
        {
            _head = null;
        }

        public void Append(T val)
        {
            var node = new Node<T>(val);

            if (_head == null)
            {
                _head = node;
                return;
            }

            var current = _head;
            while (current.Next != null)
            {
                current = current.Next;
            }

            current.Next = node;
        }

        public bool Contains(T val)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Val.Equals(val))
                    return true;

                current = current.Next;
            }

            return false;
        }

        public void Delete(T val)
        {
            if (_head == null)
                return;
            
            if (_head.Val.Equals(val))
            {
                _head = _head.Next;
                return;
            }
            
            var current = _head.Next;
            Node<T> prev = _head;
            while (current != null)
            {
                if (current.Val.Equals(val))
                {
                    prev.Next = current.Next;
                    return;
                }

                prev = current;
                current = current.Next;
            }
        }

        public void Reverse()
        {
            Node<T> prev = null;
            var current = _head;

            while (current != null)
            {
                var next = current.Next;
                
                current.Next = prev;
                prev = current;
                current = next;
            }

            _head = prev;
        }

        public void Print()
        {
            var sb = new StringBuilder(string.Empty);
            var current = _head;

            while (current != null)
            {
                sb.Append($"{current.Val} -> ");
                current = current.Next;
            }

            Console.WriteLine(sb);
        }

        #region Recursive Part

        public void AppendRecursively(T val)
        {
            if (_head == null)
            {
                _head = new Node<T>(val);
                return;
            }

            DoAppendRecursively(val, _head);
        }

        void DoAppendRecursively(T val, Node<T> node)
        {
            if (node.Next == null)
            {
                node.Next = new Node<T>(val);
                return;
            }

            DoAppendRecursively(val, node.Next);
        }

        public bool ContainsRecursively(T val)
        {
            return DoContainRecursively(val, _head);
        }

        bool DoContainRecursively(T val, Node<T> node)
        {
            if (node == null)
                return false;

            return node.Val.Equals(val) || DoContainRecursively(val, node.Next);
        }

        public void ReverseRecursively()
        {
            _head = DoReverseRecursively(_head);
        }
        
        Node<T> DoReverseRecursively(Node<T> current, Node<T> prev = null)
        {
            if (current == null)
            {
                return prev;
            }

            var next = current.Next;
            current.Next = prev;
            return DoReverseRecursively(next, current);
        }

        public void PrintRecursively()
        {
            var sb = new StringBuilder();

            DoPrintRecursively(_head, sb);

            Console.WriteLine(sb);
        }

        void DoPrintRecursively(Node<T> node, StringBuilder sb)
        {
            if (node == null)
                return;

            sb.Append($"{node.Val} -> ");
            DoPrintRecursively(node.Next, sb);
        }

        #endregion
    }

    public static class LinkedListProgram
    {
        public static void Run()
        {
            var ll = new LinkedListDS<int>();
            ll.Append(2);
            ll.Append(3);
            ll.Append(4);
            ll.AppendRecursively(5);
            
            // ll.Delete(2);
            // ll.Delete(4);
            // ll.Delete(5);
            
            ll.Reverse();
            ll.Print();
            
            ll.ReverseRecursively();
            ll.PrintRecursively();
            
            // ll.PrintRecursively();
            // Console.WriteLine(ll.Contains(3).ToString());
            // Console.WriteLine(ll.Contains(20).ToString());
            //
            // Console.WriteLine(ll.ContainsRecursively(2).ToString());
            // Console.WriteLine(ll.ContainsRecursively(20).ToString());
        }
    }
}