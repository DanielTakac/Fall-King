using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour{

    public Text hoursText;
    public Text minutesText;
    public Text secondsText;

    public float hours = 0f;
    public float minutes = 0f;
    public float seconds = 0f;

    void Update(){

        seconds += Time.deltaTime;

        hoursText.text = hours.ToString();
        minutesText.text = minutes.ToString();
        secondsText.text = seconds.ToString();

        if (seconds >= 59.5f && seconds <= 60.0f){

            seconds = 0f;

            minutes += 1f;

        }

        if (minutes >= 59.5f && minutes <= 60.0f){

            minutes = 0f;

            hours += 1f;

        }

    }

}
