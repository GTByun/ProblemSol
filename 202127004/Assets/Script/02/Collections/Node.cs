using UnityEngine;

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
}
