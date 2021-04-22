using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    string alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
    [SerializeField]
    List<string> myLetters = new List<string>();

    public void GetLetters(System.String stringInput)
    {
        myLetters.Clear();
        for (int i = 0; i < stringInput.Length; i+=2)
        {
            myLetters.Add(stringInput.Substring(i, 2));
        }

        string newWord = "";
        for (int i = 0; i < myLetters.Count; i++)
        {
            int temp = System.Int32.Parse(myLetters[i]);
            //int.TryParse(myLetters[i]), out temp);
            if (temp == 0)
            {
                newWord += " ";
            }
            else
            {
                newWord += alphabeth.Substring(temp - 1, 1);
            }
        }
        print(newWord);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
