using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet04 : MonoBehaviour
{
    private bool first = true;
    public float speed;
    private ObjectMemoryPull04 parentPull;

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
        parentPull = transform.parent.gameObject.GetComponent<ObjectMemoryPull04>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right);
    }
}
