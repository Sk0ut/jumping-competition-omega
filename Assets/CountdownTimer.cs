using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{

    public GameObject TimerText;

    private void Start ()
    {
        Time.timeScale = 0;
        StartCoroutine("Countdown", 3);
    }

    private IEnumerator Countdown(int time)
    {
        while (time > 0)
        {
            TimerText.GetComponent<Text>().text = time.ToString();
            TimerText.GetComponent<Animator>().SetTrigger("FadeIn");
            Debug.Log(time--);
            yield return new WaitForSecondsRealtime(1);
        }
        Time.timeScale = 1;
        TimerText.GetComponent<Text>().text = "GO!";
        TimerText.GetComponent<Animator>().SetTrigger("FadeOut");
    }
}
