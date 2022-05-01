using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length, startpos; //length and start pos of sprite
    public GameObject camera;       //Camera
    public float parallaxEffect;    //modifiable Parallaxeffect


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;                        //Startposition
        length = GetComponent<SpriteRenderer>().bounds.size.x;  //length
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = (camera.transform.position.x * parallaxEffect);    //distance from startposition

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);      //moveCamera
    }
}
