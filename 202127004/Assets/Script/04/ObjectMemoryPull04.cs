using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMemoryPull04 : MonoBehaviour
{
    private MyStack<GameObject> stack;
    private int count;
    public GameObject pullObj;
    public int spawnCount;

    private void Awake()
    {
        count = 0;
        GameObject[] values = new GameObject[spawnCount];
        for (int i = 0; i < values.Length; i++)
        {
            values[i] = Instantiate(pullObj, Vector3.zero, Quaternion.identity);
            values[i].transform.SetParent(transform);
            values[i].SetActive(false);
            count++;
        }
        stack = new MyStack<GameObject>(values);
    }

    public GameObject Spawn()
    {
        if (count == 0)
        {
            return null;
        }
        count--;
        GameObject obj = stack.Pop();
        obj.SetActive(true);
        return obj;
    }

    public void Despawn(GameObject obj)
    {
        count++;
        stack.Push(obj);
    }
}
