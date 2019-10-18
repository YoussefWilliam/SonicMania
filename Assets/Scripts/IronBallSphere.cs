using UnityEngine;

public class IronBallSphere : MonoBehaviour
{
    public GameObject iron;

    void OnTriggerEnter(Collider objectHit)
    {
        if (objectHit.gameObject.tag == "Player" && FindObjectOfType<PlayerCollid>().isActive == false)
        {
            Debug.Log("Hit the iron");
            FindObjectOfType<AudioManager>().Play("Iron");
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if (iron.transform.position.z < FindObjectOfType<PlayerMovment>().transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
