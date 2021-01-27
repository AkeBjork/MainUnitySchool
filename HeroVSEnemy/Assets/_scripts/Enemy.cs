using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    /***************
    *   Variables  *
    ***************/
    private string name;
    private int maxHP;
    private int currentHP;
    private int xPValue;
    private float walkSpeed;


    /***************
    * Constructors *
    ***************/

    public Enemy(string name, int maxHP, int xPValue, float walkSpeed)
    {
        this.name = name;
        this.maxHP = maxHP;
        this.xPValue = xPValue;
        this.walkSpeed = walkSpeed;

        currentHP = this.maxHP;
    }


    /**********
    * Getters*
    **********/
    public string GetName()
    {
        return name;
    }
    public int GetMaxHP()
    {
        return maxHP;
    }
    public int GetCurrentHP()
    {
        return currentHP;
    }
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
    public void SetName(string value)
    {
        name = value;
    }

    public void SetMaxHP(int value)
    {
        maxHP = value;
    }

    public void SetCurrentHP(int value)
    {
        currentHP = value;
    }

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

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP >= 0)
        {
            Die();
        }
    }

    public float Attack()
    {
        //big hardkoded number for testing
        return 100f;
    }

    private void Die()
    {
        Debug.Log(name + " died");
    }

    public void Drop()
    {
        Debug.Log(name + " drops xp amount: " + xPValue);
        Debug.Log(name + " drops gold amount: " + Random.Range(0,10));
    }

    public float Move()
    {
        return walkSpeed;
    }
        
}
