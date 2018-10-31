using System;
using System.Collections;
using System.Collections.Generic;

namespace Structures
{
    public class AvlTree<TK, TD> : IEnumerable<AvlTree<TK,TD>.Node>, IEnumerable<TD>
        where TK : IComparable
    {
        private Node _root;

        public AvlTree()
        {
            _root = null;
        }

        public class Node
        {
            public Node LeftChild;

            public Node RightChild;

            public Node Parent;

            public int Balance;

            public bool InsertedRight;

            public bool DeletedRight;

            public TK Key { get; set; }
            public TD Data { get; set; }

            public Node(TK key, TD data)
            {
                Key = key;
                Data = data;
            }

            public static Node GetLargestKeyNode(Node node) //metoda na vracanie najvacsej hodnoty kluca v lavom podstrome
            {
                var current = node;
                while (current.RightChild != null)
                {
                    current = current.RightChild;
                }
                return current;
            }

            public static Node GetSmallestKeyNodeRight(Node node) // metoda na vracanie najmensej hodnoty kluca v pravom podstrome
            {
                var current = node;
                while (current.LeftChild != null)
                {
                    current = current.LeftChild;
                }
                return current;
            }
        }

        public bool Insert(TK key, TD data)
        {
            Node insertedNode = new Node(key, data);
            insertedNode.Balance = 0;

            if (_root == null)
            {
                _root = insertedNode;
                return true;
            }
            else
            {
                Node currentNode = _root;
                while (true)
                {
                    if (insertedNode.Key.CompareTo(currentNode.Key) == 0) // inserting node with same key means return
                    {
                        return false;
                    }
                    else
                    {
                        if (insertedNode.Key.CompareTo(currentNode.Key) < 0) // insert to the left
                        {
                            if (currentNode.LeftChild == null)
                            {
                                currentNode.LeftChild = insertedNode;
                                insertedNode.Parent = currentNode;
                                currentNode.InsertedRight = false;
                                break;
                            }
                            else
                            {
                                currentNode.InsertedRight = false;
                                currentNode = currentNode.LeftChild;
                            }
                        }
                        else
                        {
                            if (currentNode.RightChild == null) // insert to the right
                            {
                                currentNode.RightChild = insertedNode;
                                insertedNode.Parent = currentNode;
                                currentNode.InsertedRight = true;
                                break;
                            }
                            else
                            {
                                currentNode.InsertedRight = true;
                                currentNode = currentNode.RightChild;
                            }
                        }
                    }
                }
                Node unbalancedNode = insertedNode.Parent;
                Node child = insertedNode;
                Node grandChild = null;
                while (true)
                {
                    if (unbalancedNode.LeftChild == child)
                    {
                        unbalancedNode.Balance--;
                    }
                    else if (unbalancedNode.RightChild == child)
                    {
                        unbalancedNode.Balance++;
                    }

                    if (unbalancedNode.Balance == 0)
                    {
                        return true;
                    }
                    if (unbalancedNode.Balance == -2)
                    {
                        if (unbalancedNode.LeftChild == child && child.LeftChild == grandChild)
                        {
                            RightRotation(this, unbalancedNode);
                            //nastavenie faktorov prava rotacia
                            child.Balance = 0;
                            unbalancedNode.Balance = 0;
                            return true;
                        }
                        else if (unbalancedNode.LeftChild == child && child.RightChild == grandChild)
                        {
                            LeftRotation(this, child);
                            RightRotation(this, unbalancedNode);
                            //nastavenie faktorov lava prava rotacia
                            if (insertedNode == grandChild)
                            {
                                grandChild.Balance = 0;
                                child.Balance = 0;
                                unbalancedNode.Balance = 0;
                            }
                            else if (grandChild?.InsertedRight == true)
                            {
                                grandChild.Balance = 0;
                                child.Balance = -1;
                                unbalancedNode.Balance = 0;
                            }
                            else if (grandChild?.InsertedRight == false)
                            {
                                grandChild.Balance = 0;
                                child.Balance = 0;
                                unbalancedNode.Balance = 1;
                            }
                            return true;
                        }

                    }
                    if (unbalancedNode.Balance == 2)
                    {
                        if (unbalancedNode.RightChild == child && child.RightChild == grandChild)
                        {
                            LeftRotation(this, unbalancedNode);
                            //nastavenie faktorov lava rotacia
                            child.Balance = 0;
                            unbalancedNode.Balance = 0;
                            return true;
                        }
                        else if (unbalancedNode.RightChild == child && child.LeftChild == grandChild)
                        {
                            RightRotation(this, child);
                            LeftRotation(this, unbalancedNode);
                            //nastavenie faktorov prava lava rotacia
                            if (insertedNode == grandChild)
                            {
                                grandChild.Balance = 0;
                                child.Balance = 0;
                                unbalancedNode.Balance = 0;
                            }
                            else if (grandChild?.InsertedRight == true)
                            {
                                grandChild.Balance = 0;
                                child.Balance = 0;
                                unbalancedNode.Balance = -1;
                            }
                            else if (grandChild?.InsertedRight == false)
                            {
                                grandChild.Balance = 0;
                                child.Balance = 1;
                                unbalancedNode.Balance = 0;
                            }
                            return true;
                        }
                    }
                    if (unbalancedNode == _root)
                    {
                        return true;
                    }

                    grandChild = child;
                    child = unbalancedNode;
                    unbalancedNode = unbalancedNode.Parent;
                }
            }
        }

        public bool Delete(TK key)
        {
            var current = _root;
            while (true)
            {
                if (current == null) // ak je prazdny
                {
                    return false;
                }
                if (current.Key.CompareTo(key) == 0 && current.LeftChild == null && current.RightChild == null && // ak mame len root a mazeme ten
                    current == _root)
                {
                    _root = null;
                    return true;
                }
                if (current.Key.CompareTo(key) == 0)
                {
                    var largestKeyLeftNode = current;
                    if (current.LeftChild != null)
                    {
                        largestKeyLeftNode = Node.GetLargestKeyNode(current.LeftChild);
                    }
                    if (current == _root && current.RightChild == null && current.LeftChild == largestKeyLeftNode 
                        && largestKeyLeftNode.RightChild == null && largestKeyLeftNode.LeftChild == null)
                    {
                        CopyValues(current, largestKeyLeftNode);
                        LeafDeletion(largestKeyLeftNode);
                        return true;
                    }
                    else
                    {
                        CopyValuesNoBalance(current, largestKeyLeftNode);
                        DeleteLeaf(current, largestKeyLeftNode);
                        return true;
                    }
                }
                else if (current.Key.CompareTo(key) < 0) //kluc je vacsi ako current
                {
                    current.DeletedRight = true;
                    current = current.RightChild;
                }
                else //kluc je mensi ako current
                {
                    current.DeletedRight = false;
                    current = current.LeftChild;
                }
            }
        }

        public TD Find(TK key)
        {
            var current = _root;
            while (true)
            {
                if (current == null)
                {
                    return default(TD);
                }
                if (current.Key.CompareTo(key) == 0)
                {
                    return current.Data;
                }
                else if (current.Key.CompareTo(key) < 0) //kluc je mensi ako current
                {
                    current = current.RightChild;
                }
                else //kluc je vacsi ako current
                {
                    current = current.LeftChild;
                }
            }
        }

        private void LeftRotation(AvlTree<TK, TD> tree, Node node)
        {
            if (node.RightChild != null)
            {
                var y = node.RightChild;
                node.RightChild = y.LeftChild;
                if (y.LeftChild != null)
                {
                    y.LeftChild.Parent = node;
                }
                y.Parent = node.Parent;
                if (node.Parent == null)
                {
                    tree._root = y;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = y;
                    }
                    else
                    {
                        node.Parent.RightChild = y;
                    }
                }
                y.LeftChild = node;
                node.Parent = y;
            }
        }

