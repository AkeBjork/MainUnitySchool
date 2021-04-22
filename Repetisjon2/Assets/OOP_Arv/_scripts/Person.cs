using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person 
{
    public string Navn { get; set; }
    public Texture Bilde { get; set; }

    public Person(string navn, Texture bilde)
    {
        Navn = navn;
        Bilde = bilde;
    }

}
