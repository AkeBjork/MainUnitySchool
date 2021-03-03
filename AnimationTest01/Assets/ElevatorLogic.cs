using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorLogic : MonoBehaviour
{
    [SerializeField]
    private Slider floorMarkerSlider;
    private float floorCurrentPosition = 1;
    private float floorTargetPosition = 3;
    [SerializeField]
    private Animator animator;
    private float timer = 0f;

    [SerializeField]
    private Button[] elevatorButtons;
    [SerializeField]
    private List<int> currentPressedButtons;
     
    //Elevator colors
    private Color32 ringlightOff = new Color32(255,255,255,255);
    private Color32 ringlightOn = new Color32(0, 219, 198, 255);
    private Color32 numberLightOff = new Color32(0, 41, 37, 255);
    private Color32 numberLightOn = new Color32(0, 219, 198, 255);

    private float lerpDuration = 3f;
    private float valueToLerp;

    [SerializeField]
    private bool elevatorRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < elevatorButtons.Length; i++)
        {
            SetColors(elevatorButtons[i], false);
        }
    }

    public void SetFloor(int floor)
    {
        if (!currentPressedButtons.Contains(floor))
        {
            currentPressedButtons.Add(floor);
            SetColors(elevatorButtons[currentPressedButtons[currentPressedButtons.Count - 1]-1], true);
            
            //floorTargetPosition = floor;
            
            if (!elevatorRunning)
            {
                elevatorRunning = true;
                StartCoroutine(GoToFloor());
            }
        }

    }

    void SetColors(Button button, bool on)
    {
        Color32 temp1;
        Color32 temp2;
        if (on)
        {
            temp1 = numberLightOn;
            temp2 = ringlightOn;
        }
        else 
        {
            temp1 = numberLightOff;
            temp2 = ringlightOff;
        }
        button.GetComponentInChildren<TextMeshProUGUI>().color = temp1;
        button.GetComponentInChildren<RawImage>().color = temp2;
    }
    

    private IEnumerator GoToFloor()
    {
        print("Starting elevator");
        while (currentPressedButtons.Count > 0)
        {
            floorTargetPosition = currentPressedButtons[0];
            print("Going to new floor");
            float timeElapsed = 0;

            while (timeElapsed < lerpDuration)
            {
                valueToLerp = Mathf.Lerp(floorCurrentPosition, floorTargetPosition, timeElapsed / lerpDuration);
                animator.SetFloat("ElevatorFloor", valueToLerp);

                timeElapsed += Time.deltaTime;
                UpdateSlider();
                yield return null;
            }

            valueToLerp = floorTargetPosition;
            animator.SetFloat("ElevatorFloor", valueToLerp);
            SetColors(elevatorButtons[(int)floorTargetPosition - 1], false);
            currentPressedButtons.Remove((int)floorTargetPosition);
            UpdateSlider();
            yield return floorCurrentPosition = floorTargetPosition;
        }
        print("Elevator done");
        yield return elevatorRunning = false;
    }

    void UpdateSlider()
    {
        floorMarkerSlider.value = valueToLerp;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