        private void RightRotation(AvlTree<TK, TD> tree, Node node)
        {
            if (node.LeftChild != null)
            {
                var x = node.LeftChild;
                node.LeftChild = x.RightChild;
                if (x.RightChild != null)
                {
                    x.RightChild.Parent = node;
                }
                x.Parent = node.Parent;
                if (node.Parent == null)
                {
                    tree._root = x;
                }
                else
                {
                    if (node.Parent.LeftChild == node)
                    {
                        node.Parent.LeftChild = x;
                    }
                    else
                    {
                        node.Parent.RightChild = x;
                    }
                }
                x.RightChild = node;
                node.Parent = x;
            }
        }

        private void DeleteLeaf(Node mazany, Node largestKeyLeftNode)
        {
            Node unbalancedNode = largestKeyLeftNode.Parent;

            bool prvokVymazany = false;
            bool rootAJedenSyn = false;

            if (largestKeyLeftNode.Parent == mazany && largestKeyLeftNode == largestKeyLeftNode.Parent.LeftChild)
            {
                mazany.DeletedRight = false;
            }
            else if (largestKeyLeftNode.Parent == mazany && largestKeyLeftNode == largestKeyLeftNode.Parent.RightChild)
            {
                mazany.DeletedRight = true;
            }

            if (largestKeyLeftNode.Parent != null)
            {
                if (largestKeyLeftNode == largestKeyLeftNode.Parent.LeftChild)
                {
                    unbalancedNode.DeletedRight = false;
                }
                else if (largestKeyLeftNode == largestKeyLeftNode.Parent.RightChild)
                {
                    unbalancedNode.DeletedRight = true;
                }
            }

            if (largestKeyLeftNode.Parent == null)
            {
                unbalancedNode = largestKeyLeftNode;
                rootAJedenSyn = true;
            }

            while (true)
            {
                if (unbalancedNode.Balance == 0) // ak je balance 0 pred upravenim koniec rotacii
                {
                    if (!unbalancedNode.DeletedRight)
                    {
                        unbalancedNode.Balance++;
                    }
                    else
                    {
                        unbalancedNode.Balance--;
                    }
                    if (!prvokVymazany)
                    {
                        LeafDeletion(largestKeyLeftNode);
                        prvokVymazany = true;
                    }
                    return;
                }

                else
                {
                    if (unbalancedNode.Balance != 0)
                    {
                        if (!unbalancedNode.DeletedRight) // zmena balance 
                        {
                            unbalancedNode.Balance++;
                        }
                        else
                        {
                            unbalancedNode.Balance--;
                        }

                        if (!prvokVymazany)
                        {
                            LeafDeletion(largestKeyLeftNode);  // najprv odstrstranime a teraz budeme rotovat a menit balance
                            prvokVymazany = true;
                            if (rootAJedenSyn)
                            {
                                return;
                            }
                        }

                        if (unbalancedNode.Balance == -2)
                        {
                            if (unbalancedNode.LeftChild.Balance == -1)
                            {
                                RightRotation(this, unbalancedNode);
                                //nastavenie faktorov prava rotacia
                                unbalancedNode.Balance = 0;
                                unbalancedNode.Parent.Balance = 0;
                            }
                            else if (unbalancedNode.LeftChild.Balance == 1)
                            {
                                if (unbalancedNode.LeftChild.RightChild.Balance == 0)
                                {
                                    LeftRightRotation(unbalancedNode);
                                    unbalancedNode.Balance = 0;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.LeftChild.Balance = 0;
                                }
                                else if (unbalancedNode.LeftChild.RightChild.Balance == 1)
                                {
                                    LeftRightRotation(unbalancedNode);
                                    unbalancedNode.Balance = 0;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.LeftChild.Balance = -1;
                                }
                                else if (unbalancedNode.LeftChild.RightChild.Balance == -1)
                                {
                                    LeftRightRotation(unbalancedNode);
                                    unbalancedNode.Balance = 1;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.LeftChild.Balance = 0;
                                }

                            }
                            else if (unbalancedNode.LeftChild.Balance == 0)
                            {
                                RightRotation(this, unbalancedNode);

                                unbalancedNode.Balance = -1;
                                unbalancedNode.Parent.Balance = 1;
                                return;
                            }

                            if (unbalancedNode.Parent.Parent != null)
                            {
                                if (unbalancedNode.Parent == unbalancedNode.Parent.Parent.LeftChild)
                                {
                                    unbalancedNode.Parent.Parent.DeletedRight = false;
                                }
                                else if (unbalancedNode.Parent == unbalancedNode.Parent.Parent.RightChild)
                                {
                                    unbalancedNode.Parent.Parent.DeletedRight = true;
                                }
                            }

                            unbalancedNode = unbalancedNode.Parent.Parent;
                            if (unbalancedNode == null)
                            {
                                return;
                            }
                        }
                        else if (unbalancedNode.Balance == 2)
                        {
                            if (unbalancedNode.RightChild.Balance == 1)
                            {
                                LeftRotation(this, unbalancedNode);
                                //nastavenie faktorov lava rotacia
                                unbalancedNode.Balance = 0;
                                unbalancedNode.Parent.Balance = 0;
                            }
                            else if (unbalancedNode.RightChild.Balance == -1)
                            {
                                if (unbalancedNode.RightChild.LeftChild.Balance == 0)
                                {
                                    RightLeftRotation(unbalancedNode);
                                    unbalancedNode.Balance = 0;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.RightChild.Balance = 0;
                                }
                                else if (unbalancedNode.RightChild.LeftChild.Balance == 1)
                                {
                                    RightLeftRotation(unbalancedNode);
                                    unbalancedNode.Balance = -1;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.RightChild.Balance = 0;
                                }
                                else if (unbalancedNode.RightChild.LeftChild.Balance == -1)
                                {
                                    RightLeftRotation(unbalancedNode);
                                    unbalancedNode.Balance = 0;
                                    unbalancedNode.Parent.Balance = 0;
                                    unbalancedNode.Parent.RightChild.Balance = 1;
                                }
                            }
                            else if (unbalancedNode.RightChild.Balance == 0)
                            {
                                LeftRotation(this, unbalancedNode);

                                unbalancedNode.Balance = 1;
                                unbalancedNode.Parent.Balance = -1;
                                return;
                            }

                            if (unbalancedNode.Parent.Parent != null)
                            {
                                if (unbalancedNode.Parent == unbalancedNode.Parent.Parent.LeftChild)
                                {
                                    unbalancedNode.Parent.Parent.DeletedRight = false;
                                }
                                else if (unbalancedNode.Parent == unbalancedNode.Parent.Parent.RightChild)
                                {
                                    unbalancedNode.Parent.Parent.DeletedRight = true;
                                }
                            }

                            unbalancedNode = unbalancedNode.Parent.Parent;
                            if (unbalancedNode == null)
                            {
                                return;
                            }
                        }
                        else
                        {
                            if (unbalancedNode.Parent != null)
                            {
                                if (unbalancedNode == unbalancedNode.Parent.LeftChild)
                                {
                                    unbalancedNode.Parent.DeletedRight = false;
                                }
                                else if (unbalancedNode == unbalancedNode.Parent.RightChild)
                                {
                                    unbalancedNode.Parent.DeletedRight = true;
                                }
                            }
                            unbalancedNode = unbalancedNode.Parent;
                            if (unbalancedNode == null)
                            {
                                return;
                            }
                        }             
                    }
                }
            }
        }

