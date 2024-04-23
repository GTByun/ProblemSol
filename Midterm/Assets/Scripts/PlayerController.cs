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
    CamState camSt = CamState.front;
    float rotateSpeed = 4;

    enum CamState
    {
        front, left, back, right
    }

    private void Awake()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (camLock)
        {
            aniTime += Time.deltaTime * rotateSpeed;
            if (aniTime > 1)
            {
                aniTime = 1;
                cam.transform.position = new Vector3(-Mathf.Sin(aimAngle.y * Mathf.PI / 180), 1, -Mathf.Cos(aimAngle.y * Mathf.PI / 180)) * 13;
                cam.transform.rotation = Quaternion.Euler(aimAngle);
                camLock = false;
            }
            cam.transform.SetPositionAndRotation(new Vector3(-Mathf.Sin(Mathf.Lerp(nowAngle.y, aimAngle.y, aniTime) * Mathf.PI / 180), 1, -Mathf.Cos(Mathf.Lerp(nowAngle.y, aimAngle.y, aniTime) * Mathf.PI / 180)) * 13, 
                Quaternion.Euler(Vector3.Lerp(nowAngle, aimAngle, aniTime)));

        }
        if (Input.GetKey(KeyCode.W))
        {
            float axis = cam.transform.rotation.eulerAngles.y * -1 + 90;
            transform.Translate(speed * Time.deltaTime * new Vector3(Mathf.Cos(axis * Mathf.PI / 180), 0, Mathf.Sin(axis * Mathf.PI / 180)));
        }
        if (Input.GetKey(KeyCode.D))
        {
            float axis = cam.transform.rotation.eulerAngles.y * -1;
            transform.Translate(speed * Time.deltaTime * new Vector3(Mathf.Cos(axis * Mathf.PI / 180), 0, Mathf.Sin(axis * Mathf.PI / 180)));
        }
        if (Input.GetKey(KeyCode.S))
        {
            float axis = cam.transform.rotation.eulerAngles.y * -1 - 90;
            transform.Translate(speed * Time.deltaTime * new Vector3(Mathf.Cos(axis * Mathf.PI / 180), 0, Mathf.Sin(axis * Mathf.PI / 180)));
        }
        if (Input.GetKey(KeyCode.A))
        {
            float axis = cam.transform.rotation.eulerAngles.y * -1 + 180;
            transform.Translate(speed * Time.deltaTime * new Vector3(Mathf.Cos(axis * Mathf.PI / 180), 0, Mathf.Sin(axis * Mathf.PI / 180)));
        }
        if (Input.GetKey(KeyCode.O) && !camLock) 
        {
            aniTime = 0;
            switch (camSt)
            {
                case CamState.front:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y + 90, camAng.z);
                        camSt = CamState.left;
                        break;
                    }

                case CamState.left:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y + 90, camAng.z);
                        camSt = CamState.back;
                        break;
                    }

                case CamState.back:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y + 90, camAng.z);
                        camSt = CamState.right;
                        break;
                    }

                case CamState.right:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y + 90, camAng.z);
                        camSt = CamState.front;
                        break;
                    }
            }
            camLock = true;

        }
        if (Input.GetKey(KeyCode.P) && !camLock)
        {
            aniTime = 0;
            switch (camSt)
            {
                case CamState.front:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y - 90, camAng.z);
                        camSt = CamState.right;
                        break;
                    }

                case CamState.left:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y - 90, camAng.z);
                        camSt = CamState.front;
                        break;
                    }

                case CamState.back:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y - 90, camAng.z);
                        camSt = CamState.left;
                        break;
                    }

                case CamState.right:
                    {
                        Vector3 camAng = cam.transform.rotation.eulerAngles;
                        nowAngle = camAng;
                        aimAngle = new Vector3(camAng.x, camAng.y - 90, camAng.z);
                        camSt = CamState.back;
                        break;
                    }
            }
            camLock = true;

        }
    }
}
