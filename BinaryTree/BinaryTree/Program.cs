using System;

namespace BinaryTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
			var score = new Random();
			var tree = new BinaryTree<StudentTestResult>(new StudentTestResult($"Student 0", $"Test 0", DateTime.Now, 7));
			for (int i = 1; i <= 10; i++)
			{
				tree.Add(new StudentTestResult($"Student {i}", $"Test {i}", DateTime.Now, score.Next(10)));
			}

			tree.Print();
		}
    }
}
