using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset; //camera's offset value
    // Start is called before the first frame update
    void Start()
    {
        offset =transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate() //for followcameras and gathering last known states //runs every frame like Update()
    // but runs after all of the updates are done
    {
        transform.position=player.transform.position+offset;
        //camera pos will only be set once player has moved from that frame
    }
}
