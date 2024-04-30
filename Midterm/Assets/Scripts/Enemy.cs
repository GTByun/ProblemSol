using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movingRange;
    private Vector3 center;
    private Camera vision;
    private Object player;

    private void Awake()
    {
        transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        center = transform.position;
        vision = gameObject.GetComponent<Camera>();
        
    }

    private void Reset()
    {
        movingRange = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(5 * Time.deltaTime * Vector3.forward);
        if (Vector3.Distance(transform.position, center) > movingRange) 
        {
            Vector3 angle = transform.position - center;
            angle.Normalize();
            transform.rotation = Quaternion.Euler(0, -Mathf.Atan2(angle.z, angle.x) * 180 / Mathf.PI - Random.Range(0, 180), 0);
        }
        if (transform.position.x > 15)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(180, 360), 0);
        }
        if (transform.position.x < -15)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 180), 0);
        }
        if (transform.position.z > 15)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(90, 270), 0);
        }
        if (transform.position.z < -15)
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(-90, 90), 0);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        Matrix4x4 trsMatrix = Matrix4x4.TRS(center == Vector3.zero ? transform.position : center, transform.rotation, transform.localScale) ;

        using (new Handles.DrawingScope(trsMatrix)) 
        {
            Handles.DrawWireDisc(Vector3.zero, Vector3.up, movingRange);
        }
    }
#endif
}
