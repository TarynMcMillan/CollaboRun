using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    
    Material myMaterial;
    Vector2 offSet;
    public List<GameObject> obstacles = new List<GameObject>();

    // test
    public BoxCollider2D collider;
    public Rigidbody2D rb;
    private float width;
    public float scrollSpeed;

    void Start()
    {
        //myMaterial = GetComponent<Renderer>().material;
        //offSet = new Vector2(backgroundScrollSpeed, 0f);
        //SpawnObstacle();

        collider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();

        width = collider.size.x;
        collider.enabled = false;

        rb.velocity = new Vector2(scrollSpeed, 0);
        SpawnObstacle();
        
    }
    void Update()
    {
        if (transform.position.x < -width)
        {
            Vector2 resetPos = new Vector2(width * 2f, 0);
            transform.position = (Vector2)transform.position + resetPos;
            SpawnObstacle();
        }
       
    }

    void SpawnObstacle()
    {
        var spawnLocation = transform.GetChild(0);
        spawnLocation.localPosition = new Vector3(0, Random.Range(-3,3), 0);
        int randomObstacle = Random.Range(0, obstacles.Count);
        GameObject obstacleInstance = Instantiate(obstacles[randomObstacle], spawnLocation.position, Quaternion.identity);
        obstacleInstance.transform.SetParent(spawnLocation, false);
    }
}
