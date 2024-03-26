using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager02 : MonoBehaviour
{
    public GameObject bulletObj;
    public ObjectMemoryPull02 bulletPull;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletPull.Spawn();
        }
    }
}
