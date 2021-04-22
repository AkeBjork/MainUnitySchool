using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{

    //Her er alle kort prefabene du skal bruke
    [SerializeField]
    private List<Transform> myCards;

    //Denne henter alle transformene under "CardHolder", men den tar også med seg selv. Altså blir det 4 i dette tilfellet så du må hoppe over første senere. Eller fjerne første linje som jeg gjør i start
    //Hvis dere vil vise 4 kort om gangen så er det bare å legge til et nytt objekt under CardHolder i hierarkiet
    [SerializeField]
    private Transform[] myPossibleCardPositions;

    //Denne sier hvilken index fra myCards[] som skal legges i første posisjon sett fra venstre
    private int currentFirstCard = 0;
    
    //Dette er transformen som holder posisjonen til kortene som vi ønsker å instantiere
    private Transform cardHolder;


    // Start is called before the first frame update
    void Start()
    {
        //Henter og lagrer posisjonen til cardHolder ved hjelp av GameObjekt.Find(string) som finner første forekomst av et objekt med gitt string navn.
        cardHolder = GameObject.Find("CardHolder").transform;
        //Lagrer alle transforms som ligger under cardHolder (inkludert seg selv)
        myPossibleCardPositions = cardHolder.GetComponentsInChildren<Transform>();
        //Vi kan fjerne første linje som vi ikke trenger. (Vi ønsker bare barna, ikke parentobjektet som er over barna)
        Transform[] tempArray = myPossibleCardPositions;
        myPossibleCardPositions = new Transform[tempArray.Length - 1];

        for (int i = 1; i < tempArray.Length; i++)
        {
            //Vi starter på i = 1 og hopper dermed over første
            myPossibleCardPositions[i - 1] = tempArray[i];
        }

        SetupCards();

    }

    void SetupCards()
    {
        //Finner alle children av objektet som dette skriptet er festet på
        Transform[] tempArray = transform.GetComponentsInChildren<Transform>();
        //print(tempArray.Length);

        //Denne ødelegger alle kort for dere og instantierer nye kort. Dette er dårlig kode, men det forenkler oppgaven. Dere kan konsentrere dere om neste for-løkke
        for (int i = 1; i < tempArray.Length; i++)
        {
            //print("Destroying: " + tempArray[i].name);
            Destroy(tempArray[i].gameObject);
        }


        //lag en sjekk på at kortene ikke går utenfor tabellen. Akkurat nå feiler det når vi prøver å instantiere en index som er under 0 eller over lengden på tabellen.
        for (int i = 0; i < myPossibleCardPositions.Length; i++)
        {
            int tempNo= currentFirstCard + i;
            if (currentFirstCard + i >= myCards.Count)
            {               
                tempNo -= myCards.Count;
            }

            //0
            else if(currentFirstCard + i < 0)
            {
                //0 
                tempNo += myCards.Count;
                //7
            }

            Instantiate(myCards[tempNo], myPossibleCardPositions[i].position,Quaternion.identity,transform);
        }
    }

    //Flytter alle kort en til høyre
    public void MoveRight()
    {
        currentFirstCard++;
        SetupCards();
    }

    //Flytter alle kort en til venstre
    public void MoveLeft()
    {
        currentFirstCard--;
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
