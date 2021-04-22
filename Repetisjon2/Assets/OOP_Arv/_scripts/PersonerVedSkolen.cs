using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonerVedSkolen : MonoBehaviour
{
    private Laerer laerer1;
    private Laerer laerer2;
    private Elev elev1;
    private Texture bilde1;
    private List<Laerer> mineLaerere = new List<Laerer>();

    //Elev1
    // Start is called before the first frame update
    void Start()
    {
        laerer1 = new Laerer("Lars", bilde1, "Matte");
        laerer2 = new Laerer("Otto", bilde1, "Nork");
        elev1 = new Elev("rn", bilde1, 7);

        for (int i = 0; i < 500; i++)
        {
            mineLaerere.Add(new Laerer("Arne"+(i+1), bilde1, "IT"));
        }

        for (int i = 0; i < mineLaerere.Count; i++)
        {
            Debug.Log(mineLaerere[i].Navn);
        }


        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
