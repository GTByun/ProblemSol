using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager04 : MonoBehaviour
{
    public ObjectMemoryPull04 bulletPull;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bulletPull.Spawn();
        }
    }
}
