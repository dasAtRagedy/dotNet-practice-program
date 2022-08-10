using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        public class Node
        {
            public T Value;
            public Node Next;
            public Node Prev;
        
            public Node(T value)
            {
                this.Value = value;
            }
        }
        
        private Node _head;
        private Node _tail;
        private int _count;
        
        
        public int Length => _count;

        public void Add(T e)
        {
            var node = new Node(e);
            if (_head == null)
            {
                _head = node;
                _tail = node;
            }
            else
            {
                _tail.Next = node;
                node.Prev = _tail;
                _tail = node;
            }
            _count++;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException();
            
            
            if (index == _count)
            {
                Add(e);
            }
            else if (index == 0)
            {
                var node = new Node(e);
                node.Next = _head;
                _head.Prev = node;
                _head = node;
            }
            else
            {
                var node = new Node(e);
                var current = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next.Prev = node;
                current.Next = node;
                node.Prev = current;
            }
        }

        public T ElementAt(int index)
        {
            if(index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            
            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            if(_count == 0)
                throw new InvalidOperationException();
            
            var current = _head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current == _head)
                    {
                        _head = current.Next;
                        _head.Prev = null;
                    }
                    else if (current == _tail)
                    {
                        _tail = current.Prev;
                        _tail.Next = null;
                    }
                    else
                    {
                        current.Prev.Next = current.Next;
                        current.Next.Prev = current.Prev;
                    }
                    _count--;
                    return;
                }
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            if(index < 0 || index >= _count)
                throw new IndexOutOfRangeException();
            
            var current = _head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            if (current == _head)
            {
                _head = current.Next;
                _head.Prev = null;
            }
            else if (current == _tail)
            {
                _tail = current.Prev;
                _tail.Next = null;
            }
            else
            {
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;
            }
            _count--;
            return current.Value;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
