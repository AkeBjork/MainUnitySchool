using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberManager : MonoBehaviour
{
    private int[] myNumbers;
    private Transform[] myNumberObjekts;

    public Transform numberPrefab;
    public Transform numberContentParent;

    private List<int> myPossiblePrimeNumbers = new List<int>();
    private List<int> foundPrimeNumbers = new List<int>();

    //private int currentNumber = 2;

    private int currentBiggestPrimeNumber = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void ResetList()
    {
        Transform[] myTempTransform = numberContentParent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < myTempTransform.Length; i++)
        {
            Destroy(myTempTransform[i].gameObject);
        }
        
        currentBiggestPrimeNumber = 2;
        startRunTime = Time.timeSinceLevelLoad;
        print("Timer 1: " + startRunTime);
    }

    public void SetNumber(System.String number)
    {
        //Setup start
        ResetList();
        int num;
        int.TryParse(number, out num);
        myNumbers = new int[num];
        myNumberObjekts = new Transform[num];
        myPossiblePrimeNumbers.Clear();
        foundPrimeNumbers.Clear();
        foundPrimeNumbers.Add(2);
        //Setup end

        for (int i = 0; i < myNumbers.Length; i++)
        {
            myNumbers[i] = (i+1);
            Transform myNumberObjekt = Instantiate(numberPrefab, numberContentParent);
            myNumberObjekt.GetComponentInChildren<TextMeshProUGUI>().text = (i+1)+"";
            myNumberObjekts[i] = myNumberObjekt;
        }
        myNumberObjekts[0].GetComponentInChildren<TextMeshProUGUI>().text = "";
        for (int i = 1; i < myNumbers.Length; i++)
        {
            myPossiblePrimeNumbers.Add(myNumbers[i]);
        }
        FindPrime(currentBiggestPrimeNumber);
    }

    /*void StartFindingNumbers(int rounds)
    {
        for (int i = 2; i <= rounds; i++)
        {
            CheckNumber(i);
            currentNumber++;
        }

    }*/

    float startRunTime;
    public void ResetAll()
    {
        currentBiggestPrimeNumber = 2;
        startRunTime = Time.timeSinceLevelLoad;
    }

    int counter = 0;
    void FindPrime(int number)
    {
        counter++;
        if (number == -1 || counter == 200)
        {
            print("done" + counter + "checking no: " + number);
            print("Timer 2: " + Time.timeSinceLevelLoad);
            print("Time since start: " + (Time.timeSinceLevelLoad - startRunTime));
            return;
        }
        //print("not done");
        for (int i = 1; i < myNumberObjekts.Length; i++)
        {
            //print(myNumbers[i] + " " + number);

            if (myNumbers[i] % number == 0 && myNumbers[i] != number && myNumbers[i] < myNumbers.Length*2)
            {
                //print("yes, " + myNumbers[i] + " and " + number);
                myNumberObjekts[i].GetComponent<Image>().color = new Color32(169, 169, 169,255);
                //myNumberObjekts[i].GetComponent<Button>().interactable = false;

                //Her er noe rart. Printer True??
                //print("Her er problemet: " + myPossiblePrimeNumbers.Remove(i));
                //print("removing: " + (i+1));
                myPossiblePrimeNumbers.Remove(i+1);
            }
        }
        //myPossiblePrimeNumbers.Remove(4);

        FindPrime(FindNextCurrentBiggestPrimeNumber());

    }

    int FindNextCurrentBiggestPrimeNumber()
    {
        int currentFoundPrimeIndex = myPossiblePrimeNumbers.IndexOf(currentBiggestPrimeNumber);
        currentBiggestPrimeNumber = myPossiblePrimeNumbers[currentFoundPrimeIndex + 1];
        foundPrimeNumbers.Add(currentBiggestPrimeNumber);
        //print(currentFoundPrimeIndex + " " + (myPossiblePrimeNumbers.Count - 1));

        if (currentFoundPrimeIndex == myPossiblePrimeNumbers.Count-2)
        {
            return -1;
        }
        else
        {
            return myPossiblePrimeNumbers[currentFoundPrimeIndex + 1];
        }
        
    }

    // Update is called once per frame
    void Update2()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Transform[] myTempTransform = numberContentParent.GetComponentsInChildren<Transform>();
            for (int i = 1; i < myTempTransform.Length; i++)
            {
                Destroy(myTempTransform[i].gameObject);
            }
        }
    }
}
