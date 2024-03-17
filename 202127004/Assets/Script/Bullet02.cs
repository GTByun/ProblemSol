using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : MonoBehaviour
{
    private bool first = true;

    private void OnEnable()
    {
        transform.position = Vector3.zero;
    }

    private void OnDisable()
    {
        if (first)
        {
            first = false;
            return;
        }
        GameManager.instance.bulletPull.Despawn(gameObject);
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "RedCube")
        {
            gameObject.SetActive(false);
        }
    }
}
