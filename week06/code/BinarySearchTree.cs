using System.Collections;
using System.Collections.Generic;

public class BinarySearchTree : IEnumerable<int>
{
    private Node? _root;

    public void Insert(int value)
    {
        Node newNode = new(value);
        if (_root is null)
        {
            _root = newNode;
        }
        else
        {
            _root.Insert(value);
        }
    }

    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    // Cambiar el tipo de retorno a IEnumerator<int>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    // Método privado para recorrer el árbol en orden (in-order)
    private void TraverseForward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    // Recorrido inverso (de mayor a menor)
    private void TraverseBackward(Node? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);  // Primero recorremos el subárbol derecho
            values.Add(node.Data);
            TraverseBackward(node.Left, values);   // Luego el subárbol izquierdo
        }
    }

    // Implementar Reverse para recorrer en orden inverso
    public IEnumerable<int> Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    // Método para obtener la altura del árbol
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    // Sobreescribir ToString para mostrar el árbol de forma legible
    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";
    }

    // Implementación del método IEnumerable.GetEnumerator() para que sea compatible
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
