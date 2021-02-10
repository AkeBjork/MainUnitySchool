using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hero : Unit
{
    //[SerializeField]
    /*
    private string name;
    private int maxHP;
    private int currentHP;
    */
    private int gold;
    private int xp;

    //prop, lær senere
    public Transform HeroTransform { get; set; }
    public int CurrentAvailableJumpCount { get; set; }
    public float JumpForce { get; set; }

    public Hero(string name, int maxHP, Transform heroTransform, int currentAvailableJumpCount) : base(name, maxHP)
    {
        HeroTransform = heroTransform;
        CurrentAvailableJumpCount = currentAvailableJumpCount;
        
    }












    /***************
    * Constructors *
    ***************/
    /*
    public Hero(string name, int maxHP, Transform heroTransform, int playerNo)
    {
        this.name = name;
        this.maxHP = maxHP;

        currentHP = this.maxHP;
        HeroTransform = heroTransform;
        
        //Standard settings
        CurrentAvailableJumpCount = 1;
        JumpForce = 5f;
        heroTransform.GetComponent<HeroCollisions>().SetPlayerID(playerNo);
    }
    */





    /**********
    * Getters*
    **********/
    /*
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
    */
    public int GetGold()
    {
        return gold;
    }

    public int GetXP()
    {
        return xp;
    }



    /**********
    * Setters *
    **********/
    /*
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
    */

    public void SetXP(int value)
    {
        xp = value;
    }

    public void SetGold(int value)
    {
        gold = value;
    }

    /**********
    * Methods *
    **********/
    /*
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
    */

    public void PickUp()
    { 
    
    }

    public void Jump()
    { 
    
    }


}
