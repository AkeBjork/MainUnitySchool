using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroManager : MonoBehaviour
{
    public Transform[] myHeroTransforms;


    //Just 1 for now, but makes it possible to alter easy later
    private Hero[] myHeroes = new Hero[1];
    private Rigidbody rigidbody;


    // Start is called before the first frame update
    void Awake()
    {
        myHeroes[0] = new Hero("Hero-man", 1, myHeroTransforms[0], 1);  
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Hero GetHero(int player)
    {
        return myHeroes[player - 1];
    }

}
