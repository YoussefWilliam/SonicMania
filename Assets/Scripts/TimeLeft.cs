using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
public class TimeLeft : MonoBehaviour
{
    public int timeLeft = 5;
    private int timePrint;
    public Text countdown;
    public PlayerCollid play;



    void Start()
    {
        StartCoroutine("LoseTime");
        Time.timeScale = 1; 
    }
    void Update()
    {
        timePrint = timeLeft + play.increaseTime - play.decreaseTime;
        countdown.text = ("" + timePrint + " sec"); 

        if(timePrint <= 0)
        {
            StopCoroutine("LoseTime");
            countdown.text = ("TIME'S UP");
            FindObjectOfType<gameOver>().EndGame();
            Invoke("playSound", 0.5f);

        }
    }
    //Simple Coroutine
    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
    void playSound()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        Time.timeScale = 0f;

    }
}