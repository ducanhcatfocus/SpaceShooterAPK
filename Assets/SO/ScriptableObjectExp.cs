using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/PowerUpSpawner", fileName ="Spawner")]
public class ScriptableObjectExp : ScriptableObject
{
    public int spawnThreshold;
    public GameObject[] powerUp;
    public void SpawnPowerUp(Vector3 spawnPos)
    {
        int randomChance = Random.Range(0, 100);
        if(spawnThreshold > randomChance )
        {
        int randomPowerUp = Random.Range(0, powerUp.Length);
        Instantiate(powerUp[randomPowerUp], spawnPos, Quaternion.identity);

        }

    }

}
