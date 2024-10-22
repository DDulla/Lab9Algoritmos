using System;

public class SimpleLinkedList<T>
{
    private class Node
    {
        public T Value { get; set; }
        public Node Next { get; set; }
        public Node(T value)
        {
            Value = value;
            Next = null;
        }
    }

    private Node Head { get; set; }
    private Node Tail { get; set; }
    private int Count { get; set; }

    public void InsertAtEnd(T value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }
        Count++;
    }

    public T GetAtPosition(int position)
    {
        if (position < 0 || position >= Count)
            throw new IndexOutOfRangeException("Invalid position");
        Node currentNode = Head;
        for (int i = 0; i < position; i++)
        {
            currentNode = currentNode.Next;
        }
        return currentNode.Value;
    }

    public int GetCount()
    {
        return Count;
    }

    public void Clear()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }
}