        private void LeftRightRotation(Node unbalancedNode)
        {
            LeftRotation(this, unbalancedNode.LeftChild);
            RightRotation(this, unbalancedNode);
        }

        private void RightLeftRotation(Node unbalancedNode)
        {
            RightRotation(this, unbalancedNode.RightChild);
            LeftRotation(this, unbalancedNode);
        }

        private void LeafDeletion(Node largestKeyLeftNode)
        {
            if (largestKeyLeftNode.Parent != null)
            {
                if (largestKeyLeftNode == largestKeyLeftNode.Parent.LeftChild)
                {
                    if (largestKeyLeftNode.LeftChild == null && largestKeyLeftNode.RightChild == null)
                    {
                        largestKeyLeftNode.Parent.LeftChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }
                    if (largestKeyLeftNode.LeftChild != null && largestKeyLeftNode.RightChild == null)
                    {
                        largestKeyLeftNode.Parent.LeftChild = largestKeyLeftNode.LeftChild;
                        largestKeyLeftNode.LeftChild.Parent = largestKeyLeftNode.Parent;
                        largestKeyLeftNode.LeftChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }

                    if (largestKeyLeftNode.LeftChild == null && largestKeyLeftNode.RightChild != null)
                    {
                        largestKeyLeftNode.Parent.LeftChild = largestKeyLeftNode.RightChild;
                        largestKeyLeftNode.RightChild.Parent = largestKeyLeftNode.Parent;
                        largestKeyLeftNode.RightChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }

                    if (largestKeyLeftNode.LeftChild != null && largestKeyLeftNode.RightChild != null)
                    {
                        var smallest = Node.GetSmallestKeyNodeRight(largestKeyLeftNode.RightChild);
                        if (smallest == smallest.Parent.LeftChild)
                        {
                            if (smallest.RightChild != null)
                            {
                                smallest.Parent.LeftChild = smallest.RightChild;
                                smallest.RightChild.Parent = smallest.Parent;
                            }
                            else
                            {
                                smallest.Parent.LeftChild = null;
                            }
                        }
                        else
                        {
                            if (smallest.RightChild != null)
                            {
                                smallest.Parent.RightChild = smallest.RightChild;
                                smallest.RightChild.Parent = smallest.Parent;
                            }
                            else
                            {
                                smallest.Parent.RightChild = null;
                            }
                        }
                        largestKeyLeftNode.Parent.LeftChild = smallest;
                        smallest.Parent = largestKeyLeftNode.Parent;
                        if (largestKeyLeftNode.RightChild != null)
                        {
                            smallest.RightChild = largestKeyLeftNode.RightChild;
                            largestKeyLeftNode.RightChild.Parent = smallest;
                        }
                        largestKeyLeftNode.Parent = null;
                        largestKeyLeftNode.LeftChild = null;
                        largestKeyLeftNode.RightChild = null;
                        return;
                    }
                }
                else
                {
                    if (largestKeyLeftNode.LeftChild == null && largestKeyLeftNode.RightChild == null)
                    {
                        largestKeyLeftNode.Parent.RightChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }
                    if (largestKeyLeftNode.LeftChild != null && largestKeyLeftNode.RightChild == null)
                    {
                        largestKeyLeftNode.Parent.RightChild = largestKeyLeftNode.LeftChild;
                        largestKeyLeftNode.LeftChild.Parent = largestKeyLeftNode.Parent;
                        largestKeyLeftNode.LeftChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }

                    if (largestKeyLeftNode.LeftChild == null && largestKeyLeftNode.RightChild != null)
                    {
                        largestKeyLeftNode.Parent.RightChild = largestKeyLeftNode.RightChild;
                        largestKeyLeftNode.RightChild.Parent = largestKeyLeftNode.Parent;
                        largestKeyLeftNode.RightChild = null;
                        largestKeyLeftNode.Parent = null;
                        return;
                    }

                    if (largestKeyLeftNode.LeftChild != null && largestKeyLeftNode.RightChild != null)
                    {
                        var smallest = Node.GetSmallestKeyNodeRight(largestKeyLeftNode.RightChild);
                        if (smallest == smallest.Parent.LeftChild)
                        {
                            if (smallest.RightChild != null)
                            {
                                smallest.Parent.LeftChild = smallest.RightChild;
                                smallest.RightChild.Parent = smallest.Parent;
                            }
                            else
                            {
                                smallest.Parent.LeftChild = null;
                            }
                        }
                        else
                        {
                            if (smallest.RightChild != null)
                            {
                                smallest.Parent.RightChild = smallest.RightChild;
                                smallest.RightChild.Parent = smallest.Parent;
                            }
                            else
                            {
                                smallest.Parent.RightChild = null;
                            }
                        }
                        largestKeyLeftNode.Parent.RightChild = smallest;
                        smallest.Parent = largestKeyLeftNode.Parent;
                        if (largestKeyLeftNode.RightChild != null)
                        {
                            smallest.RightChild = largestKeyLeftNode.RightChild;
                            largestKeyLeftNode.RightChild.Parent = smallest;
                        }
                        largestKeyLeftNode.Parent = null;
                        largestKeyLeftNode.LeftChild = null;
                        largestKeyLeftNode.RightChild = null;
                        return;
                    }
                }
            }
            if (largestKeyLeftNode.Parent == null)
            {
                if (largestKeyLeftNode.LeftChild == null && largestKeyLeftNode.RightChild != null)
                {
                    _root = largestKeyLeftNode.RightChild;
                    _root.Parent = null;
                }

                else if (largestKeyLeftNode.LeftChild != null && largestKeyLeftNode.RightChild == null)
                {
                    _root = largestKeyLeftNode.LeftChild;
                    _root.Parent = null;
                }
            }
        }

