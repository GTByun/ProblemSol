using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject bulletObj;
    public ObjectMemoryPull bulletPull;

    private void Awake()
    {
        instance = this;
        bulletPull = gameObject.AddComponent<ObjectMemoryPull>();
        bulletPull.Initiate(bulletObj, 10);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletPull.Spawn();
        }
    }
}
