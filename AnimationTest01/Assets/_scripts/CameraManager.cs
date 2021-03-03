using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private Camera[] myCameras;
    private int currentCamera = 0;

    private void Start()
    {
        //Sets default camera
        ChangeCamera(0);    
    }

    private void Update()
    {
        //Not a good way to do it, users can't change keys. But fast :p
        if (Input.GetKeyDown(KeyCode.O))
        {
            CycleCameraUP();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            CycleCameraDOWN();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChangeCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ChangeCamera(1);
        }

    }

    //Set directly active camera
    public void ChangeCamera(int newCamera)
    {
        if (newCamera >= myCameras.Length)
        {
            return;
        }
        currentCamera = newCamera;
        
        for (int i = 0; i < myCameras.Length; i++)
        {
            if (newCamera == i)
            {
                myCameras[i].gameObject.SetActive(true);
            }
            else
            {
                myCameras[i].gameObject.SetActive(false);
            }
        }
    }

    //Cycle through camera array
    public void CycleCameraUP()
    {
        currentCamera++;
        if (currentCamera >= myCameras.Length)
        {
            currentCamera = 0;
        }
        ChangeCamera(currentCamera);
    }
    //Cycle through camera array reversed
    public void CycleCameraDOWN()
    {
        currentCamera--;
        if (currentCamera < 0)
        {
            currentCamera = myCameras.Length-1;
        }
        ChangeCamera(currentCamera);
    }
}
