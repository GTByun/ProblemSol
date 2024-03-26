using System;
using UnityEngine;

public class MyLinkedList<T>
{
    private MyNode<T> first;

    public MyNode<T> First { get => first; }

    public MyLinkedList()
    {
        first = null;
    }

    public MyLinkedList(T[] values)
    {
        if (values == null)
        {
            throw new ArgumentNullException(nameof(values));
        }
        first = new(values[0], null);
        MyNode<T> prevNode = first;
        for (int i = 1; i < values.Length; i++)
        {
            MyNode<T> node = new(values[i], null);
            prevNode.Next = node;
            prevNode = node;
        }
    }

    public MyNode<T> AddFirst(T value)
    {
        return first = new MyNode<T>(value, first ?? null);
    }

    public MyNode<T> AddLast(T value)
    {
        if (first == null)
        {
            return first = new MyNode<T>(value, null);
        }
        MyNode<T> node = first;
        while (node.Next != null)
        {
            node = node.Next;
        }
        return node.Next = new(value, null);
    }

    public void Clear()
    {
        first = null;
    }

    public void RemoveFirst()
    {
        if (first == null)
        {
            throw new InvalidOperationException();
        }
        first = first.Next ?? null;
    }

    public void RemoveLast()
    {
        if (first == null)
        {
            throw new InvalidOperationException();
        }
        if (first.Next == null)
        {
            first = null;
            return;
        }
        MyNode<T> node = first;
        while (node.Next.Next != null)
        {
            node = node.Next;
        }
        node.Next = null;
    }

    public void Print()
    {
        MyNode<T> node = first;
        while (node != null)
        {
            Debug.Log(node.Value);
            node = node.Next;
        }
    }
}
