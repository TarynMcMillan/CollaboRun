using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<GameObject> obstacles = new List<GameObject>();

    private void Start()
    {
        SpawnObstacle();
    }

    private void Update()
    {
        
    }
    void SpawnObstacle()
    {
        transform.position = new Vector3(0, Random.Range(-3, 3), 0);
        int randomObstacle = Random.Range(0, obstacles.Count);
        GameObject obstacleInstance = Instantiate(obstacles[randomObstacle], transform.position, Quaternion.identity);
        obstacleInstance.transform.SetParent(this.transform, false);
    }
}
