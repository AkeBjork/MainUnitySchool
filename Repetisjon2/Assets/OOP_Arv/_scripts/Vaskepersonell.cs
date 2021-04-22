using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaskepersonell : Person
{
    public float Lonn { get; set; }
    public Vaskepersonell(string navn, Texture bilde, float lonn) : base(navn, bilde)
    {
        Lonn = lonn;
    }
}
