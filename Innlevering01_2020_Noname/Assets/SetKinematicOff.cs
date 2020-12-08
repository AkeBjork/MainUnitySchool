using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetKinematicOff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetInactive", 0.1f);
    }

    // Update is called once per frame
    void SetInactive()
    {
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
