using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Otus.SlayAndRandomSearchTrees.Logic
{
    public class SplayTree : BaseTree
    {
        public Node GetNode(int value)
        {
            return GetNode(Root, value);
        }
        

        #region Support methods

        public Node GetNode(Node currentNode, int value)
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

        public void LiftNodeToTheRoot(Node currentNode)
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

        private void DoSmallLeftRotation(Node rootToRotate)
        {
            var rightChildOfRotatedRoot = rootToRotate.RightChild;
            rootToRotate.RightChild = rightChildOfRotatedRoot.LeftChild;

            if (rightChildOfRotatedRoot.LeftChild != null)
            {
                rightChildOfRotatedRoot.LeftChild.Parent = rootToRotate;
            }

            rightChildOfRotatedRoot.Parent = rootToRotate.Parent;
            if (rootToRotate.Parent == null)
            {
                Root = rightChildOfRotatedRoot;
            }
            else
            {
                ReplaceNodeInParent(rootToRotate, rightChildOfRotatedRoot);
            }

            rightChildOfRotatedRoot.LeftChild = rootToRotate;
            rootToRotate.Parent = rightChildOfRotatedRoot;
        }

        private void DoSmallRightRotation(Node rootToRotate)
        {
            var leftChildOfRotatedRoot = rootToRotate.LeftChild;
            rootToRotate.LeftChild = leftChildOfRotatedRoot.RightChild;

            if (leftChildOfRotatedRoot.RightChild != null)
            {
                leftChildOfRotatedRoot.RightChild.Parent = rootToRotate;
            }

            leftChildOfRotatedRoot.Parent = rootToRotate.Parent;
            if (rootToRotate.Parent == null)
            {
                Root = leftChildOfRotatedRoot;
            }
            else
            {
                ReplaceNodeInParent(rootToRotate, leftChildOfRotatedRoot);
            }

            leftChildOfRotatedRoot.RightChild = rootToRotate;
            rootToRotate.Parent = leftChildOfRotatedRoot;
        }

        #endregion
    }
}
