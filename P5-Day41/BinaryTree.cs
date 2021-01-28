using System;

namespace BinaryTree
{
    public class TreeNode
    {
        public int data { get; set; }
        public TreeNode leftNode;
        public TreeNode rightNode;

        public TreeNode(int data)
        {
            this.data = data;
            leftNode = null;
            rightNode = null;
        }
    }
    public class BinaryTree
    {
        public TreeNode root { get; set; }

        public bool Add(int data)
        {
            TreeNode previous = null, iter = root;

            while (iter != null)
            {
                previous = iter;
                if (data < iter.data)
                {
                    iter = iter.leftNode;
                }
                else if (data > iter.data)
                {
                    iter = iter.rightNode;
                }
                else
                {
                    return false;
                }
            }
            TreeNode newNode = new TreeNode(data);

            if (this.root == null)
            {
                root = newNode;
            }
            else
            {
                if (data < previous.data)
                {
                    previous.leftNode = newNode;
                }
                else
                {
                    previous.rightNode = newNode;
                }
            }
            return true;
        }
        public TreeNode Find(int data)
        {
            return FindUtil(data, root);
        }

        private TreeNode FindUtil(int data, TreeNode parent)
        {
            if (parent != null)
            {
                if (data == parent.data)
                {
                    return parent;
                }
                if (data < parent.data)
                {
                    return FindUtil(data, parent.leftNode);
                }
                else
                {
                    return FindUtil(data, parent.rightNode);
                }
            }
            return null;
        }
        public void Remove(int data)
        {
            root = RemoveUtil(root, data);
        }

        private TreeNode RemoveUtil(TreeNode parent, int data)
        {
            if (parent == null)
            {
                return parent;
            }
            else
            {
                if (parent.leftNode == null)
                {
                    return parent.rightNode;
                }
                else if (parent.rightNode == null)
                {
                    return parent.leftNode;
                }

                parent.data = MinValue(parent.rightNode);

                parent.rightNode = RemoveUtil(parent.rightNode, parent.data);
            }
            return parent;
        }

        private int MinValue(TreeNode node)
        {
            int minValue = node.data;

            while (node.leftNode != null)
            {
                minValue = node.leftNode.data;
                node = node.leftNode;
            }
            return minValue;
        }

        public int GetTreeDepth()
        {
            return GetTreeDepthUtil(root);
        }

        private int GetTreeDepthUtil(TreeNode parent)
        {
            return parent == null ? 0 : Math.Max(GetTreeDepthUtil(parent.leftNode), GetTreeDepthUtil(parent.rightNode)) + 1;
        }

        public void TraversePreOrder(TreeNode parent)
        {
            if (parent != null)
            {
                Console.Write(parent.data + " ");
                TraversePreOrder(parent.leftNode);
                TraversePreOrder(parent.rightNode);
            }
        }
        public void TraverseInOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.leftNode);
                Console.Write(parent.data + " ");
                TraverseInOrder(parent.rightNode);
            }
        }
        public void TraversePostOrder(TreeNode parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.leftNode);
                TraversePostOrder(parent.rightNode);
                Console.Write(parent.data + " ");
            }
        }
    }
}
