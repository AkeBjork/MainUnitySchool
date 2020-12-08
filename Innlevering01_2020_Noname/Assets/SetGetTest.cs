using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetGetTest : MonoBehaviour
{
    private int tall1 = 3;

    public TextMeshProUGUI txtTest;


    // Start is called before the first frame update
    void Start()
    {
        SetTall1(5);

        txtTest.text = "" + GetTall1();

    }


    public int GetTall1()
    {
        return tall1;
    }

    public void SetTall1(int value)
    {
        tall1 = value;
    }


}