        private void CopyValues(Node current, Node largestKeyNode)
        {
            current.Key = largestKeyNode.Key;
            current.Data = largestKeyNode.Data;
            current.Balance = largestKeyNode.Balance;
        }

        private void CopyValuesNoBalance(Node current, Node largestKeyNode)
        {
            current.Key = largestKeyNode.Key;
            current.Data = largestKeyNode.Data;
        }

        public IEnumerable<TD> GetDataEnumerator()
        {
            var current = _root;
            MyArray<Node> list = new MyArray<Node>();
            bool end = false;
            while (end == false)
            {
                if (current != null)
                {
                    list.Add(current);
                    current = current.LeftChild;
                }
                else
                {
                    if (!list.IsEmpty())
                    {
                        current = list.Get(list.Count() - 1);
                        list.Remove(list.Count() - 1);
                        yield return current.Data;
                        current = current.RightChild;
                    }
                    else
                    {
                        end = true;
                    }
                }
            }
        }

        public IEnumerator<Node> GetEnumerator()
        {
            var current = _root;
            MyArray<Node> list = new MyArray<Node>();
            bool end = false;
            while (end == false)
            {
                if (current != null)
                {
                    list.Add(current);
                    current = current.LeftChild;
                }
                else
                {
                    if (!list.IsEmpty())
                    {
                        current = list.Get(list.Count() - 1);
                        list.Remove(list.Count() - 1);
                        yield return current;
                        current = current.RightChild;
                    }
                    else
                    {
                        end = true;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<TD> IEnumerable<TD>.GetEnumerator()
        {
            return (IEnumerator<TD>) GetDataEnumerator();
        }

        public void CheckDepth()
        {
            foreach (Node node in this)
            {
                int maxlh = CountHeight(node?.LeftChild);
                int maxrh = CountHeight(node?.RightChild);
                if (maxlh - maxrh > 1 || maxrh - maxlh < -1 || maxlh - maxrh < -1 || maxrh - maxlh > 1)
                {
                    Console.WriteLine("Tree is unbalanced." + node.Key);
                }
            }
        }

        private int CountHeight(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(CountHeight(node.LeftChild), CountHeight(node.RightChild));
            }
        }
    }
}
