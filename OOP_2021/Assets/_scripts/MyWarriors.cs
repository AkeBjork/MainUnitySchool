using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //for å kunne skripte mot UI elementer som f.eks slider
using TMPro; //for å kunne skripte mot textmesh pro

public class MyWarriors : MonoBehaviour
{
    
    //Liste som kan fylles med Warrior objekter/instanser
    private List<Warrior> myWarriors = new List<Warrior>();

    [SerializeField] //Vi bruker ikke public lengre på variabler. Denne skal bare nås fra unity så seriaze kan brukes. Getters and setters kan brukes her, men mister oversikten. I klasser uten MonoBehaviour så skal get/set brukes
    private GameObject hero3DObjekt; //Hele HeroCharacter som dere ser i hierarkiet

    [SerializeField] //Animasjon
    private Animator[] HeroObjektAnimator;

    // Start is called before the first frame update
    void Start()
    {       
        //en instans(objekt av klassen Warrior)
        Warrior warrior1 = new Warrior("Sam");
        //bruk av en intern metode
        print(warrior1.GetName()); //printer Sam
        warrior1.SetName("Jimmy");
        print(warrior1.GetName()); //printer Jimmy

        //10 instanser lagt i en liste
        for (int i = 0; i < 10; i++) //Vi bruker en for-løkke siden vi vet at vi ønsker å lage 10 stykk i dette tilfellet
        {
            //vi legger 1 warrior i listen på linje 8 over per gjennomkjøring av for-løkken
            //De har name warrior med tallet som ligger i variabelen i etter navnet. + en random verdi som health (liv/helse) 
            myWarriors.Add(new Warrior("Warrior " + (i+1), Random.Range(1,3)));
        }

        //Vi printer ut alle warrior-objektene som ligger i listen myWarriors
        //listenavn.count gir oss tallet på hvor mange rader som ligger inne i listevariabelen
        for (int i = 0; i < myWarriors.Count; i++)
        {
            print(myWarriors[i].GetName()); //Her treffer vi GetName() metoden som ligger inne i hvert eneste objekt/instans. Siden dette er en metode med string som retur så kan vi skrive ut svaret som denne metoden sender tilbake til oss.
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Når vi trykker på en museknapp, 0 er venstre museknapp som standard.
        if (Input.GetMouseButtonDown(0))
        {
            //Lager en peker til en tilfeldig rad i listen vår slik at vi kan bruke denne videre i koden
            Warrior temp = myWarriors[Random.Range(0,myWarriors.Count)];
            //print(hero3DObjekt.transform.Find("CanvasWorldSpace/txtName").gameObject.ToString());
            hero3DObjekt.transform.Find("CanvasWorldSpace/txtName").GetComponent<TextMeshProUGUI>().text = temp.GetName();

            //starter metoden under
            StartCoroutine(StartAnim());
        }
    }

    //Dette er litt utenfor pensum, men det er en coroutine metode som betyr at den kjører i en egen tråd som er uavhengig av annen kode. Glem dette hvis du ikke er veldig interessert
    //NB: Metoden fungerer ikke som jeg ønsker. Setter meg ikke inn i hvorfor nå   
    IEnumerator StartAnim()
    {
        //Kjører kode i alle elementene som er lagt i arrayen
        foreach (var item in HeroObjektAnimator)
        {
            //venter fra 0  til 0.5 sekunder.
            yield return new WaitForSeconds(Random.Range(0, 0.5f));
            //Aktiverer en trigger som heter Raise inni i animatoren. Mer om animasjon om noen uker. Dette er pensum senere.
            item.SetTrigger("Raise");
        }
    }
}
