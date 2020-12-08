using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCubes : MonoBehaviour
{
    public GameObject cubePrefab;
    public Transform spawnPoint;
    public Slider spawnSlider;
    public Slider spreadSlider;

    private float automationIndex = 0;
    private float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (automationIndex > 0 && timer > automationIndex/60)
        {
            
            SpawnCube();
            timer = 0f;
        }
    }

    public void SpawnCube()
    {
        Instantiate(cubePrefab, spawnPoint.position, Quaternion.identity);
    }

    public void Automate(int value)
    { 
        
    }
}
