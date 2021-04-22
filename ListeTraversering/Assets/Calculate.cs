using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calculate : MonoBehaviour
{
    private int timer = 0;
    [SerializeField]
    private TextMeshProUGUI txtTimer;

    //Antall sekunder det skal telles
    [SerializeField]
    private int n = 1;
    void Update()
    {
        //teller opp fra 0 til en under n
        timer = (int)Time.time % n;
        
        //teller ned fra n til 1. 
        //timer =n -( (int)Time.time % n);
        txtTimer.text = timer.ToString();
            
    }

}
