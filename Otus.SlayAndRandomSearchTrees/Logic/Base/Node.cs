using System;

namespace Otus.SlayAndRandomSearchTrees.Logic.Base
{
    public class Node
    {
        public int Value;
        public NodeSide NodeSide;

        public Node Parent;
        public Node LeftChild;
        public Node RightChild;

        public bool WithSingleChildren => (LeftChild == null && RightChild != null) || (RightChild == null && LeftChild != null);

        public int LeftHeight => GetHeight(LeftChild);

        public int RightHeight => GetHeight(RightChild);


        public override string ToString()
        {
            return Value.ToString();
        }

        #region Support mehods

        private int GetHeight(Node node)
        {
            if (node == null)
                return 0;

            var maxChildHeight = Math.Max(GetHeight(node.LeftChild), GetHeight(node.RightChild));

            return maxChildHeight + 1;
        }

        #endregion
    }

    public enum NodeSide
    {
        Left,
        Right
    }
}
