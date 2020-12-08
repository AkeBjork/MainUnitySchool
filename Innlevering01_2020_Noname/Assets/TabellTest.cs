using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabellTest : MonoBehaviour
{
    public List<int> myList = new List<int>();
    float time;

    void Start()
    {
        time = Time.time;



        for (int i = 0; i < 10000; i++)
        {
            LeggTilTall(LagRandomTall(-5000,5000));

        }
        print(Time.time);

    }

    //Lag en metode som tar imot et tall 
    //og legger til tallet i slutten av listen over

    void LeggTilTall(int nyttTall)
    {
        myList.Add(nyttTall);
    }

    int LagRandomTall(int nedreTall, int ovreTall)
    {
        return Random.Range(nedreTall, ovreTall);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
