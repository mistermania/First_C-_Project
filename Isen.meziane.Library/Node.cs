using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Isen.meziane.Library
{
    public class Node<T>
            :  INode<T> , IEquatable<Node<T>>
    {
        //Rider auto-generate code
        public T value { get; set; }
        public Guid Id { get; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
        public int Depth => Parent?.Depth + 1 ?? 0;
        //end Rider auto-generate code

        public Node()
        {
            this.value = default(T);
            this.Id = new Guid();
            this.Parent = null;
            this.Children = new List<Node<T>>();
        }
        
        public Node(T value)
        {
            this.value = value;
            this.Id = new Guid();
            this.Parent = null;
            this.Children = new List<Node<T>>();
        }

        public void AddChildNode(Node<T> node)
        {
            var children = node;
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
                if (child.Id == id)
                {
                    this.Children.RemoveAt(i);
                }

                i++;
            }
        }

        public void RemoveChildNote(Node<T> node)
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

        public Node<T> FindTraversing(Guid id)
        {
            if (this.Id == id)
            {
                return this;
            }        
            foreach (var child in this.Children)
            {
                var result = FindTraversing(id);

                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }
        
        public Node<T> FindTraversing(Node<T> node)
        {
            if (this.Equals(node))
            {
                return this;
            }        
            foreach (var child in this.Children)
            {
                var result = FindTraversing(node);

                if (result != null)
                {
                    return result;
                }
            }
            return null;
        }

        //Rider auto-generate override method
        public override string ToString()
        {
            var text = "";
            for (int i = 0; i < this.Depth; i++)
            {
                text = text + "|-";
            }

            text = text + $"{this.value} {this.Id}";
            
            foreach (var child in this.Children)
            {
                text = text + $"{Environment.NewLine}" + child.ToString();
            }

            return text;
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
        //end Rider auto-generate code
    }
}