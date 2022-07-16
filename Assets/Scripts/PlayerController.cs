using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed=10.0f;
    public TextMeshProUGUI countText;



    //as we are only enabling-deabling this text
    public GameObject winTextObject;
    private int count;

    private Rigidbody rb;
    private float movementX;
    
    private float movementY;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void onMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX=movementVector.x;
        movementY=movementVector.y;
        Debug.Log("onMove()");

    }

    void SetCountText(){
        countText.text= "Count: " + count.ToString();
        if (count>=2)
        {
                          winTextObject.SetActive(true);
      
        }
    }

    void FixedUpdate(){
        Vector3 movement = new Vector3(movementX,0.0f,movementY);
        rb.AddForce(movement*speed);  
    }

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);//disabling object
            count=count+1;
            SetCountText();

        }
    }
    


   
}
