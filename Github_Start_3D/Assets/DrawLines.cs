using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLines : MonoBehaviour
{


    public Transform[] myPoints;
    Vector3[] myVectorPoints;

    Mesh mesh;
    MeshRenderer meshRenderer;
    int[] triangles;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        myVectorPoints = new Vector3[myPoints.Length + 1];
        for (int i = 0; i < myPoints.Length; i++)
        {
            myVectorPoints[i] = myPoints[i].position;
            print(myVectorPoints[i]);
        }

        Draw();

    }
    private void Draw()
    {
        mesh.Clear();
        /*
        for (int i = 0; i < myPoints.Length; i++)
        {
            int nextPoint = i+1;
            if (nextPoint >= myPoints.Length)
            {
                nextPoint = 0;
            }
            */
            LineRenderer lineRenderer = GetComponent<LineRenderer>();
           // lineRenderer.SetPositions(myVectorPoints);
        //. (myPoints[0].position, myPoints[nextPoint].position);


        lineRenderer.positionCount = myVectorPoints.Length;
        for (int i = 0; i < myVectorPoints.Length; i++)
        {
            lineRenderer.SetPosition(i, myVectorPoints[i]);
        }
        lineRenderer.SetPosition(myVectorPoints.Length-1, myVectorPoints[0]);

        mesh.vertices = myVectorPoints;
        triangles = new int[] { 0, 1, 2 };
        mesh.triangles = triangles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
