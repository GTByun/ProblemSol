using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public float speed;

    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed * -1.0f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + speed * 1.0f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.I))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + speed * 1.0f * Time.deltaTime, transform.eulerAngles.y, 0);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x + speed * -1.0f * Time.deltaTime, transform.eulerAngles.y, 0);
        }
    }
}
