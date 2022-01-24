using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour{

    public GameObject player;

    public float currentHeight = 5;
    
    void Update(){

        if(player.transform.position.y >= currentHeight + 10){

            gameObject.transform.position = new Vector3(0, currentHeight + 20, -10);

            currentHeight += 20;

        }

        if(player.transform.position.y <= currentHeight - 10){

            gameObject.transform.position = new Vector3(0, currentHeight - 20, -10);

            currentHeight -= 20;

        }
        
    }

}
