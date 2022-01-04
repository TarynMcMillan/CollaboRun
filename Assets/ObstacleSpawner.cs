using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public List<Obstacle> obstacles = new List<Obstacle>();
    Obstacle currentObstacle;
    private void Start()
    {
        SpawnObstacle();
    }

    private void Update()
    {
        
    }
    public void SpawnObstacle()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-1, 0), transform.position.z);
        int randomObstacle = Random.Range(0, obstacles.Count);
        currentObstacle = Instantiate(obstacles[randomObstacle], transform.position, Quaternion.identity);
        currentObstacle.transform.SetParent(this.transform, false);
    }
}
