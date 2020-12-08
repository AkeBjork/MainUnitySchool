using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform[] hardPoints;
    public GameObject[] bulletPrefabs;

    private float fireSpeed1 = 0.2f;
    private float fireSpeed2 = 0.5f;
    private float fireTimer1 = 0f;
    private float fireTimer2 = 0f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer1 += Time.deltaTime;
        fireTimer2 += Time.deltaTime;

        if (Input.GetMouseButton(0) && fireTimer1 > fireSpeed1)
        {
            Shoot(0, bulletPrefabs[0]);
            fireTimer1 = 0;
        }

        if (Input.GetMouseButton(1) && fireTimer2 > fireSpeed2)
        {
            Shoot(1, bulletPrefabs[1]);
            fireTimer2 = 0;
        }
    }

    void Shoot(int hardpoint, GameObject prefab)
    {
        GameObject go = Instantiate(prefab, hardPoints[hardpoint].position, transform.rotation);
    }

}
