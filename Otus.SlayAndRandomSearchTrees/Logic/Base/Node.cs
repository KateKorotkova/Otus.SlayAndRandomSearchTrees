namespace Otus.SlayAndRandomSearchTrees.Logic.Base
{
    public class Node
    {
        public int Value;
        public int Size;

        public Node Parent;
        public Node LeftChild;
        public Node RightChild;


        public Node()
        {
            Size = 1;
        }

        public Node(int value)
        {
            Value = value;
        }


        public void FixSize()
        {
            Size = LeftChild?.Size ?? 0 + RightChild?.Size ?? 0 + 1;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
