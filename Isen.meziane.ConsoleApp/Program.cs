using System;
using Isen.meziane.Library;

namespace Isen.meziane.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var racine = new Node<string>("racine");
            
            var c1 = new Node<string>( "c1");
            var c2 = new Node<string>("c2");
            
            var c11 = new Node<string>("c11");
            var c21= new Node<string>( "c21");
            var c22 = new Node<string>("c22");
            
            racine.AddChildNode(c1);
            racine.AddChildNode(c2);
            
            c1.AddChildNode(c11);
            c2.AddChildNode(c21);
            c2.AddChildNode(c22);
            
            Console.WriteLine(racine.ToString());
        }
    }
}
