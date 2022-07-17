using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collector : MonoBehaviour
{

    public GameObject winTextObject;
    public GameObject gameoverTextObject;

    private  string OTHERBALLSTAG= "OtherBalls";
    private  string PLAYERTAG= "Player";
    
    // Start is called before the first frame update
    void Start(){
        gameoverTextObject.SetActive(false);
        winTextObject.SetActive(false);

    }

void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(OTHERBALLSTAG)){
                winTextObject.SetActive(true);
                // Debug.Log("SCORED");
        }

        if(other.gameObject.CompareTag(PLAYERTAG)){
                gameoverTextObject.SetActive(true);
                // Debug.Log("SCORED");
        }

        

}

void OnTriggerExit(Collider other){
            winTextObject.SetActive(false);
            // gameoverTextObject.SetActive(false);

            // Debug.Log("SCORED");
    }
    
}
