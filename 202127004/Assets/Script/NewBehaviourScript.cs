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
        Debug.Log(list.Contains(9));
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
    private int count;

    public int Count { get => count; }
    public MyNode<T> First { get => first; }

    public MyLinkedList()
    {
        count = 0;
        first = null;
    }

    public MyLinkedList(T[] values)
    {
        count = values.Length;
        MyNode<T> prevNode = null;
        for (int i = 0; i < count; i++) 
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
        count++;
        return first = new MyNode<T>(value, count != 1 ? first : null);
    }

    public MyNode<T> AddLast(T value)
    {
        count++;
        if (count == 1)
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

    public void AddLast(MyNode<T> node)
    {
        count++;
        if (count == 1)
        {
            first = node;
            return;
        }
        MyNode<T> preNode = first;
        while (preNode.Next != null)
        {
            preNode = preNode.Next;
        }
        preNode.Next = node;
    }

    public void Clear()
    {
        count = 0;
        first = null;
    }

    public bool Contains(T value)
    {
        MyNode<T> node = first;
        bool isTrue = false;
        while (node != null)
        {
            if (node.Value.Equals(value))
            {
                isTrue = true;
                break;
            }
            node = node.Next;
        }
        return isTrue;
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