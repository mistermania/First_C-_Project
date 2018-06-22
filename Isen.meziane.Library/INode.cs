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
    }
    
}