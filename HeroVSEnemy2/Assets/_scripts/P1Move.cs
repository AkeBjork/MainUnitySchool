using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Move : MonoBehaviour
{
    private Hero p1;
    private KeyCode jumpButton = KeyCode.Space;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        p1 = GetComponent<HeroManager>().GetHero(1);
        rigidbody = p1.HeroTransform.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpButton) && p1.CurrentAvailableJumpCount > 0)
        {
            Jump();

        }
    }

    void Jump()
    {
        p1.CurrentAvailableJumpCount--;
        rigidbody.AddForce(0, p1.JumpForce, 0, ForceMode.Impulse);
    }
}
