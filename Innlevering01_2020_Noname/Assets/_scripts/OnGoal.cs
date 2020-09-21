using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGoal : MonoBehaviour
{
    private GoalManager goalManager;

    // Start is called before the first frame update
    void Start()
    {
        goalManager = GameObject.Find("GoalManager").GetComponent<GoalManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        goalManager.OnEnterGoal();
        Destroy(gameObject);
    }
}
