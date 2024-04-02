using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyStack<T>
{
    private MyQueue<T> stack;
    private int count;

    public MyStack()
    {
        stack = new MyQueue<T>();
        count = 0;
    }

    public MyStack(T[] values)
    {
        stack = new MyQueue<T>(values);
        count = values.Length;
    }

    public void Push(T value)
    {
        stack.Enqueue(value);
        count++;
    }

    public T Pop()
    {
        if (count == 0)
        {
            throw new InvalidOperationException();
        }
        T[] array = new T[count - 1];
        for (int i = 0; i < count - 1; i++)
        {
            array[i] = stack.Dequeue();
        }
        T ret = stack.Dequeue();
        for (int i = 0;i < count - 1; i++)
        {
            stack.Enqueue(array[i]);
        }
        count--;
        return ret;
    }
}
