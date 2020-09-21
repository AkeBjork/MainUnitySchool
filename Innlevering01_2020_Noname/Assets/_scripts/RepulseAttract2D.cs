using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulseAttract2D : MonoBehaviour
{
    private Animator animator;
    private PointEffector2D pointEffector2D;
    private float effectorMagnitude = 20;

    // Start is called before the first frame update
    void Start()
    {
        pointEffector2D = GetComponent<PointEffector2D>();
        animator = transform.parent.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //Attract
        if (Input.GetMouseButton(0))
        {
            animator.SetFloat("ForceMode", 1f);
            pointEffector2D.forceMagnitude = -effectorMagnitude;
        }
        //Repulse
        else if (Input.GetMouseButton(1))
        {
            animator.SetFloat("ForceMode", -1f);
            pointEffector2D.forceMagnitude = effectorMagnitude;
        }
        //Hide sprite, no force
        else
        {
            animator.SetFloat("ForceMode", 0f);
            pointEffector2D.forceMagnitude = 0;
        }
    }


    void AttractObjects()
    {

    }
    void RepulseObjects()
    {

    }
}
