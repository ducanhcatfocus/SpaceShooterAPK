using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    
    [SerializeField] Slider hpBar;
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] ShieldPowerUp shield;
    Animator animator;
    PlayerShoting playerShoting;

    [SerializeField] float maxHp;
    float currentHp;

    bool canPlayAnimWhenTakeDmg = true;
    void Start()
    {
        animator = GetComponent<Animator>();   
        playerShoting = GetComponent<PlayerShoting>();
        currentHp = maxHp;
        hpBar.value = currentHp/maxHp;
        GameManager.Instance.gameOver = false;
    }

    

    public void PlayerTakeDmg(float dmg)
    {
        if (shield.protection)
            return;
        currentHp -= dmg;
        hpBar.value = currentHp / maxHp;
        if(canPlayAnimWhenTakeDmg )
        {
            animator.SetTrigger("Damaged");
            StartCoroutine(AntiSpamAnimateWhenTakeDmg());

        }
        playerShoting.DecreaseLVCanon();

        if (currentHp <=0)
        {
            GameManager.Instance.gameOver = true;
            GameManager.Instance.StartResolveGame();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    public void PlayerHeal(int healAmount)
    {
        currentHp += healAmount;
        if(currentHp >maxHp) {
        currentHp = maxHp;}
        hpBar.value = currentHp / maxHp;


    }

    IEnumerator AntiSpamAnimateWhenTakeDmg()
    {
        canPlayAnimWhenTakeDmg = false;
        yield return new WaitForSeconds(0.2f);
        canPlayAnimWhenTakeDmg = true;
    }
}
