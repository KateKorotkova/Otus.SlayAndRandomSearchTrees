namespace Otus.SlayAndRandomSearchTrees.Logic.Base
{
    public abstract class BaseNode<T>
    {
        public int Value;

        public T Parent;
        public T LeftChild;
        public T RightChild;


        protected BaseNode()
        {

        }

        protected BaseNode(int value)
        {
            Value = value;
        }


        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
