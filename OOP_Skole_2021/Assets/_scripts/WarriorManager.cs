using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorManager : MonoBehaviour
{
    private List<Warrior> myWarriors = new List<Warrior>();

    public int MyProperty { get; set; }



    

    // Start is called before the first frame update
    void Start()
    {

        //Oppgave, lag 100 krigere. De skal hete warrior1,2,3,4, .. , 100




        for (int i = 0; i < 100; i++)
        {
            myWarriors.Add(new Warrior("Warrior " + (i+1)));
        }




        for (int i = 0; i < myWarriors.Count; i++)
        {
            print(myWarriors[i].GetName());
        }


    }

    
    // Update is called once per frame
    void Update()
    {

    }
}
