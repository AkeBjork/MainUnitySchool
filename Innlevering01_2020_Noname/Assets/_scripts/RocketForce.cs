using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketForce : MonoBehaviour
{
    private float speed = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        StartEngine();
    }

    public void StartEngine()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * speed;
    }

    public void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
