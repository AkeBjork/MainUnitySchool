using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HelpMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject myPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            myPanel.SetActive(!myPanel.activeSelf);
        }
    }
}
