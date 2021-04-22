using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sag : Verktoy
{
    public Color32 Farge { get; set; }

    public Sag(string navn, float pris, Color32 farge) : base(navn, pris)
    {
        Farge = farge;
    }


}
