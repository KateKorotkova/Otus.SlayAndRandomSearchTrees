using NUnit.Framework;
using Otus.SlayAndRandomSearchTrees.Logic;

namespace Tests
{
    public class Splay_Tests
    {
        [Test]
        public void Can_Search()
        {
            var tree = new SplayTree();
            tree.Insert(10);
            tree.Insert(20);
            tree.Insert(30);
            tree.Insert(40);

            var result = tree.GetNode(40);

            Assert.That(tree.Root.Value, Is.EqualTo(40));
            Assert.That(tree.Root.LeftChild.Value, Is.EqualTo(10));
            Assert.That(tree.Root.LeftChild.RightChild.Value, Is.EqualTo(30));
            Assert.That(tree.Root.LeftChild.RightChild.LeftChild.Value, Is.EqualTo(20));
        }

        [Test]
        public void CanNot_Search_UnExisting_Value()
        {
            var tree = new SplayTree();
            tree.Insert(10);

            var result = tree.GetNode(123);

            Assert.IsNull(result);
        }
    }
}