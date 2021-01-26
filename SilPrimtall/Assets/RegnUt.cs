using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RegnUt : MonoBehaviour
{
    int x = -20;
    int y = -20;

    int counter = 40;

    int counterLow; //a og b minimumverdier
    int counterHigh; // a og b maks
    [SerializeField]
    private int a;
    [SerializeField]
    private int b;
    [SerializeField]
    private int c;
    [SerializeField]
    private string[] myEquationParts;

    [SerializeField]
    private string myEquation;
    [SerializeField]
    private Transform valuePrefab;
    [SerializeField]
    private Transform valueParent;

    public void SetEquation(System.String newEquation)
    {
        myEquation = newEquation;
        //myEquationParts = myEquation.Split(new[] { "+" },System.StringSplitOptions.None);
        myEquationParts = myEquation.Split("x+y=".ToCharArray(),System.StringSplitOptions.RemoveEmptyEntries);

        int.TryParse(myEquationParts[0], out a);
        int.TryParse(myEquationParts[1], out b);
        int.TryParse(myEquationParts[2], out c);
    }

    [SerializeField]
    private TextMeshProUGUI[] myValues;
    public void CalculateEquation()
    {
        myValues = valueParent.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 2; i < myValues.Length; i++)
        {
            Destroy(myValues[i].transform.parent.gameObject);
        }
        if (myEquationParts.Length == 3)
        {
            if (counterLow == counterHigh)
            {
                counterLow = -100;
                counterHigh = 100;
            }

            for (int x = counterLow; x <= counterHigh; x++)
            {
                for (int y = counterLow; y <= counterHigh; y++)
                {
                    if (((a * x) + (b * y)) == c)
                    {
                        Transform xValue = Instantiate(valuePrefab, valueParent);
                        xValue.GetComponentInChildren<TextMeshProUGUI>().text = x.ToString();
                        Transform yValue = Instantiate(valuePrefab, valueParent);
                        yValue.GetComponentInChildren<TextMeshProUGUI>().text = y.ToString();

                        print("a=" + x + " b=" + y);
                    }
                }
            }
        }
    }




    // Start is called before the first frame update
    void NOStart()
    {
        
        //print("start");
        for (int a = -counter; a < counter; a++)
        {
            //print("outer");
            for (int b = -counter; b < counter; b++)
            {
                //sprint(a + " " + b + ": " + ((3 * a) + (5 * b)));

                //oppgave1
                /*if (((3 * a) + (5*b)) == 4)
                {
                    print("a=" + a + " b=" + b);
                }*/
                //oppgave2
                if (((2 * a) + (6 * b)) == 7)
                {
                    print("a=" + a + " b=" + b);
                }

                //oppgave 3
                /*if (((6 * a) + (7 * b)) == 4)
                {
                    print("a=" + a + " b=" + b);
                }
                */
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
