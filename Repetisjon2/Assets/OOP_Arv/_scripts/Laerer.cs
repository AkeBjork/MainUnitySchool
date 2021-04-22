using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laerer : Person
{
    public string Avdeling { get; set; }

    public Laerer(string navn, Texture bilde, string avdeling) : base(navn, bilde)
    {
        Avdeling = avdeling;
    }
}
