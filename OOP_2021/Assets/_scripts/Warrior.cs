using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior //: MonoBehaviour. slett denne!
{
    //Slett Start() og Update() siden disse bruker vi bare sammen med MonoBehaviour så vi ikke blir forvirret. 


    /***********************
     ****   Variabler    ***
     ***********************/

    //Sett inn de egenskapene en kriger skal ha (variabler)
    private string name;
    private float health;
    private float attackDamage;


    /***********************
    **** Konstruktører   ***
    ***********************/

    //Sett inn de konstruktørene du ønsker. En konstruktør er hva som kan skje når det blir laget et objekt av denne klassen.

    //tom konstruktør, objektet blir laget uten verdier
    public Warrior()
    {

    }
    //overlastet konstruktør 1: objektet blir laget med et navn
    public Warrior(string name)
    {
        this.name = name;
    }
    //overlastet konstruktør 2: objektet blir laget med et navn og helseverdi
    public Warrior(string name, float health)
    {
        this.name = name;
        this.health = health;
    }


    /***********************
    ****     Metoder     ***
    ***********************/

    //Sett inn de tingene en kriger skal kunne gjøre eller bli gort på (metoder)
    void Attack()
    {
        Debug.Log(name + " is attacking!");
    }

    public void TakeDamage(float value, string weapon)
    {
        Debug.Log(name + " got hit with a(n) " + weapon +  " for " + value + " damage!");
    }

}
