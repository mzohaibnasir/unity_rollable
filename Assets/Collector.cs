using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    public GameObject winTextObject;
    public  string OTHERBALLSTAG= "OtherBalls";
    
    // Start is called before the first frame update
    void Start(){
    }

void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag(OTHERBALLSTAG)){
                winTextObject.SetActive(true);
                // Debug.Log("SCORED");
        }

        

}

void OnTriggerExit(Collider other){
            winTextObject.SetActive(false);
            // Debug.Log("SCORED");
    }
    
}
