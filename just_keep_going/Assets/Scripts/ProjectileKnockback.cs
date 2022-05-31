using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileKnockback : MonoBehaviour
{
    public float knockBackForce;
    private SpriteRenderer spriteRenderer;
    public GameObject Enemy;
    Rigidbody2D rb;
    Rigidbody2D EnemyRB;

    void Start()
    {
        Enemy = GameObject.FindWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        EnemyRB = Enemy.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("?");
            Attack();
        }
    }

    public void Attack()
    {
        Debug.Log("Test");
        EnemyRB.AddForce(-knockBackForce * Vector2.right);
        //player.GetComponent<Rigidbody2D>().AddForce(knockBackForce * Vector2.right);
    }

    public void takeDamage(float damage)
    {

        //play hurt animation
        //StartCoroutine(ColorSwitch());

        //knockback
    }

    void Die()
    {
        Debug.Log("Enemy died");

        //play death animation

        Destroy(gameObject);
    }

    IEnumerator ColorSwitch()
    {
        //Change the color instantly to new color
        spriteRenderer.color = new Color(1, 0, 0, 1);

        //Wait for .2 seconds
        yield return new WaitForSeconds(0.2f);

        //Switch to the previous color
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
