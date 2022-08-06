using System;
using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Otus.SlayAndRandomSearchTrees.Logic.Randomized
{
    public class RandomizedTree : BaseTree<RandomizedNode>
    {
        private readonly Random _random;

        
        public RandomizedTree()
        {
            _random = new Random();
        }


        public RandomizedNode GetNode(int value)
        {
            return GetNode(Root, value);
        }
        

        #region Support methods

        private RandomizedNode GetNode(RandomizedNode currentNode, int value)
        {
            if (currentNode == null)
                return null;

            var nextNode = value < currentNode.Value
                ? currentNode.LeftChild
                : currentNode.RightChild;

            return GetNode(nextNode, value);
        }

        public RandomizedNode Insert(RandomizedNode node, int value)
        {
            if (Root == null)
            {
                Root = new RandomizedNode(value);
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

        private RandomizedNode InsertRoot(RandomizedNode root, int value) 
        {
            if (root == null)
            {
                Root = new RandomizedNode(value);
                return Root;
            }
            
            AddNode(root, value);

            if (value < root.Value)
            {
                return DoSmallRightRotation(root);
            }

            return DoSmallLeftRotation(root);
        }

        protected override void AfterSmallLeftRotation(RandomizedNode rightChildOfRotatedRoot)
        {
            rightChildOfRotatedRoot.FixSize();
        }

        protected override void AfterSmallRightRotation(RandomizedNode leftChildOfRotatedRoot)
        {
            leftChildOfRotatedRoot.FixSize();
        }

        #endregion
    }
}
