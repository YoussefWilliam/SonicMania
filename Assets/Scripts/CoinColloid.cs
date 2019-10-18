using UnityEngine;

public class CoinColloid : MonoBehaviour
{
    public GameObject coin;
    
    
    void OnTriggerEnter(Collider objectHit)
    {
        if (objectHit.gameObject.tag == "Player")
        {
            Debug.Log("Hit the coin");
            FindObjectOfType<AudioManager>().Play("Coins");
            Destroy(this.gameObject);
        }
    }



    private void Update()
    {
        if (coin.transform.position.z < FindObjectOfType<PlayerMovment>().transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }

}
