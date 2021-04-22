using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManagerSteg1 : MonoBehaviour
{
    private int addNumber;


    public void SetMultiplier(System.String value)
    {
        int newValue = int.Parse(value);
        if (newValue == 0)
        {
            newValue = 1;
        }
        addNumber = newValue;
    }

    //Her er alle kort prefabene du skal bruke
    [SerializeField]
    private List<Transform> myCards;

    //Denne henter alle transformene under "CardHolder", men den tar ogs� med seg selv. Alts� blir det 4 i dette tilfellet s� du m� hoppe over f�rste senere. Eller fjerne f�rste linje som jeg gj�r i start
    //Hvis dere vil vise 4 kort om gangen s� er det bare � legge til et nytt objekt under CardHolder i hierarkiet
    [SerializeField]
    private Transform[] myPossibleCardPositions;

    //Denne sier hvilken index fra myCards[] som skal legges i f�rste posisjon sett fra venstre
    private int currentFirstCard = 0;
    
    //Dette er transformen som holder posisjonen til kortene som vi �nsker � instantiere
    private Transform cardHolder;


    // Start is called before the first frame update
    void Start()
    {
        addNumber = 1;
        //Henter og lagrer posisjonen til cardHolder ved hjelp av GameObjekt.Find(string) som finner f�rste forekomst av et objekt med gitt string navn.
        cardHolder = GameObject.Find("CardHolder").transform;
        //Lagrer alle transforms som ligger under cardHolder (inkludert seg selv)
        myPossibleCardPositions = cardHolder.GetComponentsInChildren<Transform>();
        //Vi kan fjerne f�rste linje som vi ikke trenger. (Vi �nsker bare barna, ikke parentobjektet som er over barna)
        Transform[] tempArray = myPossibleCardPositions;
        myPossibleCardPositions = new Transform[tempArray.Length - 1];

        for (int i = 1; i < tempArray.Length; i++)
        {
            //Vi starter p� i = 1 og hopper dermed over f�rste
            myPossibleCardPositions[i - 1] = tempArray[i];
        }

        //SetupCards();
        SetupCardsDynamic();

    }

    void SetupCards()
    {
        //Finner alle children av objektet som dette skriptet er festet p�
        Transform[] tempArray = transform.GetComponentsInChildren<Transform>();
        //print(tempArray.Length);

        //Denne �delegger alle kort for dere og instantierer nye kort. Dette er d�rlig kode, men det forenkler oppgaven. Dere kan konsentrere dere om neste for-l�kke
        for (int i = 1; i < tempArray.Length; i++)
        {
            //print("Destroying: " + tempArray[i].name);
            Destroy(tempArray[i].gameObject);
        }


        //lag en sjekk p� at kortene ikke g�r utenfor tabellen. Akkurat n� feiler det n�r vi pr�ver � instantiere en index som er under 0 eller over lengden p� tabellen.
        for (int i = 0; i < myPossibleCardPositions.Length; i++)
        {
            Vector3 tempVector = myPossibleCardPositions[i].position;
            tempVector.y += 12;

            int tempPosition = (currentFirstCard + i);
            //print(tempPosition);
            if (tempPosition >= myCards.Count)
            {
                tempPosition -= myCards.Count;
            }
            else if (tempPosition < 0)
            {
                tempPosition += myCards.Count;
            }
            //print(tempPosition);

            Instantiate(myCards[tempPosition], tempVector, Quaternion.identity,transform);
        }
        if (currentFirstCard >= myCards.Count)
        {
            currentFirstCard = 0;
        }
        else if (currentFirstCard < 0)
        {
            currentFirstCard = myCards.Count - 1;
        }
                
    }

    void SetupCardsDynamic()
    {
        //Finner alle children av objektet som dette skriptet er festet p�
        Transform[] tempArray = transform.GetComponentsInChildren<Transform>();
        //print(tempArray.Length);

        //Denne �delegger alle kort for dere og instantierer nye kort. Dette er d�rlig kode, men det forenkler oppgaven. Dere kan konsentrere dere om neste for-l�kke
        for (int i = 1; i < tempArray.Length; i++)
        {
            //print("Destroying: " + tempArray[i].name);
            Destroy(tempArray[i].gameObject);
        }


        //lag en sjekk p� at kortene ikke g�r utenfor tabellen. Akkurat n� feiler det n�r vi pr�ver � instantiere en index som er under 0 eller over lengden p� tabellen.
        for (int i = 0; i < myPossibleCardPositions.Length; i++)
        {
            Vector3 tempVector = myPossibleCardPositions[i].position;
            tempVector.y += 12;

            int tempPosition = (currentFirstCard + i);
            //print(tempPosition);
            if (tempPosition >= myCards.Count)
            {
                tempPosition -= myCards.Count;
            }
            else if (tempPosition < 0)
            {
                tempPosition += myCards.Count;
            }
            //print(tempPosition);

            Instantiate(myCards[tempPosition], tempVector, Quaternion.identity, transform);
        }
        if (currentFirstCard >= myCards.Count)
        {
            currentFirstCard = 0;
        }
        else if (currentFirstCard < 0)
        {
            currentFirstCard = myCards.Count - 1;
        }

    }

    //Flytter alle kort en til h�yre
    public void MoveRight()
    {
        //currentFirstCard++;
        currentFirstCard += addNumber;
        SetupCards();
    }

    //Flytter alle kort en til venstre
    public void MoveLeft()
    {
        //currentFirstCard--;
        currentFirstCard -= addNumber;
        SetupCards();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }
}
