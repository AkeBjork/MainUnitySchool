using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    private string name;
    private int maxHP;
    private int currentHP;


    public Unit(string name, int maxHP)
    {
        this.name = name;
        this.maxHP = maxHP;
        
        currentHP = maxHP;
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


    //Metoder
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    public void Attack(Transform enemyTransform)
    {

        Debug.Log("attacked " + enemyTransform.name);
        //send damage to enemy transform
        //enemyTransform.

    }

    private void Die()
    {
        Debug.Log(name + " died");
    }
}
