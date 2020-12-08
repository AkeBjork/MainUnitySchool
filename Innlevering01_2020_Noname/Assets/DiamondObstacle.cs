using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondObstacle : MonoBehaviour
{
    private Color origColor;
    private Color newColor;
    public Material[] rend;
    public Mesh mesh;

    // Start is called before the first frame update
    void Start()
    {
        origColor = Color.green;
        newColor = Color.red;

        Material[] curMaterial = GetComponent<Renderer>().materials;
        curMaterial[1].color = newColor;
        curMaterial[1].SetColor("_EmissionColor", newColor);

        GetComponent<Renderer>().materials = curMaterial;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
