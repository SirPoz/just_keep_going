using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public float damage;
    public float knockBackForce;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.GetComponent<PlayerEnergyHealth>().setCurrentHealth(col.gameObject.GetComponent<PlayerEnergyHealth>().getCurrentHealth() - damage);
            Debug.Log("Dealt " + damage + "damage to the player");
            if(col.gameObject.GetComponent<PlayerMovement>().isFacingRight)
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(-knockBackForce * Vector2.right);
            else
                col.gameObject.GetComponent<Rigidbody2D>().AddForce(knockBackForce * Vector2.right);
        }
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        //play hurt animation

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
}
