using System;
using System.Collections.Generic;

namespace Isen.meziane.Library
{
    public class Node<T>
            : INode<T> , IEquatable<Node<T>>
    {
        //Rider auto-generate code
        public T value { get; set; }
        public Guid Id { get; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
        public int Depth { get; set; }

        public void AddChildNode(Node<T> node)
        {
            var children = new Node<T>();
            children.Parent = this;
            Children.Add(children);
        }

        public void AddNodes(IEnumerable<Node<T>> nodeList)
        {
            foreach (var node in nodeList)
            {
                this.Children.Add(node);
            }
        }

        public void RemoveChildNote(Guid id)
        {
            var i = 0;
            foreach (var child in this.Children)
            {
                if (child.Id.Equals(id))
                {
                    this.Children.RemoveAt(i);
                }

                i++;
            }
        }

        public void RemoveChildNode(Node<T> node)
        {
            var i = 0;
            foreach (var child in this.Children)
            {
                if (child.Equals(node))
                {
                    this.Children.RemoveAt(i);
                }

                i++;
            }
        }

        
        //Rider auto-generate code
        public bool Equals(Node<T> other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<T>.Default.Equals(value, other.value) && Id.Equals(other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Node<T>) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (EqualityComparer<T>.Default.GetHashCode(value) * 397) ^ Id.GetHashCode();
            }
        }
    }
}