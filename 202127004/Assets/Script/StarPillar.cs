using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public partial class StarPillar : MonoBehaviour
{
    public Material material;
    public bool dotNormals;
    private void Awake()
    {
        Vector3[] dot = new Vector3[20];
        float pi = Mathf.PI / 180;
        Mesh mesh = new();
        for (int i = 0; i < 2; i++)
        {
            float thisY = 0.5f - i;
            for (int j = 0; j < 5; j++)
            {
                dot[i * 10 + j] = new Vector3(Mathf.Cos(j * 72 * pi), thisY, Mathf.Sin(j * 72 * pi));
            }
            for (int j = 0; j < 5; j++)
            {
                dot[i * 10 + 5 + j] = new Vector3(Mathf.Cos((j * 72 + 36) * pi) / 2, thisY, Mathf.Sin((j * 72 + 36) * pi) / 2);
            }
        }
        mesh.vertices = dot;

        int[,] dotList = { 
            { 4, 0, 1, 2, 3, 4, 0 }, 
            { 9, 5, 6, 7, 8, 9, 5 }, 
            { 14, 10, 11, 12, 13, 14, 10 }, 
            { 19, 15, 16, 17, 18, 19, 15 } };

        Face[] faceList = new Face[36];
        for (int i = 0; i < faceList.Length; i++)
        {
            faceList[i].dot = new int[3];
        }

        int faceNum = 0;

        for (int i = 0; i < 5; i++)
        {
            faceList[faceNum].Dot3Set(dotList[1, i + 1], dotList[0, i + 1], dotList[1, i]);
            faceNum++;
        }

        for (int i = 0; i < 5; i++)
        {
            faceList[faceNum].Dot3Set(dotList[3, i + 1], dotList[2, i + 2], dotList[3, i + 2]);
            faceNum++;
        }

        int[] fivePoly = new int[9];
        fivePoly[0] = 8; fivePoly[1] = 6; fivePoly[2] = 5; fivePoly[3] = 5; fivePoly[4] = 9; fivePoly[5] = 8; fivePoly[6] = 8; fivePoly[7] = 7; fivePoly[8] = 6;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                faceList[faceNum].dot[j] = fivePoly[i * 3 + j];
            }
            faceNum++;
        }

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                faceList[faceNum].dot[j] = fivePoly[8 - (i * 3 + j)] + 10;
            }
            faceNum++;
        }

        for (int i = 0; i < 5; i++)
        {
            faceList[faceNum].Dot3Set(dotList[2, i + 1], dotList[1, i], dotList[0, i + 1]);
            faceNum++;
            faceList[faceNum].Dot3Set(dotList[1, i], dotList[2, i + 1], dotList[3, i]);
            faceNum++;
            faceList[faceNum].Dot3Set(dotList[0, i + 1], dotList[1, i + 1], dotList[2, i + 1]);
            faceNum++;
            faceList[faceNum].Dot3Set(dotList[3, i + 1], dotList[2, i + 1], dotList[1, i + 1]);
            faceNum++;
        }

        if (dotNormals)
        {
            Vector3[] normals = new Vector3[20];

            for (int i = 0; i < normals.Length; i++)
            {
                MyQueue<Face> faceQueue = new();
                int dotFaceNum = 0;

                for (int j = 0; j < faceList.Length; j++)
                {
                    if (faceList[j].DotInclude(i))
                    {
                        faceQueue.Enqueue(faceList[j]);
                        dotFaceNum++;
                    }
                }

                Vector3[] dotNormals = new Vector3[dotFaceNum];
                for (int j = 0; j < dotNormals.Length; j++)
                {
                    Face dotFace = faceQueue.Dequeue();
                    int[] twoPoints = dotFace.FirstThis(i);
                    Vector3 side1 = dot[twoPoints[0]] - dot[i];
                    Vector3 side2 = dot[twoPoints[1]] - dot[i];
                    dotNormals[j] = Vector3.Cross(side1, side2).normalized;

                }
                dotNormals = dotNormals.Distinct().ToArray();
                Vector3 dotNormalsSum = Vector3.zero;
                for (int j = 0; j < dotNormals.Length; j++)
                {
                    dotNormalsSum += dotNormals[j];
                }
                dotNormalsSum.Normalize();

                normals[i] = dotNormalsSum;
            }

            mesh.normals = normals;
        }
        else
        {
            mesh.normals = dot;
        }
        

        int[] triangles = new int[faceList.Length * 3];

        for (int i = 0; i < faceList.Length; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                triangles[i * 3 + j] = faceList[i].dot[j];
            }
        }

        mesh.triangles = triangles;


        MeshFilter mf = this.AddComponent<MeshFilter>();
        MeshRenderer mr = this.AddComponent<MeshRenderer>();

        mf.mesh = mesh;


        mr.material = material;
    }
}