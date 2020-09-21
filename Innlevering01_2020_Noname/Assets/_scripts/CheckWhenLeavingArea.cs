using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWhenLeavingArea : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<WhenDestroyed>().PlayDestroyAnimation();
    }
}
