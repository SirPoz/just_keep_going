using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(player.transform.position.x,0,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(player??false){
            player = GameObject.FindWithTag("Player");
        }
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
    }
}
