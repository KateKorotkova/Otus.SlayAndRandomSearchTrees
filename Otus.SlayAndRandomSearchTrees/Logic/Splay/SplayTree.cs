using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Otus.SlayAndRandomSearchTrees.Logic.Splay
{
    public class SplayTree : BaseTree<SplayNode>
    {
        public SplayNode GetNode(int value)
        {
            return GetNode(Root, value);
        }

        public SplayNode Insert(int value)
        {
            if (Root == null)
            {
                Root = new SplayNode(value);
                return Root;
            }

            return AddNode(Root, value);
        }


        #region Support methods

        public SplayNode GetNode(SplayNode currentNode, int value)
        {
            if (currentNode == null)
                return null;

            if (value == currentNode.Value)
            {
                LiftNodeToTheRoot(currentNode);
                return currentNode;
            }

            var nextNode = value < currentNode.Value
                ? currentNode.LeftChild
                : currentNode.RightChild;

            return GetNode(nextNode, value);
        }

        public void LiftNodeToTheRoot(SplayNode currentNode)
        {
            while (currentNode.Parent != null)
            { 
                if (currentNode.Parent != Root)
                {
                    var parent = currentNode.Parent;
                    var grandFather = parent.Parent;

                    if (parent.LeftChild == currentNode)
                    {
                        if (parent.Parent.LeftChild == parent)
                        {
                            DoSmallRightRotation(grandFather);
                            DoSmallRightRotation(parent);
                        }
                        else if (parent.Parent.RightChild == parent)
                        {
                            DoSmallRightRotation(parent);
                            DoSmallLeftRotation(grandFather);
                        }
                    }
                    else if (parent.RightChild == currentNode)
                    {
                        if (parent.Parent.RightChild == parent)
                        {
                            DoSmallLeftRotation(grandFather);
                            DoSmallLeftRotation(parent);
                        }
                        else if (parent.Parent.LeftChild == parent)
                        {
                            DoSmallLeftRotation(parent);
                            DoSmallRightRotation(grandFather);
                        }
                    }
                }
                else
                {
                    if (currentNode == currentNode.Parent.RightChild)
                    {
                        DoSmallLeftRotation(currentNode.Parent);
                    }
                    else
                    {
                        DoSmallRightRotation(currentNode.Parent);
                    }
                }
            }
        }

        #endregion
    }
}
