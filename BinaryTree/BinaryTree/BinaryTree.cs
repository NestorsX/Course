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
			if (value.CompareTo(_value) <= 0)
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

		private void ChangeChildOfParentNode(BinaryTreeNode<T> node, BinaryTreeNode<T> nodeToChange)
        {
			if (node._parent == null)
            {
				return;
            }

			if (node == node._parent._left)
			{
				node._parent._left = nodeToChange;
				return;
			}

			node._parent._right = nodeToChange;
		}
		
		private BinaryTreeNode<T> GetLeftmostNode(BinaryTreeNode<T> currentNode)
        {
			if (currentNode._left != null)
			{ 
				return GetLeftmostNode(currentNode._left);
			}

			return currentNode;
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
			if (node._left == null && node._right == null)
            {
				ChangeChildOfParentNode(node, null);
				return true;
            }

			if (node._left == null && node._right != null)
            {
				ChangeChildOfParentNode(node, node._right);
				node._right._parent = node._parent;
				return true;
			}

			if (node._left != null && node._right == null)
			{
				ChangeChildOfParentNode(node, node._left);
				node._left._parent = node._parent;
				return true;
			}

			if (node._right != null && node._left != null)
			{
				currentNode = GetLeftmostNode(node._right);
				node._value = currentNode._value;
				return Remove(currentNode);
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
