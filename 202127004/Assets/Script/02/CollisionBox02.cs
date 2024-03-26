using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox02 : MonoBehaviour
{
    void Update()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("bullet02"))
            {
                colliders[i].gameObject.SetActive(false);
            }
        }
    }
}
