using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Weapon : MonoBehaviour
{
    public float attackRange = 1f;
    public Vector3 attackOffset;
    public LayerMask attackMask;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Attack()
    {
        Vector3 pos = this.transform.Find("pivot").transform.position;
        pos += this.transform.Find("pivot").transform.right * attackOffset.x;
        pos += this.transform.Find("pivot").transform.up * attackOffset.y;

        Collider2D col = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (col != null)
        {
            this.GetComponent<DamageHandler>().Attack();
        }
        Debug.Log("Boss has hit the player");
    }

    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
