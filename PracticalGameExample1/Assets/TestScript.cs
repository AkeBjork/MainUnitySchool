using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public int[] myArray = {1,2,3};

    public List<int> myList = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        myList.Add(1);
        myList.Add(2);
        myList.Add(3);

        myList.RemoveAt(1);
        print(MinIntMetode(10,34));
        
        MinMetode(10);
        int tall = 10;
        MinMetode(tall);
        myArray[1] = 12;
        print(myArray[1]);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MinMetode(int verdi)
    {
        print(verdi);
    }

    int MinIntMetode(int verdi, int minAndreVerdi)
    {
        return verdi + minAndreVerdi;
    }
}
