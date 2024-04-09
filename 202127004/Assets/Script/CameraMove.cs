using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public int speed;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.right);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.left);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.back);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(25 * speed * Time.deltaTime * new Vector3(0, -1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(25 * speed * Time.deltaTime * new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.up);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(speed * Time.deltaTime * Vector3.down);
        }
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(25 * speed * Time.deltaTime * new Vector3(1, 0, 0));
        }
        if (Input.GetKey(KeyCode.X))
        {
            transform.Rotate(25 * speed * Time.deltaTime * new Vector3(-1, 0, 0));
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
