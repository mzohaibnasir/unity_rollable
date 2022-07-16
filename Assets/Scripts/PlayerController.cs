using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed=10.0f;
    public float jumpForce=10.0f;
    public TextMeshProUGUI countText;
    private bool isGrounded;

    // public 



    //as we are only enabling-deabling this text
    public GameObject winTextObject;
    private int count;
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    private string GROUND_TAG = "Ground";



    public void Awake(){
        // PlayerInputActions inputAction = new PlayerInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
        count=0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX=movementVector.x;
        movementY=movementVector.y;
        Debug.Log("onMove()");

    }
    void OnJump(){ //onAction
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0f, 10.0f, 0f),ForceMode.Impulse);
            Debug.Log("Jumped");
            isGrounded=false;   
        }
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
        // playerJump();
    }

    

    void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("pickUp"))
        {
            other.gameObject.SetActive(false);//disabling object
            count=count+1;
            SetCountText();

        }
    }

     private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded=true;
        }
     }
    


   
}
