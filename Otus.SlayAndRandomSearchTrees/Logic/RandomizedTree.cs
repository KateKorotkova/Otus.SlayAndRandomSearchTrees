using System;
using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Otus.SlayAndRandomSearchTrees.Logic
{
    public class RandomizedTree : BaseTree
    {
        private readonly Random _random;

        
        public RandomizedTree()
        {
            _random = new Random();
        }


        public Node GetNode(int value)
        {
            return GetNode(Root, value);
        }
        

        #region Support methods

        private Node GetNode(Node currentNode, int value)
        {
            if (currentNode == null)
                return null;

            var nextNode = value < currentNode.Value
                ? currentNode.LeftChild
                : currentNode.RightChild;

            return GetNode(nextNode, value);
        }

        public Node Insert(Node node, int value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return Root;
            }

            if (_random.Next() % (node.Size + 1) == 0) 
            //// for tests purposes
            //if (true)
                return InsertRoot(node, value);

            AddNode(Root, value);
            node.FixSize();

            return node;
        }

        private Node InsertRoot(Node root, int value) 
        {
            if (root == null)
            {
                Root = new Node(value);
                return Root;
            }
            
            AddNode(root, value);

            if (value < root.Value)
            {
                return DoSmallRightRotation(root);
            }

            return DoSmallLeftRotation(root);
        }

        private Node DoSmallLeftRotation(Node rootToRotate)
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

            rightChildOfRotatedRoot.Size = rootToRotate.Size;
            rightChildOfRotatedRoot.FixSize();

            return rightChildOfRotatedRoot;
        }

        private Node DoSmallRightRotation(Node rootToRotate)
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

            leftChildOfRotatedRoot.Size = rootToRotate.Size;
            leftChildOfRotatedRoot.FixSize();

            return leftChildOfRotatedRoot;
        }

        #endregion
    }
}
