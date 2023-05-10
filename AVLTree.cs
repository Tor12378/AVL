namespace AVL
{
    // Определение класса AVLTree
    class AVLTree
    {
        // Корень дерева
        private Node root;

        // Счетчик операций
        public int OperationsCount { get; set; } = 0;

        // Добавление элемента в дерево
        public void Add(int key)
        {
            root = Add(root, key);
        }

        // Вспомогательный метод для добавления элемента в узел дерева
        private Node Add(Node node, int key)
        {
            OperationsCount++; // Увеличиваем счетчик операций
            if (node == null) return new Node(key);

            // Вставка ключа в левое или правое поддерево
            if (key < node.Key)
            {
                node.Left = Add(node.Left, key);
            }
            else if (key > node.Key)
            {
                node.Right = Add(node.Right, key);
            }
            else
            {
                // Ключ уже существует, не добавляем
                return node;
            }

            // Обновление высоты узла
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Балансировка узла
            return Balance(node);
        }

        // Удаление элемента из дерева
        public void Remove(int key)
        {
            root = Remove(root, key);
        }

        // Вспомогательный метод для удаления элемента из узла дерева
        private Node Remove(Node node, int key)
        {
            OperationsCount++; // Увеличиваем счетчик операций
            if (node == null) return null;

            // Поиск узла для удаления
            if (key < node.Key)
            {
                node.Left = Remove(node.Left, key);
            }
            else if (key > node.Key)
            {
                node.Right = Remove(node.Right, key);
            }
            else
            {
                // Удаляем узел
                Node left = node.Left;
                Node right = node.Right;

                if (right == null) return left;

                Node min = FindMin(right);
                min.Right = RemoveMin(right);
                min.Left = left;

                return Balance(min);
            }

            // Обновление высоты узла
            node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

            // Балансировка узла
            return Balance(node);
        }

        // Проверка наличия элемента в дереве
        public bool Contains(int key)
        {
            return Contains(root, key);
        }

        // Вспомогательный метод для проверки наличия элемента в узле дерева
        private bool Contains(Node node, int key)
        {
            OperationsCount++; // Увеличиваем счетчик операций
            if (node == null) return false;

            // Поиск элемента в левом или правом поддереве
            if (key < node.Key)
            {
                return Contains(node.Left, key);
            }
            else if (key > node.Key)
            {
                return Contains(node.Right, key);
            }
            else
            {
                // Элемент найден
                return true;
            }
        }

        // Балансировка узла
        private Node Balance(Node node)
        {
            if (node == null) return null;

            // Проверка баланса узла и выполнение соответствующих поворотов
            if (GetBalanceFactor(node) == 2)
            {
                if (GetBalanceFactor(node.Right) < 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                return RotateLeft(node);
            }

            if (GetBalanceFactor(node) == -2)
            {
                if (GetBalanceFactor(node.Left) > 0)
                {
                    node.Left = RotateLeft(node.Left);
                }
                return RotateRight(node);
            }

            return node;
        }

        // Правый поворот
        private Node RotateRight(Node p)
        {
            Node q = p.Left;
            p.Left = q.Right;
            q.Right = p;

            // Обновление высоты узлов
            p.Height = 1 + Math.Max(GetHeight(p.Left), GetHeight(p.Right));
            q.Height = 1 + Math.Max(GetHeight(q.Left), GetHeight(q.Right));

            return q;
        }

        // Левый поворот
        private Node RotateLeft(Node q)
        {
            Node p = q.Right;
            q.Right = p.Left;
            p.Left = q;

            // Обновление высоты узлов
            q.Height = 1 + Math.Max(GetHeight(q.Left), GetHeight(q.Right));
            p.Height = 1 + Math.Max(GetHeight(p.Left), GetHeight(p.Right));
            return p;
        }

        // Получение высоты узла
        private int GetHeight(Node node)
        {
            return node?.Height ?? 0;
        }

        // Получение баланс-фактора узла
        private int GetBalanceFactor(Node node)
        {
            return GetHeight(node.Right) - GetHeight(node.Left);
        }

        // Поиск минимального элемента в дереве
        private Node FindMin(Node node)
        {
            return node.Left != null ? FindMin(node.Left) : node;
        }

        // Удаление минимального элемента из дерева
        private Node RemoveMin(Node node)
        {
            if (node.Left == null) return node.Right;
            node.Left = RemoveMin(node.Left);
            return Balance(node);
        }
    }
}