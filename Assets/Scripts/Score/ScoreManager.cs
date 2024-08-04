using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int coinScore = 50;
    [SerializeField] private int obstacleBonus = 20;
    [SerializeField] private int distanceBonus = 200;
    [SerializeField] private PlayerController playerController;

    public float score = 0;
    public Text scoreText;
    public Font customFont;
    private static SoundManager instance;

    private int coinCount;
    private int obstacleCount;

    void Start()
    {
        scoreText.font = customFont;
        scoreText.text = "Score: 0";

        UpdateScoreText();
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
        UpdateScoreText();
    }


    // when restart
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }


    // each time collect coin - multiple point
    public void MultiplyScore(int times)
    {
        score *= times;
        UpdateScoreText();
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


    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }



}
