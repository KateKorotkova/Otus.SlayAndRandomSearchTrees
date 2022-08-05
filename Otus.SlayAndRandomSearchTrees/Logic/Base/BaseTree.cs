namespace Otus.SlayAndRandomSearchTrees.Logic.Base
{
    public abstract class BaseTree
    {
        public Node Root { get; protected set; }


        public virtual Node Insert(int value)
        {
            if (Root == null)
            {
                Root = new Node { Value = value};
                return Root;
            }

            return AddNode(Root, value);
        }

        #region Support Methods

        protected void ReplaceNodeInParent(Node nodeToRemove, Node node)
        {
            var parent = nodeToRemove.Parent;
            if (parent == null)
                return;

            if (parent.LeftChild == nodeToRemove)
            {
                parent.LeftChild = node;
            }
            else if (parent.RightChild == nodeToRemove)
            {
                parent.RightChild = node;
            }
        }

        protected Node AddNode(Node currentRoot, int value)
        {
            if (value < currentRoot.Value)
            {
                if (currentRoot.LeftChild == null)
                {
                    currentRoot.LeftChild = new Node
                    {
                        Value = value,
                        Parent =  currentRoot,
                        NodeSide = NodeSide.Left
                    };

                    return currentRoot.LeftChild;
                }

                return AddNode(currentRoot.LeftChild, value);
            }
            else
            {
                if (currentRoot.RightChild == null)
                {
                    currentRoot.RightChild = new Node
                    {
                        Value = value,
                        Parent = currentRoot,
                        NodeSide = NodeSide.Right
                    };

                    return currentRoot.RightChild;
                }

                return AddNode(currentRoot.RightChild, value);
            }
        }

        #endregion
    }
}
