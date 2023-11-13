using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    int hitsTodestroy = 3;
    public bool protection = false;

    [SerializeField] GameObject[] shieldBase;

    private void OnEnable()
    {
        hitsTodestroy = 3;
        for (int i = 0; i < shieldBase.Length; i++)
        {
            shieldBase[i].SetActive(true);
        }
        protection = true;


    }

    private void UpdateIUShieldIcon()
    {
        switch (hitsTodestroy)
        {
            case 0:
                for (int i = 0; i < shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(false);
                }
                break;
            case 1:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(false);
                shieldBase[2].SetActive(false);
                break;
            case 2:
                shieldBase[0].SetActive(true);
                shieldBase[1].SetActive(true);
                shieldBase[2].SetActive(false);
                break;
            case 3:
                for (int i = 0; i < shieldBase.Length; i++)
                {
                    shieldBase[i].SetActive(true);
                }
                break;
            default:
                Debug.Log("sth wrong");
                break;
        }
    }

    private void DamageShield()
    {
        hitsTodestroy-= 1;
        if(hitsTodestroy <= 0)
        {
            hitsTodestroy = 0;
            protection = false;
            gameObject.SetActive(false);
        }
        UpdateIUShieldIcon();
    }

    public void RepairShield()
    {
        hitsTodestroy = 3;
        UpdateIUShieldIcon();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            if (collision.CompareTag("Boss"))
            {
                DamageShield();
                return;

            }
            enemy.TakeDmg(1000);
            DamageShield();
        }
        else
        {
            Destroy(collision.gameObject);
            DamageShield();
        }
    }
}
