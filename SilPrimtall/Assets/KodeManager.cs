using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KodeManager : MonoBehaviour
{
    [SerializeField]
    private Transform encryptField;
    [SerializeField]
    private Transform decodeingField;
    [SerializeField]
    private Transform outer;
    [SerializeField]
    private Transform inner;
    //0=outerCurrent, 1=innerCurrent, 2=shiftNumber 
    [SerializeField]    
    private int[] currentNumbers = new int[3];
    private int alphabetLenght;
    private DragRotate outerDR;
    private DragRotate innerDR;
    private char[] currentAlphabet;
    private char[] message;

    public void Encode(System.String tekst)
    {
        FindCurrentNumbers();
        alterString(tekst, currentNumbers[2], encryptField);
    }

    public void Decode(System.String tekst)
    {
        FindCurrentNumbers();
        alterString(tekst, (currentNumbers[2]*-1),decodeingField);
    }


    private void FindCurrentNumbers()
    {
        currentNumbers[0] = outerDR.GetCurrentNo();
        currentNumbers[1] = innerDR.GetCurrentNo();
        currentNumbers[2] = currentNumbers[1] - currentNumbers[0];
        alphabetLenght = outerDR.GetAlphabetLenght();
        currentAlphabet = outerDR.GetCurrentAlphabet();
    }

    private void alterString(string tekst, int shiftNo, Transform outText)
    {
        TextMeshProUGUI text = outText.GetComponentInChildren<TextMeshProUGUI>();
        text.text = "";
        message = tekst.ToCharArray();
        print(shiftNo);
        for (int i = 0; i < message.Length; i++)
        {
            //char tmpChar = message[i];
            //int tempCharIndex = currentAlphabet.

            //Need to make uppercase before checking index
            int index = System.Array.IndexOf(currentAlphabet, message[i]);
            print("index " + index);
            int tmp = (index+shiftNo);
            print("index " + tmp + "shift " + shiftNo);
            if (tmp >= alphabetLenght)
            {
                tmp -= alphabetLenght;
            }
            else if (tmp < 0)
            {
                tmp += alphabetLenght;
            }
            message[i] = currentAlphabet[tmp];
        }
        
        for (int i = 0; i < message.Length; i++)
        {
            text.text += message[i];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        outerDR = outer.GetComponent<DragRotate>();
        innerDR = inner.GetComponent<DragRotate>();
        //FindCurrentNumbers();
        //Invoke("LateStart", 0.3f);
    }
}
