using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyWarriors : MonoBehaviour
{
    private Warrior[] myWarriors = new Warrior[3];
    private List<string> myWeapons = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        Warrior warrior1 = new Warrior("Sam");
        Warrior warrior2 = new Warrior("Gina");
        Warrior warrior3 = new Warrior("Bob");

        myWarriors[0] = warrior1;
        myWarriors[1] = warrior2;
        myWarriors[2] = warrior3;

        myWeapons.Add("axe");
        myWeapons.Add("knife");
        myWeapons.Add("rifle bullet");
        myWeapons.Add("laser beam");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //myWarriors[0].TakeDamage(50);
            myWarriors
                [Random.Range(0, myWarriors.Length)]
                .TakeDamage(Random.Range(1,100),
                myWeapons[Random.Range(0,myWeapons.Count)]);
        }
    }
}
