using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCollisions : MonoBehaviour
{
    [SerializeField]
    private Hero currentHero;
    private int playerNo;

    public void SetPlayerID(int playerNo)
    {
        this.playerNo = playerNo;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHero = GameObject.Find("/Managers").GetComponent<HeroManager>().GetHero(playerNo);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            currentHero.CurrentAvailableJumpCount = 1;
        }
        else if (collision.transform.tag == "Enemy")
        {
            currentHero.CurrentAvailableJumpCount = 1;
            collision.collider.isTrigger = true;
            Destroy(collision.gameObject, 2);
            //currentHero.Attack(collision.transform);
        }
    }
}
