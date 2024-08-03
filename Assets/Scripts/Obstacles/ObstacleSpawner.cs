using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;

    public float obstacleSpawnTime = 2f;
    public float obstacleSpeed = 2f;

    private float timeUntilSpawn;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= obstacleSpawnTime)
        {
            SpawnObstacle();
            timeUntilSpawn = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);

        GameObject spawnedObstacle = Instantiate(obstaclePrefabs[prefabIndex], transform.position, Quaternion.identity);
        spawnedObstacle.AddComponent(typeof(DestroyMyself));
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * obstacleSpeed;
    }

}
