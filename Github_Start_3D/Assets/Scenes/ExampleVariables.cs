using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleVariables : MonoBehaviour
{

    //public gjør at alle andre klasser kan nå denne variabelen. Vi kan også se den i Unity inspector
    public int myNumber = 5;
    public int mySecondNumber = 8;
    
    //private gjør at variabelen bare kan akseseres i denne klassen og kan ikke sees i Unity inspector. Bruk denne for sikkerhet og høyere hastighet i programmet.
    private int myThirdNumber; //er det samme som å skrive =0;


    // Start er en metode spesifik for Unity og kjøres engang når objektet som har skriptet på seg blir levende i programmet.
    // Ligger skriptet på to objekter så kjøres det to ganger. 
    void Start()
    {
        //skriver ut første variabel
        print("My number is " + myNumber);
        
        //skriver ut andre variabel
        print("My second number is " + mySecondNumber);
        
        //legger sammen begge variabelene, siden vi har en string med i utregningen så vil programmet bare sette sammen tallene, ikke regne ut.
        print(myNumber + " + " + mySecondNumber + " = " + myNumber + mySecondNumber);
        
        //Vi trenger denne endringen () for å få utregning i dette tilfellet.
        print(myNumber + " + " + mySecondNumber + " = " + (myNumber + mySecondNumber));

        //sjekker om en påstand er sann. If må alltid kunne sies som en påstand, eks: er int a mindre enn int b. Ikke er "Hello world" mindre enn int a. Vi kunne testet om en variabel inneholder ordene "Hello" og "world".
        if (myNumber > mySecondNumber)
        {
            print(myNumber + " > " + mySecondNumber);
        }
        //kjøres alltid ut hvis ikke if-en blir sann
        else
        {
            print(myNumber + " < " + mySecondNumber);
        }

    }

    //Metoden Update er spesifik for Unity og kjøres uendelig og i den hastigheten som din maskin klarer. Skal den kjøres eksakt 3 ganger per sekund så må dette programmeres spesifikt.
    void Update()
    {
        
    }
}
