using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpEffect : MonoBehaviour{

    void Awake(){

        Invoke("DestroyObject", 1f);

        gameObject.transform.parent = null;
        
    }

    public void DestroyObject(){

        Destroy(gameObject);

    }

}
