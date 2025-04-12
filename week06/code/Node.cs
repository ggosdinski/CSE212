public class Node
{
    public int Data { get; set; }
    public Node? Right { get; private set; }
    public Node? Left { get; private set; }

    public Node(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // Evitar duplicados
        if (value == Data)
        {
            return; // No insertar el valor duplicado
        }

        if (value < Data)
        {
            // Insertar a la izquierda
            if (Left is null)
                Left = new Node(value);
            else
                Left.Insert(value);
        }
        else
        {
            // Insertar a la derecha
            if (Right is null)
                Right = new Node(value);
            else
                Right.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        if (value == Data)
            return true; // Encontrado el valor

        if (value < Data)
            return Left?.Contains(value) ?? false; // Buscar en el subárbol izquierdo

        return Right?.Contains(value) ?? false; // Buscar en el subárbol derecho
    }

    public int GetHeight()
    {
        // Si no hay subárbol izquierdo ni derecho, la altura es 1
        int leftHeight = Left?.GetHeight() ?? 0;
        int rightHeight = Right?.GetHeight() ?? 0;

        // La altura es 1 (el nodo actual) + el máximo de las alturas de los subárboles izquierdo y derecho
        return 1 + Math.Max(leftHeight, rightHeight);
    }
}
