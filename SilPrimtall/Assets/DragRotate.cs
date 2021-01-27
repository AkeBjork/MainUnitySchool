using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class DragRotate : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
{
    // This event echoes the new local angle to which we have been dragged
    public event Action<Quaternion> OnAngleChanged;

    Quaternion dragStartRotation;
    Quaternion dragStartInverseRotation;

    [SerializeField]
    private Transform parent;
    [SerializeField]
    private Transform charPrefab;
    [SerializeField]
    private bool canRotate = true;
    private char[] alphabet;
    private Transform[] alphabetTransforms;
    private float anglePerLetter;
    /*[SerializeField]
    private TextMeshProUGUI rotateNo;
    [SerializeField]
    private TextMeshProUGUI rotateChar;
    */
    [SerializeField]
    private Transform outerDiscParent;
    private Transform originalParent;
    private int currentNo;




    void Start()
    {

    }
    

    public void SwitchCanRotate()
    {
        if (canRotate)
        {
            canRotate = false;
            transform.parent = outerDiscParent;
        }
        else
        {
            canRotate = true;
            transform.parent = originalParent;
        }
    }

    public void SetAlphabet(string newAlphabet)
    {
        alphabet = newAlphabet.ToCharArray();
        anglePerLetter = 360f / alphabet.Length;
        alphabetTransforms = new Transform[alphabet.Length];
        
        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabetTransforms[i] = Instantiate(charPrefab, parent);
            alphabetTransforms[i].GetComponentInChildren<TextMeshProUGUI>().text = alphabet[i].ToString();
            alphabetTransforms[i].rotation = Quaternion.Euler(0, 0, i * -anglePerLetter);
            //transform.rotation *= Quaternion.Euler(0, -90, 0);
        }
        //print(alphabet[28]);
    }

    private void Awake()
    {
        // As an example: rotate the attached object
        OnAngleChanged += (rotation) => transform.localRotation = rotation;

        originalParent = transform.parent;
        //string myString = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
        //alphabet = myString.Split(" "[0]);
        //char[] alphabet = myString.ToCharArray();

        SetAlphabet("ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ");




    }


    // This detects the starting point of the drag more accurately than OnBeginDrag,
    // because OnBeginDrag won't fire until the mouse has moved from the point of mousedown
    public void OnPointerDown(PointerEventData eventData)
    {
        dragStartRotation = transform.localRotation;
        Vector3 worldPoint;
        if (DragWorldPoint(eventData, out worldPoint))
        {
            // We use Vector3.forward as the "up" vector because we assume we're working in a Canvas
            // and so mostly care about rotation around the Z axis
            dragStartInverseRotation = Quaternion.Inverse(Quaternion.LookRotation(worldPoint - transform.position, Vector3.forward));
        }
        else
        {
            Debug.LogWarning("Couldn't get drag start world point");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Do nothing (but this has to exist or OnDrag won't work)
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        // Do nothing (but this has to exist or OnDrag won't work)
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canRotate)
        {
            Vector3 worldPoint;
            if (DragWorldPoint(eventData, out worldPoint))
            {
                Quaternion currentDragAngle = Quaternion.LookRotation(worldPoint - transform.position, Vector3.forward);
                if (OnAngleChanged != null)
                {
                    OnAngleChanged(currentDragAngle * dragStartInverseRotation * dragStartRotation);
                }
            }
            RotateData();
        }
    }

    void RotateData()
    {
        float tmp = transform.eulerAngles.z;
        //tmp += anglePerLetter / 2;
  //      rotateNo.text = tmp.ToString("F0");
        //print(Mathf.Floor((tmp / (anglePerLetter))));
        currentNo = (int)Mathf.Floor((tmp / (anglePerLetter)));
  //      rotateChar.text = alphabet[currentNo].ToString();
        //rotateChar.text = ((int)Mathf.Floor(tmp / alphabet.Length)).ToString();
        //rotateChar.text = alphabet[(int)Mathf.Floor(tmp/alphabet.Length)].ToString();
        //rotateChar.text = tmp+"";
    }
    // Gets the point in worldspace corresponding to where the mouse is
    private bool DragWorldPoint(PointerEventData eventData, out Vector3 worldPoint)
    {
        return RectTransformUtility.ScreenPointToWorldPointInRectangle(
            GetComponent<RectTransform>(),
            eventData.position,
            eventData.pressEventCamera,
            out worldPoint);
    }

    public int GetCurrentNo()
    {
        return currentNo;
    }

    public int GetAlphabetLenght()
    {
        return alphabet.Length;
    }

    public char[] GetCurrentAlphabet()
    {
        return alphabet;
    }
}
