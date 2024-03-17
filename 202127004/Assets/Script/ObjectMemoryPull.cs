using System;
using UnityEngine;

public class ObjectMemoryPull : MonoBehaviour
{
    private MyQueue<GameObject> queue;
    private int count;

    public void Initiate(GameObject type, int count)
    {
        this.count = count;
        GameObject[] values = new GameObject[count];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Instantiate(type, Vector3.zero, Quaternion.identity);
        }
        queue = new MyQueue<GameObject>(values);
    }

    public GameObject Spawn()
    {
        if (count == 0) { return null; }
        count--;
        GameObject obj = queue.Dequeue();
        obj.SetActive(true);
        return obj;
    }

    public void Despawn(GameObject obj)
    {
        count++;
        queue.Enqueue(obj);
    }
}