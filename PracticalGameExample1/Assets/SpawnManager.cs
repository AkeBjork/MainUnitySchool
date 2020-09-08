using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public Transform prefabEnemyA;
    public Transform EnemyParent;

    public float spawnHeight = 4f;
    public Transform spawnHeightObject;
    public Transform spawnLeftObject;
    public Transform spawnRightObject;

    public float spawnRate = 0.5f;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            Spawn(prefabEnemyA);
            timer = 0;
        }


        if (Input.GetMouseButtonDown(0))
        {
            Spawn(prefabEnemyA);
        }
    }

    void Spawn(Transform enemy)
    {
        Instantiate(prefabEnemyA, new Vector3(Random.Range(spawnLeftObject.position.x, spawnRightObject.position.x), spawnHeightObject.position.y, 0), Quaternion.identity, EnemyParent);
    }
}
