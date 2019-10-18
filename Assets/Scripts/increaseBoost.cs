using UnityEngine;
using UnityEngine.UI;


public class increaseBoost : MonoBehaviour
{
    public Text boostText;
    public PlayerCollid play;

    void Update()
    {
        boostText.text = play.countSphere.ToString();
    }

}
