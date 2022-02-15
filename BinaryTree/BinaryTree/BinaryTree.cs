using System;

namespace BinaryTree
{
	public class BinaryTreeNode<T> where T : IComparable<T>
	{
		private BinaryTreeNode<T> _parent, _left, _right;
		private T _value;

		public BinaryTreeNode(T value, BinaryTreeNode<T> parent)
		{
			_value = value;
			_parent = parent;
		}

		public void Add(T value)
		{
			if (value.CompareTo(_value) < 0)
			{
				switch(_left)
                {
					case null:
						_left = new BinaryTreeNode<T>(value, this);
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
					_right = new BinaryTreeNode<T>(value, this);
					break;
				default:
					_right.Add(value);
					break;
			}
		}
		
		public BinaryTreeNode<T> Search(T value)
		{
			return Search(this, value);
		}

		private BinaryTreeNode<T> Search(BinaryTreeNode<T> node, T value)
        {
			if (node == null)
			{
				return null;
			}

            return value.CompareTo(node._value) switch
            {
                -1 => Search(node._left, value),
                1 => Search(node._right, value),
                0 => node,
                _ => null,
            };
        }

		public bool Remove(T value)
        {
			return Remove(Search(value));
        }

		private bool Remove(BinaryTreeNode<T> node)
		{
			if (node == null)
			{
				return false;
			}

			BinaryTreeNode<T> currentNode;
			if (node == this)
			{
				if (node._right != null)
				{
					currentNode = node._right;
				}
				else
				{
					currentNode = node._left;
				}

				while (currentNode._left != null)
				{
					currentNode = currentNode._left;
				}
				T temp = currentNode._value;
				Remove(currentNode);
				node._value = temp;

				return true;
			}

			if (node._left == null && node._right == null)
            {
				if (node == node._parent._left)
                {
					node._parent._left = null;
                }
				else
                {
					node._parent._right = null;
                }

				return true;
            }

			if (node._left == null && node._right != null)
            {
				if (node == node._parent._left)
				{
					node._parent._left = node._right;
				}
				else
				{
					node._parent._right = node._right;
				}

				node._right._parent = node._parent;

				return true;
			}

			if (node._left != null && node._right == null)
			{
				if (node == node._parent._left)
				{
					node._parent._left = node._left;
				}
				else
				{
					node._parent._right = node._left;
				}

				node._left._parent = node._parent;

				return true;
			}

			if (node._right != null && node._left != null)
			{
				currentNode = node._right;

				while (currentNode._left != null)
				{
					currentNode = currentNode._left;
				}

				if (currentNode._parent == node)
				{
					currentNode._left = node._left;
					node._left._parent = currentNode;
					currentNode._parent = node._parent;
					if (node == node._parent._left)
					{
						node._parent._left = currentNode;
					}
					else
					{
						node._parent._right = currentNode;
					}

					return true;
				}

				if (currentNode._right != null)
				{
					currentNode._right._parent = currentNode._parent;
				}

				currentNode._parent._left = currentNode._right;
				currentNode._right = node._right;
				currentNode._left = node._left;
				node._left._parent = currentNode;
				node._right._parent = currentNode;
				currentNode._parent = node._parent;
				if (node == node._parent._left)
				{
					node._parent._left = currentNode;
				}
				else
				{
					node._parent._right = currentNode;
				}

				return true;
			}

			return false;
		}

		private void Print(BinaryTreeNode<T> node)
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

		public override string ToString()
		{
			return _value.ToString();
		}
    }
}
