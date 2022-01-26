using System;
using System.Collections;
using System.Collections.Generic;

namespace BinaryTree
{
	public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
	{
		private BinaryTree<T> _left, _right;
		private readonly T _value;

		public BinaryTree(T value)
		{
			_value = value;
		}

		public void Add(T value)
		{
			if (value.CompareTo(_value) < 0)
			{
				switch(_left)
                {
					case null:
						_left = new BinaryTree<T>(value);
						break;
					default:
						_left.Add(value);
						break;
				}

				return;
			}

			switch (_right)
			{
				case null:
					_right = new BinaryTree<T>(value);
					break;
				default:
					_right.Add(value);
					break;
			}
		}

		private void Print(BinaryTree<T> node)
		{
			if (node == null)
			{
				return;
			}

            Print(node._left);
            Console.WriteLine(node + "\n");
			if (node._right != null)
			{
				Print(node._right);
			}
		}

		public void Print()
		{
			Print(this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (_left != null)
			{
				foreach (T item in _left)
				{
					yield return item;
				}
			}

			if (_right != null)
			{
				foreach (T item in _right)
				{
					yield return item;
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (_left != null)
			{
				foreach (T item in _left)
				{
					yield return item;
				}
			}

			if (_right != null)
			{
				foreach (T item in _right)
				{
					yield return item;
				}
			}
		}

		public override string ToString()
		{
			return _value.ToString();
		}
	}
}
