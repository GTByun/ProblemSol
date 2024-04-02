using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StarPillar : MonoBehaviour
{
    public GameObject myCircle;
    private void Awake()
    {
        Vector3[] dot = new Vector3[20];
        float pi = Mathf.PI / 180;
        Mesh mesh = new Mesh();
        for (int i = 0; i < 2; i++)
        {
            float thisY = 0.5f - i;
            for (int j = 0; j < 5; j++) 
            {
                dot[i * 10 + j] = new Vector3(Mathf.Cos(j * 72 * pi), thisY, Mathf.Sin(j * 72* pi));
            }
            for (int j = 0; j < 5;j++)
            {
                dot[i * 10 + 5 + j] = new Vector3(Mathf.Cos((j * 72 + 36) * pi) / 2, thisY, Mathf.Sin((j * 72 + 36) * pi) / 2);
            }
        }
        mesh.vertices = dot;

        int[] triangles =
        {
            0, 9, 5,
            1, 5, 6,
            2, 6, 7,
            3, 7, 8,
            4, 8, 9,
            8, 7, 6,
            9, 8, 5,
            8, 6, 5,
            10, 15, 19,
            11, 16, 15,
            12, 17, 16,
            13, 18, 17,
            14, 19, 18,
            18, 16, 17,
            19, 15, 18,
            18, 15, 16,
            0, 10, 9,
            10, 19, 9,
            0, 5, 10,
            10, 5, 15,
            1, 11, 5,
            11, 15, 5,
            1, 6, 11,
            11, 6, 16,
            2, 12, 6,
            12, 16, 6,
            2, 7, 12,
            12, 7, 17,
            3, 13, 7,
            13, 17, 7,
            3, 8, 13,
            13, 8, 18,
            4, 14, 8,
            14, 18, 8,
            4, 9, 14,
            14, 9, 19
        };

        mesh.triangles = triangles;

        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;

        


        for (int i = 0; i < 20; i++) 
        {
            Instantiate(myCircle, dot[i], Quaternion.identity);
        }
    }
}