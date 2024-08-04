using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int coinScore = 50;
    [SerializeField] private int obstacleBonus = 20;
    [SerializeField] private int distanceBonus = 200;

    public float score = 0;
    public Text scoreText;
    public Font customFont;
    private static ScoreManager instance;
    private PlayerController playerController;
    private ObstacleSpawner obstacleSpawner;

    private int coinCount;
    private int obstacleCount;
    private int distance;

    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        obstacleSpawner = FindObjectOfType<ObstacleSpawner>();

        //UpdateScoreText();
    }

    private void Update()
    {
        if(Time.timeScale != 0) {
            distance = (int)(playerController.aliveTime / 60) + 1;
            AddScore(distance);
        }


        //if (obstacleSpawner != null && obstacleSpawner.obstacleSpeed > 0 && Time.timeScale != 0)
        //{
        //    distance = (int)(playerController.aliveTime / 60) + 1;
        //    AddScore(distance);
        //}
    }


    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void IncrementCoin()
    {
        coinCount++;
    }

    public void IncrementObstacle()
    {
        obstacleCount++;
    }


    // each time pass obstacle -  add some point
    public void AddScore(int points)
    {
        score += points;
        //UpdateScoreText();
    }


    // when restart
    public void ResetScore()
    {
        score = 0;
        //UpdateScoreText();
    }


    // each time collect coin - multiple point
    public void MultiplyScore(int times)
    {
        score *= times;
        //UpdateScoreText();
    }

    public int GetCoinCount()
    {
        return coinCount;
    }

    public float GetCoinScore()
    {
        return coinScore;
    }

    public float GetTotalCoinScore()
    {
        return coinScore * coinCount;
    }

    public float GetTotalDistanceScore()
    {
        return distanceBonus;

    }

    public float GetTotalScore()
    {
        return GetTotalCoinScore() + GetTotalDistanceScore();
    }


    //void UpdateScoreText()
    //{
    //    if (scoreText != null)
    //    {
    //        scoreText.text = score.ToString();
    //    }
    //}


}
