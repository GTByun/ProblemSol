using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    MyLinkedList<int> list = new();
    // Start is called before the first frame update
    void Start()
    {
        list.AddFirst(1);
        list.AddLast(0);
        list.AddLast(2);
        list.AddLast(3);
        list.AddFirst(9);
        list.Print();
        list.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class MyNode<T>
{
    private T value;
    private MyNode<T> next;

    public T Value { get => value; set => this.value = value; }
    public MyNode<T> Next { get => next; set => next = value; }
    
    public MyNode(T value, MyNode<T> next)
    {
        this.value = value;
        this.next = next;
    }

    ~MyNode()
    {
        Debug.Log(value.ToString() + " ªË¡¶");
    }
}

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
        MyNode<T> prevNode = null;
        for (int i = 0; i < values.Length; i++) 
        {
            MyNode<T> node = new(values[i], null);
            if (prevNode == null)
            {
                first = node;
            }
            else
            {
                prevNode.Next = node;
            }
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
        MyNode<T> lastNode = new(value, null);
        node.Next = lastNode;
        return lastNode;
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
        MyNode<T> node = first.Next;
        first = node ?? null;
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