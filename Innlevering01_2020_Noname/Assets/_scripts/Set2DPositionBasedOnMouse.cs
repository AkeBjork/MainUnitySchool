using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Set2DPositionBasedOnMouse : MonoBehaviour
{
    private Vector3 mousePos;
    private float moveSpeed = 20f;
    private bool hidden = true;
    private bool alwaysOn = true;


    // Update is called once per frame
    void Update()
    {
        //Beregner hvor musen er når venstre eller høyre museknapp er nedtrykket
        if (alwaysOn || Input.GetMouseButton(0) || Input.GetMouseButton(1))
        {
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            transform.position = Vector2.Lerp(transform.position, mousePos, moveSpeed);
        }
        else 
        {
            //Trenger ikke flytte spriten lengre. Setter alpha til 0 på animasjonen
            //transform.position = new Vector2(-10000,0);
        }
    }
}
