using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class MyQueue<T>
{
    public T[] array;
    public int size;

    public MyQueue()
    {
        size = 0;
        array = new T[10];
    }

    public MyQueue(T[] array)
    {
        size = array.Length;
        this.array = array;
    }

    public MyQueue(int count)
    {
        size = 0;
        array = new T[count];
    }

    public void Enqueue() { }
}