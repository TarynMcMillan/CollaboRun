using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] int numberOfEnemies = 5;
    public int damageDealt;

    public GameObject GetEnemyPrefab()
    {
        return enemyPrefab;
    }
    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }
    public float GetTimeBetweenSpawns()
    {
         return timeBetweenSpawns;
    }
}
