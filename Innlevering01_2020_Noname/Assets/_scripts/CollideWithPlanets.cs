using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollideWithPlanets : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<WhenDestroyed>().PlayDestroyAnimation();
    }
}
