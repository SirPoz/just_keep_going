using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public float attackDamage;
    public float knockBackForce;
    private SpriteRenderer spriteRenderer;
    GameObject player;
    Rigidbody2D rb;



    void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }


    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerEnergyHealth>().setCurrentHealth(col.gameObject.GetComponent<PlayerEnergyHealth>().getCurrentHealth() - attackDamage);
            Debug.Log("Dealt " + attackDamage + "damage to the player");
            player.GetComponent<PlayerMovement>().SwitchColor();
            if (player.GetComponent<PlayerMovement>().isFacingRight)
                player.GetComponent<Rigidbody2D>().AddForce(-knockBackForce * Vector2.right);
            else
                player.GetComponent<Rigidbody2D>().AddForce(knockBackForce * Vector2.right);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        //play hurt animation
        StartCoroutine(ColorSwitch());

        //knockback
        if (player.GetComponent<PlayerMovement>().isFacingRight) {
            rb.AddForce(player.GetComponent<PlayerMovement>().knockBackForce * Vector2.right);
        }
        else {
            rb.AddForce(player.GetComponent<PlayerMovement>().knockBackForce * -1 * Vector2.right);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
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
