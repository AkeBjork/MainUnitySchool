using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verktoy
{
    public string Navn { get; set; }
    public float Pris { get; set; }

    public Verktoy(string navn, float pris)
    {
        Navn = navn;
        Pris = pris;
    }


}
