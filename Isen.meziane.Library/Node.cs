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