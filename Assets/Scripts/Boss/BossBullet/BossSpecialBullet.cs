using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialBullet : MonoBehaviour
{
    [SerializeField] float dmg;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject miniBulletPrefab;
    [SerializeField] Transform[] spawnPos;


    private void Start()
    {
        rb.velocity = Vector2.down * speed;
        StartCoroutine(Explode());
    }

    private void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }

    IEnumerator Explode()
    {
        float randomExplodeTime = Random.Range(1.5f, 4.5f);
        yield return new WaitForSeconds(randomExplodeTime);
        for (int i = 0; i < spawnPos.Length; i++)
        {
            Instantiate(miniBulletPrefab, spawnPos[i].position, spawnPos[i].rotation);
        }
        Destroy(gameObject);

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
