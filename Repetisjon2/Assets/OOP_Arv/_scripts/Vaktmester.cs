using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaktmester : Person
{
    public Texture Favorittverktoy { get; set; }
    public Vaktmester(string navn, Texture bilde, Texture favorittverktoy) : base(navn, bilde)
    {
        Favorittverktoy = favorittverktoy;
    }
}
