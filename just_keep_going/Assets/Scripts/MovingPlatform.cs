using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed;         //  speed of platform
    public int startingPoint;   //  starting index (position of the platform)
    public Transform[] points;  // An array of transform points (positions where the platform needs to move)

    private int i; //   index of the array
    // Start is called before the first frame update
    void Start()
    {
        transform.position = points[startingPoint].position;    //  setting the position of the platform to
                                                                // the position of one of the points using index "startingPoint"
    }

    // Update is called once per frame
    void Update()
    {

    // checking the distance of the platform and the point
        if(Vector2.Distance(transform.position, points[i].position)< 0.02f)
        {
            i++;    //increase the index
            if (i==points.Length) //check if the platform was on the last point after the index increase
            {
                i=0; // reset index
            }
        }

        //  moving the platform to the point position with the index "i"
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.setParent(transform);       //Player does not fall off the platform
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.setParent(null);
    }
    */






}
