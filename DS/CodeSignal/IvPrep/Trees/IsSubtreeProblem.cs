using System.Collections.Generic;
using System.Text;

namespace DS.CodeSignal.IvPrep.Trees
{
    public class IsSubtreeProblem
    {
        public static bool IsSubtree(Tree<int> t1, Tree<int> t2)
        {
            if (t2 == null) return true;
            if (t1 == null) return false;

            if (CompareTrees(t1, t2)) return true;

            return IsSubtree(t1.left, t2) || IsSubtree(t1.right, t2);
        }


        static bool CompareTrees(Tree<int> t1, Tree<int> t2)
        {
            if (t1 == null || t2 == null) return t1 == t2;
            if (t1.value != t2.value) return false;

            return CompareTrees(t1.left, t2.left) && CompareTrees(t1.right, t2.right);
        }
    }
}