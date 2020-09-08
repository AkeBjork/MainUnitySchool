using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private int numberOne = 11;
    private int numberTwo = 2;

    private float var1 = 100f;
    private float var2 = 100f;

    private string string1 = "Noe annet ";
    private string string2 = "navn ";
    private string string3 = "er";

    private bool myBool = true;
    private bool myBool2 = false;

    void MyMet3(int tall1, int tall2)
    {
        //int sum = tall1 + tall2;
        //int produkt = tall1 * tall2;

        if (tall1 == tall2)
        {
            print("Likt");
        }
        else
        {
            print("Ulikt");
        }
    }
    //https://csharpexercises.com/

    //Lag en metode som tar inn 3 tall. pluss de to første og deretter minus det tredje tallet. Eks 3+7-2

    /*
    Add two numbers
    Given three numbers, write a method that adds two first ones and multiplies them by a third one.
    met(3,6,35) = 315
    */

    void Start()
    {
        MyMet3();
    }







    void MyMet()
    {
        //numberOne = numberOne + 1;

        //numberOne += 1;

        //numberOne--;

        
        var2 *= 1.1f;

        print(var1);
        print(var2);
    }


    int MyMet2()
    {
        numberOne++;
        return numberOne;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        //kjører metoden når jeg trykker på venstre museknapp
        if (Input.GetMouseButtonDown(0))
        {
            MyMet();
        }
        //kjører metoden når jeg trykker på høyre museknapp
        if (Input.GetMouseButtonDown(1))
        {
            print(MyMet2());
            
        }
        */
}
}
