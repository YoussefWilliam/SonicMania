using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollid : MonoBehaviour
{
    public int countSphere = 0;
    public int increaseTime = 0;
    public int decreaseTime = 0;
    public PlayerMovment player;
    float originalForce;
    public  bool isActive = false;

    private void Start()
    {
         originalForce = player.force;
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.gameObject.tag)
        {
            case "Boost":
                countSphere += 10;break;
            case "Coin":
                increaseTime += 2;break;
            case "Iron":
                if(isActive == false)
                {
                   decreaseTime += 10; break;
                }
                else
                {
                    break;
                }
        }
    }

    private void Update()
    {
        if(countSphere == 50)
        {
            isActive = true;
            FindObjectOfType<AudioManager>().Pause("Theme");
            FindObjectOfType<AudioManager>().Play("Invincible");
            countSphere = 0;
            player.force *= 2;
            Invoke("OffInvincible", 5.0f);
        }
    }
    void OffInvincible()
    {
        FindObjectOfType<AudioManager>().Play("Theme");
        player.force = originalForce;
        isActive = false;

    }
}

