using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisplayDataWithLINQ.Tests
{
    [TestClass]
    public class BinaryTreeTests
    {
		[TestMethod]
		public void PlaceLesserElementToLeft()
		{
			var tree = new BinaryTree<int>(2);
			tree.Add(1);
			Assert.AreEqual(2, tree.Value);
			Assert.AreEqual(1, tree.Left.Value);
		}

		[TestMethod]
		public void PlaceEqualElementToLeft()
		{
			var tree = new BinaryTree<int>(2);
			tree.Add(2);
			Assert.AreEqual(2, tree.Value);
			Assert.AreEqual(2, tree.Left.Value);
		}

		[TestMethod]
		public void PlaceGreaterElementToRight()
		{
			var tree = new BinaryTree<int>(2);
			tree.Add(3);
			Assert.AreEqual(2, tree.Value);
			Assert.AreEqual(3, tree.Right.Value);
		}
	}
}
