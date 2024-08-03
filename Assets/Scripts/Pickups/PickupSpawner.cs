using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] pickupPrefabs;
    [SerializeField][Range(0, 5f)] private float heightRange = 3;
    [SerializeField] private float pickupSpawnTime = 4f;
    [SerializeField] private float pickupSpeed = 4f;
    [SerializeField] private float pickupDelay = 2f;

    private float timeUntilSpawn;
    private float startTime;
    private float originalSpawnTime;

    private void Awake()
    {
        originalSpawnTime = pickupSpawnTime;
    }

    private void Update()
    {
        if (startTime < pickupSpawnTime)
        {
            startTime += Time.deltaTime;
        }
        else
        {
            SpawnLoop();
        }
    }


    public void SetPickupSpeed(float speed)
    {
        pickupSpeed = speed;
    }

    public float GetOriginalPickupSpawnTime()
    {
        return originalSpawnTime;
    }

    public void SetPickupSpawnTime(float spawnTime)
    {
        pickupSpawnTime = spawnTime;
    }

    private void SpawnLoop()
    {
        timeUntilSpawn += Time.deltaTime;

        if (timeUntilSpawn >= pickupSpawnTime)
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

        obstacleRB.velocity = Vector2.left * pickupSpeed;
    }

}
