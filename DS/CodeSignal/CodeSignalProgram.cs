using System;
using DS.CodeSignal.IvPrep.Trees;

namespace DS.CodeSignal
{
    public class CodeSignalProgram
    {
        public static void Run()
        {
            var t1 = new Tree<int>
            {
                left = new Tree<int>()
                {
                    value = 5,
                    left = new Tree<int>()
                    {
                        value = 10,
                        left = new Tree<int>()
                        {
                            value = 4,
                            left = new Tree<int>()
                            {
                                value = 1
                            },
                            right = new Tree<int>()
                            {
                                value = 2
                            }
                        },
                        right = new Tree<int>()
                        {
                            value = 6,
                            right = new Tree<int>()
                            {
                                value = -1
                            }
                        }
                    },
                    right = new Tree<int>()
                    {
                        value = 7
                    }
                }
            };

            var t2 = new Tree<int>()
            {
                value = 10,
                left = new Tree<int>()
                {
                    value = 4,
                    left = new Tree<int>()
                    {
                        value = 1
                    },
                    right = new Tree<int>()
                    {
                        value = 2
                    }
                },
                right = new Tree<int>()
                {
                    value = 6,
                    right = new Tree<int>()
                    {
                        value = -1
                    }
                }
            };
            
            Console.WriteLine(IsSubtreeProblem.IsSubtree(t1, t2));
        }
    }
}