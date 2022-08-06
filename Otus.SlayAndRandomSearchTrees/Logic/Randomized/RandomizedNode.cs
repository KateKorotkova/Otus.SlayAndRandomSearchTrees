using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Otus.SlayAndRandomSearchTrees.Logic.Randomized
{
    public class RandomizedNode : BaseNode<RandomizedNode>
    {
        public int Size;


        public RandomizedNode()
        {
            Size = 1;
        }

        public RandomizedNode(int value) : base(value)
        {
            
        }


        public void FixSize()
        {
            Size = LeftChild?.Size ?? 0 + RightChild?.Size ?? 0 + 1;
        }
    }
}
