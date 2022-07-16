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
    private Color boxColor,ballColor;
    private Color redColor= new Color(1.0f, 0.0f, 0.0f, 1.0f);
    private Color greenColor= new Color(0.0f, 1.0f, 0.0f, 1.0f);
    private Color blueColor= new Color(0.0f, 0.0f, 1.0f, 1.0f);

    // public 



    //as we are only enabling-deabling this text
    public GameObject winTextObject;
    private int count;
    private int redBoxCount;
    private int greenBoxCount;
    private int blueBoxCount;
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
        redBoxCount=0;
        greenBoxCount=0;
        blueBoxCount=0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX=movementVector.x;
        movementY=movementVector.y;
        // Debug.Log("onMove()");

    }
    void OnJump(){ //onAction
        if (isGrounded)
        {
            rb.AddForce(new Vector3(0f, 10.0f, 0f),ForceMode.Impulse);
            // Debug.Log("Jumped");
            isGrounded=false;   
        }
    }



    void SetCountText(){
        countText.text= "Red:" + redBoxCount.ToString() + "-Blue:" + blueBoxCount.ToString() + "-Green:" + greenBoxCount.ToString();
        if (greenBoxCount>=1 && redBoxCount>=2 && blueBoxCount>=1  )
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
            ballColor = gameObject.GetComponent<Renderer>().material.color;
            boxColor = other.gameObject.GetComponent<Renderer>().material.color;
            // boxColor= new Color(1.0f, 0.0f, 0.0f, 1.0f);
            

            if(boxColor.r==1.0f){
                // Debug.Log("Red");
                redBoxCount++;
            }
            if(boxColor.b==1.0f){
                // Debug.Log("Blue");
                blueBoxCount++;
            }
            if(boxColor.g==1.0f){
                // Debug.Log("Green");
                greenBoxCount++;
            }
            
            gameObject.GetComponent<Renderer>().material.color = ballColor + boxColor;
            // count=count+1;
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
