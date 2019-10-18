using UnityEngine;
using UnityEngine.UI;

public class DistancePlayer : MonoBehaviour
{
    public Transform player;
    public Text scoreCount; 

    // Update is called once per frame
    void Update()
    {
        scoreCount.text = player.position.z.ToString("0");
    }
}
