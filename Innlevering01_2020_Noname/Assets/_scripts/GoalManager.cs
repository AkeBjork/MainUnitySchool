using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalManager : MonoBehaviour
{
    private float startTime;
    private float timeLeft;
    private int points;
    private int currentGoalIndex;
    private int lastGoalIndex;
    private Transform player1;
    private Transform CurrentGoalLocationObject;
    private float timeCountMultiplierSpeed = 200f;
    private List<Transform> myTempGoals = new List<Transform>();
    private CursorManager cursorManager;

    public Transform goalPrefab;
    public List<Transform> myGoals = new List<Transform>();
    public TextMeshProUGUI txtTimeLeft;
    public TextMeshProUGUI txtPoints;
    public Transform goalParent;

    // Start is called before the first frame update
    void Start()
    {
        cursorManager = GameObject.Find("CursorManager").GetComponent<CursorManager>();
        cursorManager.SetVisible(false);
        player1 = GameObject.Find("Player1_Rocket").transform;
        //myTempGoals = myGoals;
        //var listCopy = new List<Stuff>(originalList);
        myTempGoals = new List<Transform>(myGoals);
        currentGoalIndex = Random.Range(0, myTempGoals.Count);
        print(currentGoalIndex);
        CurrentGoalLocationObject = Instantiate(goalPrefab, myTempGoals[currentGoalIndex].position,Quaternion.identity, goalParent);
        SetTimeLeft(Vector2.Distance(player1.position, CurrentGoalLocationObject.position));
        
    }

    public void OnEnterGoal()
    {
        UpdatePoints();
        myTempGoals.RemoveAt(currentGoalIndex);
        lastGoalIndex = currentGoalIndex;
        if (myTempGoals.Count <= 0)
        {
            print("Reset");
            myTempGoals = new List<Transform>(myGoals);
        }
        currentGoalIndex = Random.Range(0, myTempGoals.Count);
        CurrentGoalLocationObject = Instantiate(goalPrefab, myTempGoals[currentGoalIndex].position, Quaternion.identity, goalParent);
        SetTimeLeft(Vector2.Distance(player1.position, CurrentGoalLocationObject.position));
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0)
        {
            timeLeft -= Time.deltaTime * timeCountMultiplierSpeed;
            //timeLeft -= Time.deltaTime;
        }
        else
        {
            timeLeft = 0;
        }
        UpdateTimer();
    }

    public void SetTimeLeft(float time)
    {
        timeLeft = time * 100;
        UpdateTimer();
    }

    public float GetTimeLeft()
    {
        return timeLeft;
    }

    public void SetPoints(int newPoints)
    {
        points = newPoints;
    }

    public int GetPoints()
    {
        return points;
    }

    void UpdatePoints()
    {
        points += (int)timeLeft;
        txtPoints.text = points.ToString();
    }

    void UpdateTimer()
    {
        txtTimeLeft.text = timeLeft.ToString("F0");
    }

    public void RestartGame()
    {
        Transform[] tempGoals = goalParent.GetComponentsInChildren<Transform>();
        for (int i = 1; i < tempGoals.Length; i++)
        {
            Destroy(tempGoals[i].gameObject);
        }

        SetPoints(0);
        timeLeft = 0;
        UpdatePoints();
        myTempGoals = new List<Transform>(myGoals);

        OnEnterGoal();

        print(GameObject.Find("SpawnPoint").transform.position);
        player1.gameObject.SetActive(true);
        player1.transform.position = GameObject.Find("SpawnPoint").transform.position;
        player1.GetComponent<RocketForce>().StartEngine();
        cursorManager.SetVisible(false);
    }

}
