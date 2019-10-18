using UnityEngine;

public class BombCollid : MonoBehaviour
{
    public GameObject bomb;
    void OnTriggerEnter(Collider objectHit)
    {
        if (objectHit.gameObject.tag == "Player" && FindObjectOfType<PlayerCollid>().isActive == false)
        {
            Debug.Log("Hit the bomb,");
            FindObjectOfType<AudioManager>().Play("Bomb");
            Destroy(this.gameObject);
            FindObjectOfType<gameOver>().EndGame();
            FindObjectOfType<AudioManager>().Play("GameOver");
            Time.timeScale = 0f;

        }
    }

    private void Update()
    {
        if(bomb.transform.position.z < FindObjectOfType<PlayerMovment>().transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }


}
