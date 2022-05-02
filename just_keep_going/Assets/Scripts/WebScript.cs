using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebScript : MonoBehaviour
{
    Rigidbody2D rb;
    int count = 1;
    int count2 = 0;
    int direction = -1;
    int dir_save;
    // Start is called before the first frame update
    void Start()
    {
        dir_save = direction;
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
            count++;
        }
        else if(count % 3 == 0){
            if(count2 % 2 == 0){
                count2++;
                //direction = 0;
            }
            else{
                count = 1;
                direction = (dir_save * -1);
                dir_save = direction;
                count2++;
            }
        }
        else{
            direction = (dir_save * -1);
            count++;
        }
    }

}