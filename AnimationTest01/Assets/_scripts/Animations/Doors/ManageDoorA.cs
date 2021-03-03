using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageDoorA : MonoBehaviour
{
    private Animator doorAAnimator;
    private float currentTime;
    private float timeCheck = 0.5f;
    private void OnTriggerEnter(Collider other)
    {
        //print("Enter");

        if (Time.timeSinceLevelLoad > currentTime + timeCheck)
        {
            print(currentTime + " Enter " + Time.timeSinceLevelLoad + timeCheck);
            doorAAnimator.SetTrigger("OpenDoor");
            currentTime = Time.timeSinceLevelLoad;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (Time.timeSinceLevelLoad > currentTime + timeCheck)
        {
            print(currentTime + " Exit " + Time.timeSinceLevelLoad + timeCheck);
            doorAAnimator.SetTrigger("CloseDoor");
            currentTime = Time.timeSinceLevelLoad;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        doorAAnimator = GetComponent<Animator>();
        currentTime = timeCheck;
    }
}
