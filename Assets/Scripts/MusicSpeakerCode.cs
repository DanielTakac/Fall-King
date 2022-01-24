using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class MusicSpeakerCode : MonoBehaviour{

    public GameObject Camera;

    public AudioSource audioSource;

    void Update(){

        gameObject.transform.position = Camera.transform.position;
        
    }

    public void PlayMusic1(){

        //audioSource.Play();

    }

}
