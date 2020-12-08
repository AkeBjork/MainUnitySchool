using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KeyCode pauseButton = KeyCode.P;
    private CursorManager cursorManager;
    public bool manageCursor = true;

    // Start is called before the first frame update
    void Start()
    {
        if (manageCursor)
        {
            cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            if (manageCursor)
            {
                cursorManager.SetVisible(true);
            }
            transform.Find("canvasPauseMenu").gameObject.SetActive(true);
        }
    }
}
