using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabs;
    [SerializeField][Range(0, 5f)] private float heightRange = 3;

    public float powerUpSpawnTime = 2f;
    public float powerUpSpeed = 4f;

    private float timeUntilSpawn;

    private void Update()
    {
        SpawnLoop();
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= powerUpSpawnTime)
        {
            SpawnObstacle();
            timeUntilSpawn = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int prefabIndex = Random.Range(0, pickupPrefabs.Length);

        float height = Random.Range(0, heightRange);

        Vector3 newTransform = transform.position + new Vector3(0, height, 0);

        GameObject spawnedObstacle = Instantiate(pickupPrefabs[prefabIndex], newTransform, Quaternion.identity);
        spawnedObstacle.AddComponent(typeof(DestroyMyself));
        Rigidbody2D obstacleRB = spawnedObstacle.GetComponent<Rigidbody2D>();

        obstacleRB.velocity = Vector2.left * powerUpSpeed;
    }

}
