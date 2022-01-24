using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameManagerPlus : MonoBehaviour{

    public GameObject endMusicSpeakerObject;
    public GameObject musicSpeakerObject;
    public GameObject mainCamera;
    public GameObject player;
    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject panel4;
    public GameObject panel5;
    public GameObject crown;

    public float playerXPlus;
    public float playerYPlus;
    public float cameraYPlus;

    public float playerPositionXPlus;
    public float playerPositionYPlus;
    public float cameraPositionYPlus;

    public string playerStringX;
    public string playerStringY;
    public string cameraStringY;

    public string playerPathX;
    public string playerPathY;
    public string cameraPathY;

    public bool gameWon = false;
    public bool gameLoaded = false;
    public bool creditsStarted = false;

    public int firstScoreSavePlus;

    private MusicSpeakerCode musicSpeaker;
    private EndMusicSpeakerCode endMusicSpeaker;
    private Timer timerCode;

    public float hoursHighscorePlus;
    public float minutesHighscorePlus;
    public float secondsHighscorePlus;

    public float currentHoursHighscorePlus;
    public float currentMinutesHighscorePlus;
    public float currentSecondsHighscorePlus;

    public float gameWon1;

    void Start()
    {

        creditsStarted = false;

        playerPathX = Application.dataPath + "/PlayerSaveFileX.txt";
        playerPathY = Application.dataPath + "/PlayerSaveFileY.txt";
        cameraPathY = Application.dataPath + "/CameraSaveFileY.txt";

        timerCode = panel5.GetComponent<Timer>();

        musicSpeaker = musicSpeakerObject.GetComponent<MusicSpeakerCode>();
        endMusicSpeaker = endMusicSpeakerObject.GetComponent<EndMusicSpeakerCode>();

    }

    void Update()
    {

        firstScoreSavePlus = PlayerPrefs.GetInt("firstScoreSavePlus");

        gameWon1 = PlayerPrefs.GetInt("gameWon");

        if (gameWon1 == 1)
        {

            gameWon = true;

        }

        if (Input.GetKey("j"))
        {

            firstScoreSavePlus = 0;

            PlayerPrefs.SetInt("firstScoreSave", 0);

            Debug.Log("First Score Save Reset");

        }

        /*
        if (Input.GetKey("e"))
        {

            player.transform.position = new Vector3(player.transform.position.x, 300, player.transform.position.z);

        }
        */

        if (creditsStarted == false)
        {

            if (player.transform.position.x >= -3f && player.transform.position.y >= 315)
            {

                panel3.SetActive(true);

                creditsStarted = true;

                gameWon = true;

                musicSpeakerObject.SetActive(false);
                endMusicSpeakerObject.SetActive(true);

                Invoke("StartCredits", 10f);

            }

        }

        if (Input.GetKey("r"))
        {

            Debug.Log("Restart");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKey("escape"))
        {

            Debug.Log("Escape");

            panel.SetActive(true);

        }

        cameraYPlus = mainCamera.transform.position.y;
        playerXPlus = player.transform.position.x;
        playerYPlus = player.transform.position.y;

        if (gameLoaded)
        {

            SaveGame();

        }

        currentHoursHighscorePlus = PlayerPrefs.GetFloat("hoursHighscorePlus");
        currentMinutesHighscorePlus = PlayerPrefs.GetFloat("minutesHighscorePlus");
        currentSecondsHighscorePlus = PlayerPrefs.GetFloat("secondsHighscorePlus");

        if (gameWon == true)
        {

            crown.SetActive(true);

        }

    }

    public void SaveHighscore()
    {

        Debug.Log("Saving Highscore");

        if (timerCode.minutes < currentMinutesHighscorePlus)
        {

            hoursHighscorePlus = timerCode.hours;
            minutesHighscorePlus = timerCode.minutes;
            secondsHighscorePlus = timerCode.seconds;

        }

        if (firstScoreSavePlus == 0)
        {

            hoursHighscorePlus = timerCode.hours;
            minutesHighscorePlus = timerCode.minutes;
            secondsHighscorePlus = timerCode.seconds;

            firstScoreSavePlus = 2;

            PlayerPrefs.SetInt("firstScoreSave", 2);

        }

        PlayerPrefs.SetFloat("hoursHighscorePlus", hoursHighscorePlus);
        PlayerPrefs.SetFloat("minutesHighscorePlus", minutesHighscorePlus);
        PlayerPrefs.SetFloat("secondsHighscorePlus", secondsHighscorePlus);
        PlayerPrefs.Save();

    }

    public void StartCredits()
    {

        PlayerPrefs.SetInt("gameWon", 1);

        panel3.SetActive(false);
        panel4.SetActive(true);
        panel5.SetActive(false);

        SaveHighscore();

        Invoke("EndCredits", 10);

    }

    public void EndCredits()
    {

        panel4.SetActive(false);

        SceneManager.LoadScene("MainMenu");

    }

    public void SaveGame()
    {

        PlayerPrefs.SetFloat("playerPositionXPlus", playerXPlus);
        PlayerPrefs.SetFloat("playerPositionYPlus", playerYPlus);
        PlayerPrefs.SetFloat("cameraPositionYPlus", cameraYPlus);
        PlayerPrefs.Save();

    }

    public void ContinueGame()
    {

        Debug.Log("Continue Game");

        playerPositionXPlus = PlayerPrefs.GetFloat("playerPositionXPlus");
        playerPositionYPlus = PlayerPrefs.GetFloat("playerPositionYPlus");
        cameraPositionYPlus = PlayerPrefs.GetFloat("cameraPositionYPlus");

        player.transform.position = new Vector3(playerPositionXPlus, playerPositionYPlus, player.transform.position.z);

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraPositionYPlus, mainCamera.transform.position.z);

        panel2.SetActive(false);

        gameLoaded = true;

        panel5.SetActive(true);

        timerCode.hours = 0f;
        timerCode.minutes = 0f;
        timerCode.seconds = 0f;

    }

    public void NewGame()
    {

        Debug.Log("New Game");

        player.transform.position = new Vector3(-6f, 1.25f, 0f);

        panel2.SetActive(false);

        gameLoaded = true;

        gameWon = false;

        panel5.SetActive(true);

        timerCode.hours = 0f;
        timerCode.minutes = 0f;
        timerCode.seconds = 0f;

    }

    public void Continue()
    {

        panel.SetActive(false);

    }

    public void QuitToMainMenu()
    {

        Debug.Log("Quit to Main Menu");

        SceneManager.LoadScene("MainMenu");

        gameLoaded = false;

    }

    public void QuitToDesktop()
    {

        Debug.Log("Quit to Desktop");

        Application.Quit();

    }

}
