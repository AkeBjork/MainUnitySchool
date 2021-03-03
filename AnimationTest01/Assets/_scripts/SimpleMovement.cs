using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private float horizontalMovement = 0f;
    private float verticalMovement = 0f;
    private float movementSpeed = 10f;
    private float currenSpeed;
    private float rotationSpeed = 200f;
    private float runSpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        currenSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        verticalMovement = Input.GetAxis("Vertical") * currenSpeed * Time.deltaTime;


        transform.Translate(verticalMovement, 0, 0);

        // Rotate around our y-axis
        transform.Rotate(0, horizontalMovement, 0);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Run(true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Run(false);
        }
    }

    void Run(bool running)
    {
        if (running)
        {
            currenSpeed *= runSpeed;
        }
        else
        {
            currenSpeed = movementSpeed;
        }
    }

}
