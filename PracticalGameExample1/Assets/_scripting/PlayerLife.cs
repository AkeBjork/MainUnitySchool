using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerLife : MonoBehaviour
{

    public int maxLife = 100;
    public int currentLife;
    public TextMeshProUGUI txtLife;
    public TextMeshProUGUI txtFinalScore;
    public GameObject pnlGameOver;
    public ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
        currentLife = maxLife;
    }
        
    void TakeDamage(int damage)
    {
        currentLife -= damage;
        UpdateInfo();
        CheckLife();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(3))
        {
            TakeDamage(10);
        }
    }

    void UpdateInfo()
    {
        txtLife.text = ""+currentLife;
    }

    void CheckLife()
    {
        if (currentLife <= 0)
        {
            OnDeath();
        }
        
    }

    void OnDeath()
    {
        pnlGameOver.SetActive(true);
        txtFinalScore.text = scoreManager.GetTimer().ToString("F2");
        //Todo:
        //animation?
        //Sound?
        //print("You died, restart?");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            TakeDamage(100);
        }
    }


}
