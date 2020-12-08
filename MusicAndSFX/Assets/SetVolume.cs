using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetVolume : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().volume = GameObject.Find("MusicManager").GetComponent<MusicManager>().GetSFXVolume();    
    }
}
