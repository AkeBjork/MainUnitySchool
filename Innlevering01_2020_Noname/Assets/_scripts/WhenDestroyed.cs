using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WhenDestroyed : MonoBehaviour
{
    public GameObject explosionPrefab;
    public GameObject pnlGameOver;

    private GoalManager goalManager;
    private CursorManager cursorManager;

    void Start()
    {
        goalManager = GameObject.Find("GoalManager").GetComponent<GoalManager>();
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();

    }

    public void PlayDestroyAnimation()
    {
        gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Invoke("GameOver", 0.5f);
    }
    void GameOver()
    {
        pnlGameOver.SetActive(true);
        pnlGameOver.GetComponentInChildren<TextMeshProUGUI>().text = "Game Over\nFinal score:\n" + goalManager.GetPoints();
        cursorManager.SetVisible(true);
    }
}
