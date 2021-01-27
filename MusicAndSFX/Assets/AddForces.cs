using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForces : MonoBehaviour
{
    public float force = 10f;
    public bool randomPitch = true;
    // Start is called before the first frame update

    
    void Start()
    {
        //print(transform.TransformDirection(Vector3.down));

        //GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localRotation.x, transform.localRotation.y) * force, ForceMode2D.Force);//
        //GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.forward) * force, ForceMode2D.Force);
        GetComponent<Rigidbody2D>().AddForce(-transform.up * force, ForceMode2D.Impulse);
        if (randomPitch)
        {
            GetComponent<AudioSource>().pitch *= Random.Range(0.7f, 1.3f);
        }


    }


}
