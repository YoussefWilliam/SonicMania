using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BoostSphere : MonoBehaviour
{
    public GameObject boost;
    public Text boostText;

    public float force;
    public int countSphere = 0;
    void OnTriggerEnter(Collider objectHit)
    {
        if (objectHit.gameObject.tag == "Player")
        {
            Debug.Log("Hit the boost");
            FindObjectOfType<AudioManager>().Play("Boost");
            Destroy(this.gameObject);
            Debug.Log(countSphere);


        }
    }

    private void Update()
    {
        if (boost.transform.position.z < FindObjectOfType<PlayerMovment>().transform.position.z)
        {
            Destroy(this.gameObject);
        }

    }
}
