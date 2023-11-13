using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected int scoreValue;
    [SerializeField] protected GameObject explosionPrefab;
    protected Animator animator;
    protected Rigidbody2D rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public void TakeDmg(float dmg)
    {
        hp -= dmg;
        Hurt();
        if(hp <= 0)
        {
            Die();
        }
    }

    public virtual void Hurt()
    {

    }

    public virtual void Die()
    {
        GameManager.Instance.UpdateScore(scoreValue);
    }
}
