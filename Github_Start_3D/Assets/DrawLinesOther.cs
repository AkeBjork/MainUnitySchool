using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLinesOther : MonoBehaviour
{


    //public Transform[] myPoints;
    public Vector3[] myVectorPoints;

    Mesh mesh;
    MeshRenderer meshRenderer;
    int[] triangles;
    UnityEngine.Plane plane;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;



        Draw();

    }
    private void Draw()
    {
        mesh.Clear();
        

        plane = new UnityEngine.Plane(new Vector3(1,0,0), new Vector3(0,1,0), new Vector3(0,0,1));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
