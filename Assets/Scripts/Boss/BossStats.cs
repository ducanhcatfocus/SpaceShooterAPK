using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : Enemy
{
    [SerializeField] BossController bossController;

    protected override void Start()
    {
        base.Start();
    }
    public override void Die()
    {
        base.Die();
        bossController.ChangeState(BossState.death);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);  
    }

    public override void Hurt()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Dmg"))
        {
            return;
        }
        animator.SetTrigger("Damage");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStats>().PlayerTakeDmg(dmg);
        }
    }

}
