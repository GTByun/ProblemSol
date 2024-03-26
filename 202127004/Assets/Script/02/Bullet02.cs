using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : MonoBehaviour
{
    private bool first = true;
    public float speed;
    public ObjectMemoryPull02 parentPull;

    private void OnDisable()
    {
        if (first)
        {
            first = false;
            return;
        }
        parentPull.Despawn(gameObject);
        transform.position = Vector3.zero;

    }

    private void Start()
    {
        parentPull = transform.parent.gameObject.GetComponent<ObjectMemoryPull02>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
