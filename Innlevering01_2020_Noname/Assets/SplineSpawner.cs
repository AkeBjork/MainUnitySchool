using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplineSpawner : MonoBehaviour
{
    public BezierSpline spline;
   
    public int frequency;
    public float distanceBetweenItems;
    public bool lookForward;
    public Transform[] items;
    public List<Transform> myObjects = new List<Transform>();
    public float deleteDistance = 2f;

    private void Awake()
    {
        if (frequency <= 0 || items == null || items.Length == 0)
        {
            return;
        }

        float stepSize = 1f / (frequency * items.Length);

        for (int p = 0, f = 0; f < frequency; f++)
        {
            for (int i = 0; i < items.Length; i++, p++)
            {
                Transform item = Instantiate(items[i]) as Transform;
                Transform item2 = Instantiate(items[i]) as Transform;
                item.name = "Left " + p + " " + f;
                item2.name = "Right " + p + " " + f;

                Vector3 position = spline.GetPoint(p * stepSize);
                Vector3 direction = spline.GetDirection(p * stepSize);
                Vector3 cross = Vector3.Cross(direction, Vector3.up);
                Vector3 delta = cross.normalized * (distanceBetweenItems / 2);

                item.transform.localPosition = new Vector3(position.x + delta.x, position.y + delta.y, position.z + delta.z);
                item2.transform.localPosition = new Vector3(position.x - delta.x, position.y - delta.y, position.z - delta.z);

                if (lookForward)
                {
                    item.transform.LookAt(position + spline.GetDirection(p * stepSize));
                    item2.transform.LookAt(position + spline.GetDirection(p * stepSize));
                }

                item.transform.parent = transform;
                item2.transform.parent = transform;

                if (f != 0)
                {
                    //print(Vector3.Distance(item2.position, myObjects[myObjects.Count - 1].position));
                }


                if (f == 0 || Vector3.Distance(item2.position,myObjects[myObjects.Count-1].position)>deleteDistance && Vector3.Distance(item.position, myObjects[myObjects.Count - 2].position) > deleteDistance)
                {
                    myObjects.Add(item);
                    myObjects.Add(item2);
                }
                else 
                {
                    //print("Deleted: " + item.name + " and " + item2.name);
                    Destroy(item.gameObject);
                    Destroy(item2.gameObject);
                   
                }
            }
        }
    }
}
