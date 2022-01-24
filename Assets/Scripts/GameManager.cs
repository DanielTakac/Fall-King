using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;

public class GameManager : MonoBehaviour{

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
    
    public float playerX;
    public float playerY;
    public float cameraY;

    public float playerPositionX;
    public float playerPositionY;
    public float cameraPositionY;

    public string playerStringX;
    public string playerStringY;
    public string cameraStringY;

    public string playerPathX;
    public string playerPathY;
    public string cameraPathY;

    public bool gameWon = false;
    public bool gameLoaded = false;
    public bool creditsStarted = false;
    
    public int firstScoreSave;

    private MusicSpeakerCode musicSpeaker;
    private EndMusicSpeakerCode endMusicSpeaker;
    private Timer timerCode;

    public float hoursHighscore;
    public float minutesHighscore;
    public float secondsHighscore;

    public float currentHoursHighscore;
    public float currentMinutesHighscore;
    public float currentSecondsHighscore;

    public float gameWon1;

    void Start(){

        creditsStarted = false;

        playerPathX = Application.dataPath + "/PlayerSaveFileX.txt";
        playerPathY = Application.dataPath + "/PlayerSaveFileY.txt";
        cameraPathY = Application.dataPath + "/CameraSaveFileY.txt";

        timerCode = panel5.GetComponent<Timer>();

        musicSpeaker = musicSpeakerObject.GetComponent<MusicSpeakerCode>();
        endMusicSpeaker = endMusicSpeakerObject.GetComponent<EndMusicSpeakerCode>();
        
    }

    void Update(){

        firstScoreSave = PlayerPrefs.GetInt("firstScoreSave");

        gameWon1 = PlayerPrefs.GetInt("gameWon");

        if (gameWon1 == 1){

            gameWon = true;

        }

        if (Input.GetKey("j")){

            firstScoreSave = 0;

            PlayerPrefs.SetInt("firstScoreSave", 0);

            Debug.Log("First Score Save Reset");

        }

        if (Input.GetKey("e")){

            player.transform.position = new Vector3(player.transform.position.x, 210, player.transform.position.z);

        }

        if (creditsStarted == false){

            if (player.transform.position.x >= -3f && player.transform.position.y >= 215){

                panel3.SetActive(true);

                creditsStarted = true;

                gameWon = true;

                musicSpeakerObject.SetActive(false);
                endMusicSpeakerObject.SetActive(true);

                Invoke("StartCredits", 10f);

            }

        }

        if (Input.GetKey("r")){

            Debug.Log("Restart");

            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

        if (Input.GetKey("escape")){

            Debug.Log("Escape");

            panel.SetActive(true);

        }

        cameraY = mainCamera.transform.position.y;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;

        if (gameLoaded){

            SaveGame();

        }

        currentHoursHighscore = PlayerPrefs.GetFloat("hoursHighscore");
        currentMinutesHighscore = PlayerPrefs.GetFloat("minutesHighscore");
        currentSecondsHighscore = PlayerPrefs.GetFloat("secondsHighscore");

        if(gameWon == true){

            crown.SetActive(true);

        }

    }

    public void SaveHighscore(){

        Debug.Log("Saving Highscore");

        if (timerCode.minutes < currentMinutesHighscore){

            hoursHighscore = timerCode.hours;
            minutesHighscore = timerCode.minutes;
            secondsHighscore = timerCode.seconds;
        
        }

        if (firstScoreSave == 0){

            hoursHighscore = timerCode.hours;
            minutesHighscore = timerCode.minutes;
            secondsHighscore = timerCode.seconds;

            firstScoreSave = 2;

            PlayerPrefs.SetInt("firstScoreSave", 2);

        }

        PlayerPrefs.SetFloat("hoursHighscore", hoursHighscore);
        PlayerPrefs.SetFloat("minutesHighscore", minutesHighscore);
        PlayerPrefs.SetFloat("secondsHighscore", secondsHighscore);
        PlayerPrefs.Save();

    }

    public void StartCredits(){

        PlayerPrefs.SetInt("gameWon", 1);

        panel3.SetActive(false);
        panel4.SetActive(true);
        panel5.SetActive(false);

        SaveHighscore();

        Invoke("EndCredits", 10);

    }

    public void EndCredits(){

        panel4.SetActive(false);

        SceneManager.LoadScene("MainMenu");

    }

    public void SaveGame(){

        PlayerPrefs.SetFloat("playerPositionX", playerX);
        PlayerPrefs.SetFloat("playerPositionY", playerY);
        PlayerPrefs.SetFloat("cameraPositionY", cameraY);
        PlayerPrefs.Save();

    }

    public void ContinueGame(){

        Debug.Log("Continue Game");

        playerPositionX = PlayerPrefs.GetFloat("playerPositionX");
        playerPositionY = PlayerPrefs.GetFloat("playerPositionY");
        cameraPositionY = PlayerPrefs.GetFloat("cameraPositionY");

        player.transform.position = new Vector3(playerPositionX, playerPositionY, player.transform.position.z);

        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, cameraPositionY, mainCamera.transform.position.z);
        
        panel2.SetActive(false);

        gameLoaded = true;

        panel5.SetActive(true);

        timerCode.hours = 0f;
        timerCode.minutes = 0f;
        timerCode.seconds = 0f;

    }

    public void NewGame(){

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

    public void Continue(){

        panel.SetActive(false);

    }

    public void QuitToMainMenu(){

        Debug.Log("Quit to Main Menu");

        SceneManager.LoadScene("MainMenu");

        gameLoaded = false;

    }

    public void QuitToDesktop(){

        Debug.Log("Quit to Desktop");

        Application.Quit();

    }

}
