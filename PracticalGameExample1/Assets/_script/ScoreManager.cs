using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public TextMeshProUGUI txtScore;

    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        txtScore.text = "Hello W";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        txtScore.text = timer.ToString("F0");
    }

    public float GetTimer()
    {
        return timer;
    }
}
