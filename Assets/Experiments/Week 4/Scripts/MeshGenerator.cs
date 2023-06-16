using UnityEngine;
using static UnityEngine.Mathf;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    [SerializeField, Range(1, 300)]
    int zSize = 100, xSize = 100;

    [SerializeField]
    ProceduralMeshFunctionLibrary.FunctionName function;

    void Start()
    {
        mesh = new Mesh{
            name = "Procedural Mesh"
        };
        GetComponent<MeshFilter>().mesh = mesh;
        CreateShape();
        UpdateMesh();
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    void Update()
    {
    }

    void CreateShape()
    {
        ProceduralMeshFunctionLibrary.Function f = ProceduralMeshFunctionLibrary.GetFunction(function);

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];

        for(int z = 0, i = 0; z <= zSize; z++) {
            for(int x = 0; x <= xSize; x++) {
                float u = (float)z / (float)zSize;
                float v = (float)x / (float)xSize;
                vertices[i] = f(u, v);
                i++;
            }
        }

        triangles = new int [xSize * zSize * 6];
        int vert = 0;
        int tris = 0;
        for(int z = 0; z < zSize; z++) {
            for(int x = 0; x < xSize; x++) {
                int i = z * xSize + x + z;
                triangles[tris] = vert;
                triangles[tris+1] = vert + xSize + 1;
                triangles[tris+2] = vert + 1;
                triangles[tris+3] = vert + xSize + 1;
                triangles[tris+4] = vert + xSize + 2;
                triangles[tris+5] = vert + 1;

                vert++;
                tris+=6;
            }
            vert++;
        }
        
    }
    
    void UpdateMesh()
    {
        mesh.Clear();
        
        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
