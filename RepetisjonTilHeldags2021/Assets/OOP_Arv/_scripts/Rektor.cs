using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rektor : Person
{
    public Color32 Harfarge { get; set; }
    public Rektor(string navn, Texture bilde, Color32 harfarge) : base(navn, bilde)
    {
        Harfarge = harfarge;
    }
}
