using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkEnemy : Enemy
{
    [SerializeField] Transform leftCanonPos;
    [SerializeField] Transform rightCanonPos;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float speed;
    [SerializeField] float shootInterval;
    float shootTimer;
    protected override void Start()
    {
        base.Start();
        rb.velocity = Vector3.down * speed;
    }

    private void Update()
    {
        shootTimer += Time.deltaTime;
        if(shootTimer >= shootInterval)
        {
            Instantiate(bulletPrefab, leftCanonPos.position, Quaternion.identity);

            Instantiate(bulletPrefab, rightCanonPos.position, Quaternion.identity);
            shootTimer = 0;

        }
    }
    public override void Die()
    {
        base.Die();
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public override void Hurt()
    {
        base.Hurt();
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
            return;
        animator.SetTrigger("Damaged");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDmg(dmg);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
