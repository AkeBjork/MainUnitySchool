using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    /***************
    *   Variables  *
    ***************/

    private int xPValue;
    private float walkSpeed;


    /***************
    * Constructors *
    ***************/
    public Enemy(string name, int maxHP, int xPValue, float walkSpeed) : base(name, maxHP)
    {
        this.xPValue = xPValue;
        this.walkSpeed = walkSpeed;
    }



    /**********
    * Getters*
    **********/

    public int GetXPValue()
    {
        return xPValue;
    }
    public float GetWalkSpeed()
    {
        return walkSpeed;
    }



    /**********
    * Setters *
    **********/
  

    public void SetXPValue(int value)
    {
        xPValue = value;
    }

    public void SetWalkSpeed(float value)
    {
        walkSpeed = value;
    }
    /**********
    * Methods*
    **********/

    

    public void Drop()
    {
        Debug.Log(base.GetName() + " drops xp amount: " + xPValue);
        Debug.Log(base.GetName() + " drops gold amount: " + Random.Range(0,10));
    }

    public float Move()
    {
        return walkSpeed;
    }
        
}
