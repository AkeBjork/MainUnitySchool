using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public KeyCode pauseButton = KeyCode.P;
    private CursorManager cursorManager;

    // Start is called before the first frame update
    void Start()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(pauseButton))
        {
            cursorManager.SetVisible(true);
            transform.Find("canvasPauseMenu").gameObject.SetActive(true);
        }
    }
}
