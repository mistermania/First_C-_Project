using System;
using System.Collections.Generic;

namespace Isen.meziane.Library
{
    public interface INode<T>
    {
        /// summary
        /// Renvoie la string Value
        T value { get; set; }
        
        Guid Id { get; }
        
        Node<T> Parent { get; set; }
        
        List<Node<T>> Children { get; set; }
        
        int Depth { get; set; }

        void AddChildNode(Node<T> node);

        void AddNodes(IEnumerable<Node<T>> nodeList);
        
        void RemoveChildNote(Guid id);
        void RemoveChildNote(Node<T> node);

        Node<T> FindTraversing(Guid id);
        Node<T> FindTraversing(Node<T> node);
    }
    
}