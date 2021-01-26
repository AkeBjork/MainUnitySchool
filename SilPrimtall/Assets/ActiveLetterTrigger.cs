using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActiveLetterTrigger : MonoBehaviour
{
    private Color32 startColor = new Color32(255,255,255,255);
    private Color32 highlightColor = new Color32(255, 100, 100, 255);
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //print("CollideIn");
        collision.GetComponentInChildren<TextMeshProUGUI>().color = highlightColor;    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponentInChildren<TextMeshProUGUI>().color = startColor;
        //print("CollideOut");
    }
}
