using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace MyDoors 
{
    public class ManageSlidingDoorA : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI pressUseButton;
        private bool useButtonOn = false;
        private Animator slidingDoorAAnimator;
        private Color32 currentTextColor;
        private Color32 alteredTextColor;
        // Start is called before the first frame update
        void Start()
        {
            slidingDoorAAnimator = GetComponent<Animator>();
            currentTextColor = pressUseButton.faceColor;
            SetTextColor(0);
        }

        private void OnTriggerEnter(Collider other)
        {
            slidingDoorAAnimator.SetBool("InRange", true);
            useButtonOn = true;
            SetTextColor(255);
        }

        private void OnTriggerExit(Collider other)
        {
            slidingDoorAAnimator.SetBool("InRange", false);
            useButtonOn = false;
            SetTextColor(0);
        }

        void SetTextColor(byte alphaValue)
        {
            alteredTextColor.a = alphaValue;
            pressUseButton.faceColor = alteredTextColor;
        }

        // Update is called once per frame
        void Update()
        {
            if (useButtonOn && Input.GetKeyDown(KeyCode.E))
            {
                slidingDoorAAnimator.SetTrigger("OpenDoor");
                SetTextColor(0);
            }
        }
    }
}

