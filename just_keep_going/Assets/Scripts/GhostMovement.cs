using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    Rigidbody2D rb;
    int direction = -1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("test", 2.0f, 3f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(2 * direction, rb.velocity.y);
        //transform.position += new Vector3(-1, 0, 0);
    }

    void test(){
        direction = direction * -1;
        if(direction < 0){
            gameObject.transform.localScale = new Vector3(3, 3, 1);
        }
        else{
            gameObject.transform.localScale = new Vector3(-3, 3, 1);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.name == "Player"){
            Destroy(gameObject);
        }
    }

}
