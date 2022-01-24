using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SettingsMenu : MonoBehaviour{

    public GameObject settingsPanel;
    public GameObject jebaitPanel;
    public GameObject audioSource;

    public void BackToMainMenu(){

        SceneManager.LoadScene("MainMenu");

    }

    public void resetHighscore(){

        Debug.Log("Reset Highscore");

        PlayerPrefs.SetFloat("hoursHighscore", 0f);
        PlayerPrefs.SetFloat("minutesHighscore", 0f);
        PlayerPrefs.SetFloat("secondsHighscore", 0f);

    }

    public void Jebait(){

        Debug.Log("You got jebaited");

        settingsPanel.SetActive(false);
        jebaitPanel.SetActive(true);
        audioSource.SetActive(false);

        Invoke("unJebait", 40f);

    }

    public void unJebait(){

        Application.Quit();

    }
    
}
