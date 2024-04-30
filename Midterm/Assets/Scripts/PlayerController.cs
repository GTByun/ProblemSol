using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private int speed = 5;
    private Camera cam;
    bool camLock = false;
    Vector3 nowAngle;
    Vector3 aimAngle;
    float aniTime;
    Vector3 moveVector;

    private void Awake()
    {
        cam = Camera.main;
        aniTime = 0;
    }

    void Moving(KeyCode key, float axis)
    {
        if (Input.GetKey(key))
        {
            //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, axis, transform.rotation.eulerAngles.z));
            moveVector += new Vector3(Mathf.Sin(axis / 180 * Mathf.PI), 0, Mathf.Cos(axis / 180 * Mathf.PI));
        }
    }

    void AngleAnimeStart(KeyCode key, float angle)
    {
        if (Input.GetKeyDown(key) && !camLock)
        {
            Vector3 camAng = cam.transform.rotation.eulerAngles;
            nowAngle = camAng;
            aimAngle = new Vector3(camAng.x, camAng.y + angle, camAng.z);
            aniTime = 0;
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
            cam.transform.rotation = Quaternion.Euler(Vector3.Lerp(nowAngle, aimAngle, aniTime));
            if (aniTime > 1)
            {
                cam.transform.rotation = Quaternion.Euler(aimAngle);
                camLock = false;
                aniTime = 0;
            }
            
        }
        moveVector = Vector3.zero;
        Moving(KeyCode.A, camRotationY);
        Moving(KeyCode.W, camRotationY + 90);
        Moving(KeyCode.D, camRotationY + 180);
        Moving(KeyCode.S, camRotationY + 270);
        if (moveVector != Vector3.zero) 
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -Mathf.Atan2(moveVector.z, moveVector.x) * 180 / Mathf.PI, transform.rotation.eulerAngles.z);
            transform.Translate(speed * Time.deltaTime * Vector3.forward);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -15, 15), 1, Mathf.Clamp(transform.position.z, -15, 15));
        AngleAnimeStart(KeyCode.O, 90);
        AngleAnimeStart(KeyCode.P, -90);
    }
}
