using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    public float attackDamage;
    public float knockBackForce;
    public float knockBackForce2 = 100000;
    private SpriteRenderer spriteRenderer;
    public GameObject player;
    Rigidbody2D rb;

    void Start()
    {
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
            Attack();
        }
        if (col.gameObject.tag == "projectile")
        {
            projectile();
        }
    }

    public void Attack()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<PlayerEnergyHealth>().setCurrentHealth(player.GetComponent<PlayerEnergyHealth>().getCurrentHealth() - attackDamage);
        Debug.Log("Dealt " + attackDamage + "damage to the player");
        player.GetComponent<PlayerMovement>().SwitchColor();
        if (player.GetComponent<PlayerMovement>().isFacingRight)
            player.GetComponent<Rigidbody2D>().AddForce(-knockBackForce * Vector2.right);
        else
            player.GetComponent<Rigidbody2D>().AddForce(knockBackForce * Vector2.right);
    }

    public void projectile()
    {
        player = GameObject.FindWithTag("Player");
        if (player.GetComponent<PlayerMovement>().isFacingRight){
            Debug.Log("OK");
            GetComponent<Rigidbody2D>().AddForce(knockBackForce2 * Vector2.right);
        }
        else
            GetComponent<Rigidbody2D>().AddForce(-knockBackForce2 * Vector2.right);
    }

    public void takeDamage(float damage)
    {
        player = GameObject.FindWithTag("Player");
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }

        //play hurt animation
        StartCoroutine(ColorSwitch());

        //knockback
        if (player.GetComponent<PlayerMovement>().isFacingRight) {
            rb.AddForce(player.GetComponent<PlayerMovement>().knockBackForce * Vector2.right);
        }
        else {
            rb.AddForce(player.GetComponent<PlayerMovement>().knockBackForce * -1 * Vector2.right);
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
