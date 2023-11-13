using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMiniBullet : MonoBehaviour
{
    [SerializeField] float dmg;
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        
        rb.velocity = transform.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDmg(dmg);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
