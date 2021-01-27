using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetButtonHitAlpha : MonoBehaviour
{

    [SerializeField]
    private float treshold = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = treshold;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<Image>().alphaHitTestMinimumThreshold = treshold;
        }


    }

}
