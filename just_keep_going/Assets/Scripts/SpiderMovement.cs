using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    Rigidbody2D rb;
    int count = 0;
    int direction = -1;
    int dir_save;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("test", 2.0f, 2f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, 2 * direction);
        //transform.position += new Vector3(-1, 0, 0);
    }

    void test(){
        if(count % 2 == 0){
            dir_save = direction;
            direction = 0;
        }
        else{
            direction = dir_save * -1;
        }
        count++;
    }

}

