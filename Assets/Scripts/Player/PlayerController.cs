using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float difficultyIncrease = 0.2f;
    [SerializeField] private float intervalReduction = 0.2f;
    [SerializeField] private float difficultyIncreaseTimer = 60f;
    [SerializeField] private ObstacleSpawner obstacleSpawner;
    [SerializeField] private BackgroundScroll backgroundScroll;
    private bool isCollision = true;

    private float gameTimer;


    // Start is called before the first frame update
    void Start()
    {
        gameTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;

        if (gameTimer > difficultyIncreaseTimer){
            IncreaseDifficulty();
            gameTimer = 0f;
        }
    }

    
    private void IncreaseDifficulty()
    {
        if (obstacleSpawner != null && backgroundScroll != null)
        {
            float speed = obstacleSpawner.obstacleSpeed += difficultyIncrease;
            float interval = obstacleSpawner.obstacleSpawnTime -= intervalReduction;

            obstacleSpawner.SetObstacleSpawnTime(interval);
            obstacleSpawner.SetObstacleSpeed(speed);
            backgroundScroll.SetBackgroundSpeed(speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Obstacle" && isCollision)
        {
            // Handle Collission stuff here
            Destroy(col.gameObject);
        }
    }

    public void SetCollision(bool collision)
    {
        isCollision = collision;
    }
}
