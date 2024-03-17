using UnityEngine;

public class MyQueue<T>
{
    private readonly MyLinkedList<T> queue;

    public MyQueue()
    {
        queue = new MyLinkedList<T>();
    }

    public MyQueue(T[] values)
    {
        queue = new MyLinkedList<T>(values);
    }

    public void Enqueue(T value)
    {
        queue.AddLast(value);
    }

    public T Dequeue()
    {
        T value = queue.First.Value;
        queue.RemoveFirst();
        return value;
    }

    public void Print()
    {
        queue.Print();
    }
}
