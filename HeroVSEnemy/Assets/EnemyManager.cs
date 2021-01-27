using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemyTypes;
    [SerializeField]
    private Transform enemyParent;
    [SerializeField]
    private Transform spawnPoint;
    private Enemy[] myEnemies;

    private float timer = 0f;
    private float nextSpawn = 1f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawn)
        {
            timer = 0;
            nextSpawn = Random.Range(0.2f, 2);
            Spawn(Random.Range(0, enemyTypes.Length));
        }

        
    }
    void Spawn(int spawnNumber)
    {
        if (spawnNumber < enemyTypes.Length)
        {
            Instantiate(enemyTypes[spawnNumber], spawnPoint.transform.position, Quaternion.identity,enemyParent);
        }
    }
}
