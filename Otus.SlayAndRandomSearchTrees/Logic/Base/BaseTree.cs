namespace Otus.SlayAndRandomSearchTrees.Logic.Base
{
    public abstract class BaseTree<T> where T : BaseNode<T>, new()
    {
        public T Root { get; protected set; }


        #region Support Methods

        protected T AddNode(T currentRoot, int value)
        {
            if (value < currentRoot.Value)
            {
                if (currentRoot.LeftChild == null)
                {
                    currentRoot.LeftChild = new T
                    {
                        Value = value,
                        Parent =  currentRoot
                    };

                    return currentRoot.LeftChild;
                }

                return AddNode(currentRoot.LeftChild, value);
            }
            else
            {
                if (currentRoot.RightChild == null)
                {
                    currentRoot.RightChild = new T
                    {
                        Value = value,
                        Parent = currentRoot
                    };

                    return currentRoot.RightChild;
                }

                return AddNode(currentRoot.RightChild, value);
            }
        }

        protected T DoSmallLeftRotation(T rootToRotate)
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

            AfterSmallLeftRotation(rightChildOfRotatedRoot);

            return rightChildOfRotatedRoot;
        }

        protected T DoSmallRightRotation(T rootToRotate)
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

            AfterSmallRightRotation(leftChildOfRotatedRoot);

            return leftChildOfRotatedRoot;
        }

        private void ReplaceNodeInParent(T nodeToRemove, T node)
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

        protected virtual void AfterSmallLeftRotation(T rightChildOfRotatedRoot)
        {

        }

        protected virtual void AfterSmallRightRotation(T leftChildOfRotatedRoot)
        {

        }

        #endregion
    }
}
