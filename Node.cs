using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL
{
    // Определение класса Node, представляющего узел AVL дерева
    public class Node
    {
        // Ключ узла
        public int Key;

        // Высота узла
        public int Height;

        // Указатель на левого потомка
        public Node Left;

        // Указатель на правого потомка
        public Node Right;

        // Конструктор класса Node, инициализирует узел с заданным ключом и высотой, равной 1
        public Node(int key)
        {
            Key = key;
            Height = 1;
        }
    }
}