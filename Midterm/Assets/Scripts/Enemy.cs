using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movingRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Reset()
    {
        movingRange = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.yellow;
        Matrix4x4 trsMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.localScale);

        using (new Handles.DrawingScope(trsMatrix)) 
        {
            Handles.DrawWireDisc(Vector3.zero, Vector3.up, movingRange);
        }
    }
#endif
}
