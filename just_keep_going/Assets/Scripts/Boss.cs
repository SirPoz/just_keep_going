using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 2.5f;
    public float attackRange = 3f;
    public Transform player;
    bool isFlipped = false;
    public Transform pivot;
    private SpriteRenderer spriteRenderer;

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;
        if(pivot.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if(pivot.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(GetComponent<DamageHandler>().currentHealth <= 500)
        {
            GetComponent<Animator>().SetTrigger("secondPhase");
            spriteRenderer.color = new Color(1, 0, 0, 1);
            GetComponent<Animator>().ResetTrigger("secondPhase");
            speed = 5f;
        }
    }
}
