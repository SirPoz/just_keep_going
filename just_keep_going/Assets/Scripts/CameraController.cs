using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float cameraOffsetY;
    public float cameraOffsetX;

    // Start is called before the first frame update
    void Start()
    {
        player = null;
        /*player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(player.transform.position.x,0,transform.position.z);*/
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null){
            Debug.Log("Test");
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            float offsetY =  player.transform.position.y + cameraOffsetY;
            float offsetX = player.transform.position.x + cameraOffsetX;
            transform.position = new Vector3(offsetX, offsetY,transform.position.z);
        }
        
    }

    
}
