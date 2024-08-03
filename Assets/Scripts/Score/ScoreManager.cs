using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class ScoreManager : MonoBehaviour
{
    public float score = 0; 
    public Text scoreText;
    public Font customFont; 
    private static SoundManager instance;


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

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

   

}
