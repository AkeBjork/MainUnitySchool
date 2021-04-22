using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elev : Person
{
    public int Alder { get; set; }
    public Elev(string navn, Texture bilde, int alder) : base(navn, bilde)
    {
        Alder = alder;
    }
}
