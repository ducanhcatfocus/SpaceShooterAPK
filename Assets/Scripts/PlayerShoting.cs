using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoting : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefabs;
    [SerializeField] float shootingInterval;


    [SerializeField] Transform shootPos;

    [SerializeField] Transform leftShootPos;

    [SerializeField] Transform rightShootPos;


    int upgradeLV = 0;



    private float intercalReset;

    private void Start()
    {
        intercalReset = shootingInterval;
    }

    private void Update()
    {
        shootingInterval -= Time.deltaTime;
        if(shootingInterval <= 0)
        {
            Shoot(); 
            shootingInterval = intercalReset;
        }
    }

    public void IncreaseLVCanon()
    {
        upgradeLV++;
        if(upgradeLV > 2)
        {
            upgradeLV = 2;
        }
    }

    public void DecreaseLVCanon()
    {
        upgradeLV--;
        if(upgradeLV < 0)
            upgradeLV = 0;
       
    }
    private void Shoot()
    {
       switch(upgradeLV)
        {
            case 0:
                Instantiate(bulletPrefabs, shootPos.position, Quaternion.identity);

                break;
            case 1:
                Instantiate(bulletPrefabs, leftShootPos.position, Quaternion.identity);
                Instantiate(bulletPrefabs, rightShootPos.position, Quaternion.identity);
                break;
            case 2:
                Instantiate(bulletPrefabs, leftShootPos.position, Quaternion.identity);
                Instantiate(bulletPrefabs, rightShootPos.position, Quaternion.identity);
                Instantiate(bulletPrefabs, shootPos.position, Quaternion.identity);
                break;
            default: break;
        }
    }
}
