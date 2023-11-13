using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mete : Enemy
{
    [SerializeField] float minSpeed;
    [SerializeField] float maxSpeed;
    float speed;
    [SerializeField] float rotateSpeed;
    [SerializeField] ScriptableObjectExp powerUpSpawner;


    protected override void Start()
    {
        base.Start();
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        RotateMeteor();
    }
     
    private void RotateMeteor()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    public override void Die()
    {
        base.Die();
        if(powerUpSpawner != null)
        {
            powerUpSpawner.SpawnPowerUp(transform.position); 
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    public override void Hurt()
    {
        base.Hurt();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStats player = other.GetComponent<PlayerStats>();
            player.PlayerTakeDmg(dmg);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);

        } 

    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }


}
