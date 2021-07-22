using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DS.DataStructures
{
    public class TreeNode<T>
    {
        public TreeNode(T val)
        {
            Val = val ?? throw new ArgumentNullException();
        }

        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public T Val { get; set; }
    }


    public class BST
    {
        public static void BreadthFirstTraverse<T>(TreeNode<T> root)
        {

        }

        public static void StackDepthFirstTraverse<T>(TreeNode<T> root)
        {
            var stack = new Stack<TreeNode<T>>();
            stack.Push(root);

            Console.Write("[");
            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (node.Right != null) stack.Push(node.Right);
                if (node.Left != null) stack.Push(node.Left);

                Console.Write($"{node.Val}, ");
            }

            Console.Write("]");
            Console.WriteLine();
        }

        public static void PreOrderTraverse<T>(TreeNode<T> root)
        {
            if (root == null)
                return;

            Console.Write($"{root.Val}, ");

            PreOrderTraverse(root.Left);
            PreOrderTraverse(root.Right);
        }

        public static void InOrderTraverse<T>(TreeNode<T> root)
        {
            if (root == null)
                return;


            InOrderTraverse(root.Left);
            Console.Write($"{root.Val}, ");
            InOrderTraverse(root.Right);
        }

        public static void PostOrderTraverse<T>(TreeNode<T> root)
        {
            if (root == null)
                return;

            PostOrderTraverse(root.Left);
            PostOrderTraverse(root.Right);
            Console.Write($"{root.Val}, ");
        }
    }


    public class BSTProgram
    {
        public static void RunBST()
        {
            var tree = new TreeNode<char>('A')
            {
                Left = new TreeNode<char>('B')
                {
                    Left = new TreeNode<char>('D'),
                    Right = new TreeNode<char>('E')
                },
                Right = new TreeNode<char>('C')
                {
                    Right = new TreeNode<char>('F')
                }
            };


            BST.BreadthFirstTraverse(tree);
            BST.StackDepthFirstTraverse(tree);
            
            BST.PreOrderTraverse(tree);
            Console.WriteLine();
            BST.InOrderTraverse(tree);
            Console.WriteLine();
            BST.PostOrderTraverse(tree);
        }
    }
}