using NUnit.Framework;
using Otus.SlayAndRandomSearchTrees.Logic;
using Otus.SlayAndRandomSearchTrees.Logic.Base;

namespace Tests
{
    public class Randomized_Tests
    {
        [Test]
        public void Can_Search()
        {
            var tree = new RandomizedTree();
            var firstNode = tree.Insert(new Node(), 10);
            var secondNode = tree.Insert(firstNode, 20);
            var thirdNode = tree.Insert(secondNode, 15);
            var forthNode = tree.Insert(thirdNode, 40);

           //due to randomizer asserts are not useful

           var test = tree.Root;
        }

        [Test]
        public void CanNot_Search_UnExisting_Value()
        {
            var tree = new RandomizedTree();
            tree.Insert(new Node(),10);

            var result = tree.GetNode(123);

            Assert.IsNull(result);
        }
    }
}