using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    int speed = 5;
    private Camera cam;
    bool camLock = false;
    Vector3 nowAngle;
    Vector3 aimAngle;
    float aniTime;

    private void Awake()
    {
        cam = Camera.main;
        aniTime = 0;
    }

    void Moving(KeyCode key, float axis)
    {
        if (Input.GetKey(key))
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, axis, transform.rotation.eulerAngles.z);
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
    }

    void AngleAnimeStart(KeyCode key, float angle)
    {
        if (Input.GetKeyDown(key) && !camLock)
        {
            Vector3 camAng = cam.transform.rotation.eulerAngles;
            nowAngle = camAng;
            aimAngle = new Vector3(camAng.x, camAng.y + angle, camAng.z);
            camLock = true;
        }
    }

    void Update()
    {
        float camRotationY = cam.transform.rotation.eulerAngles.y;
        float radPi = Mathf.PI / 180;
        Vector3 camBasePos = new Vector3(-Mathf.Sin(camRotationY * radPi), 1, -Mathf.Cos(camRotationY * radPi)) * 13;
        cam.transform.position = camBasePos + gameObject.transform.position;
        if (camLock)
        {
            aniTime += Time.deltaTime;
            aniTime = Mathf.Max(aniTime, 1);
            cam.transform.rotation = Quaternion.Euler(Vector3.Lerp(nowAngle, aimAngle, aniTime));
            if (aniTime > 1)
            {
                cam.transform.rotation = Quaternion.Euler(aimAngle);
                camLock = false;
                aniTime = 0;
            }
            
        }
        Moving(KeyCode.W, camRotationY);
        Moving(KeyCode.D, camRotationY + 90);
        Moving(KeyCode.S, camRotationY + 180);
        Moving(KeyCode.A, camRotationY + 270);
        AngleAnimeStart(KeyCode.O, 90);
        AngleAnimeStart(KeyCode.P, -90);
    }
}
