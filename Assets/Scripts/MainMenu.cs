using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MainMenu : MonoBehaviour{

    public float hours;
    public float minutes;
    public float seconds;

    public float hoursPlus;
    public float minutesPlus;
    public float secondsPlus;

    public Text hoursText;
    public Text minutesText;
    public Text secondsText;

    public Text hoursTextPlus;
    public Text minutesTextPlus;
    public Text secondsTextPlus;

    public GameObject newGamePlusObject;

    public int newGamePlusUnlocked;

    void Update(){

        newGamePlusUnlocked = PlayerPrefs.GetInt("gameWon");

        hours = PlayerPrefs.GetFloat("hoursHighscore");
        minutes = PlayerPrefs.GetFloat("minutesHighscore");
        seconds = PlayerPrefs.GetFloat("secondsHighscore");

        hoursPlus = PlayerPrefs.GetFloat("hoursHighscorePlus");
        minutesPlus = PlayerPrefs.GetFloat("minutesHighscorePlus");
        secondsPlus = PlayerPrefs.GetFloat("secondsHighscorePlus");

        hoursText.text = hours.ToString();
        minutesText.text = minutes.ToString();
        secondsText.text = seconds.ToString();

        hoursTextPlus.text = hoursPlus.ToString();
        minutesTextPlus.text = minutesPlus.ToString();
        secondsTextPlus.text = secondsPlus.ToString();

        if(newGamePlusUnlocked == 1){

            newGamePlusObject.SetActive(true);

        }
        else
        {

            newGamePlusObject.SetActive(false);

        }

    }

    public void NewGamePlus(){

        Debug.Log("New Game+");

        SceneManager.LoadScene("NewGamePlus");

    }

    public void PlayGame(){

        Debug.Log("Play Game");

        SceneManager.LoadScene("SampleScene");

    }

    public void Settings(){

        Debug.Log("Settings");

        SceneManager.LoadScene("Settings");

    }

    public void QuitToDesktop(){

        Debug.Log("Quit to Desktop");

        Application.Quit();

    }

}
