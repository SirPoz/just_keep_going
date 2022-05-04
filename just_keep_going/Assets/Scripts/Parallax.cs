using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float Length;           //length of sprite
    private float StartingPosition; //starting position of sprite
    public float ParallaxEffect;     //modifiable Parallaxeffect

    private void Start()
    {
        StartingPosition = transform.position.x;                //Startposition
        Length = GetComponent<SpriteRenderer>().bounds.size.x;  //length
    }

    private void Update()
    {
       // var temp = Camera.main.transform.position.x * -1 - ParallaxEffect;
        var distance = Camera.main.transform.position.x * ParallaxEffect;    //distance from startposition

        transform.position = new Vector3(StartingPosition + distance, transform.position.y, transform.position.z);  //moveCamera

        /*
        if (temp > StartingPosition + Length)
        {
            StartingPosition += Length;
        }
        else if (temp < StartingPosition - Length)
        {
            StartingPosition -= Length;
        }
        */
    }
}