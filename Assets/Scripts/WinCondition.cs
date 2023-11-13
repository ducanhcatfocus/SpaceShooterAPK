using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    private float timer;
    [SerializeField] private float possibleWinTime;
    [SerializeField] private GameObject[] spawner;
    [SerializeField] private bool hasBoss;
    public bool canSpawnBoss = false;


    private void Update()
    {
        if(GameManager.Instance.gameOver)
        {
            return;
        }
        timer += Time.deltaTime;
        if(timer >= possibleWinTime)
        {
            if (hasBoss == false)
            {
                GameManager.Instance.StartResolveGame();
            }
            else
            {
                canSpawnBoss = true;
            }
            for (int i = 0; i < spawner.Length; i++)
            {
                spawner[i].SetActive(false);
              
       
            }
                    gameObject.SetActive(false);
        }
    }
}
