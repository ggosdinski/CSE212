public static class Trees
{
    public static BinarySearchTree CreateTreeFromSortedList(int[] sortedNumbers)
    {
        var bst = new BinarySearchTree();
        InsertMiddle(sortedNumbers, 0, sortedNumbers.Length - 1, bst);
        return bst;
    }

    private static void InsertMiddle(int[] sortedNumbers, int first, int last, BinarySearchTree bst)
    {
        if (first > last)
            return; // Caso base: si no hay más elementos para insertar, termina la recursión

        int mid = (first + last) / 2; // Encontramos el valor medio
        bst.Insert(sortedNumbers[mid]); // Insertamos el valor medio en el árbol

        // Recursión para insertar los elementos de la mitad izquierda y derecha
        InsertMiddle(sortedNumbers, first, mid - 1, bst);
        InsertMiddle(sortedNumbers, mid + 1, last, bst);
    }
}
