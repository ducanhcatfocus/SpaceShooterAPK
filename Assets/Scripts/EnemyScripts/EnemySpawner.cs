using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies = new List<GameObject>();

    Camera mainCam;
    float maxLeft;
    float maxRight;
    float yPos;

    float maxLeftForGreen;
    float maxRightForGreen;
    float yPosMaxForGreen;
    float yPosMinForGreen;


    float enemyTimer;
    [SerializeField] float enemySpawnTime;

    [SerializeField] GameObject bossPrefab;
    [SerializeField] WinCondition winCondition;



    private void Start()
    {
        mainCam = Camera.main;
        StartCoroutine(SetBoundary());
    }

    private void Update()
    {
        EnemySpawn();
    }

    private void EnemySpawn()
    {
        enemyTimer += Time.deltaTime;
        if(enemyTimer >= enemySpawnTime)
        {
            int randomPick = Random.Range(0, enemies.Count);
            if(randomPick == 1)
            {
                Instantiate(enemies[randomPick], new Vector3(maxLeftForGreen, Random.Range(yPosMinForGreen, yPosMaxForGreen), 0), Quaternion.identity);
                Instantiate(enemies[0], new Vector3(Random.Range(maxLeft, maxRight), yPos, 0), Quaternion.identity);

                enemyTimer = 0;

                return;
            }
            if (randomPick == 2)
            {
                
                Instantiate(enemies[randomPick], new Vector3(maxRightForGreen, Random.Range(yPosMinForGreen, yPosMaxForGreen), 0), Quaternion.identity);


                enemyTimer = 0;
                return;
            }
            enemyTimer = 0;
        }
    }

    IEnumerator SetBoundary()
    {
        yield return new WaitForSeconds(0.4f);
        maxLeft = mainCam.ViewportToWorldPoint(new Vector2(0.15f, 0)).x;
        maxRight = mainCam.ViewportToWorldPoint(new Vector2(0.85f, 0)).x;
        yPos = mainCam.ViewportToWorldPoint(new Vector2(0, 1.1f)).y;
        maxLeftForGreen = mainCam.ViewportToWorldPoint(new Vector2(-0.15f, 0)).x;
        maxRightForGreen = mainCam.ViewportToWorldPoint(new Vector2(1.1f, 0)).x;
        yPosMaxForGreen = mainCam.ViewportToWorldPoint(new Vector2(0, 0.7f)).y;
        yPosMinForGreen = mainCam.ViewportToWorldPoint(new Vector2(0, 0.2f)).y;



    }

    private void OnDisable()
    {
        if(!winCondition.canSpawnBoss)
        {
            return;
        }
        if(bossPrefab != null)
        {
       

            Vector2 spawnBossPos = mainCam.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
            Instantiate(bossPrefab, spawnBossPos, Quaternion.identity);
        }
    }
}
