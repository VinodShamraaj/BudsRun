using System.Collections;
// using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHighscores : MonoBehaviour 
{
    public Text[] rNames;
    public Text[] rScores;
    HighScores myScores;

    [SerializeField] private Text firstName = null;
    [SerializeField] private Text firstScore = null;
    [SerializeField] private Text score = null;

    private ScoreManager scoreManager;

    void Start() //Fetches the Data at the beginning
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = i + 1 + ". Fetching...";
        }
        myScores = GetComponent<HighScores>();
        StartCoroutine("RefreshHighscores");

        if(score) {
            scoreManager = FindObjectOfType<ScoreManager>();
            score.text = scoreManager.score.ToString();
        }
    }

    public void SetScoresToMenu(PlayerScore[] highscoreList) //Assigns proper name and score for each text value
    {
        for (int i = 0; i < rNames.Length;i ++)
        {
            rNames[i].text = "NAME";
            if (highscoreList.Length > i)
            {
                rScores[i].text = highscoreList[i].score.ToString();
                rNames[i].text = highscoreList[i].username;
            }

            if(firstName && firstScore) {
                firstName.text = rNames[0].text;
                firstScore.text = rScores[0].text;
            }
        }
    }
    IEnumerator RefreshHighscores() //Refreshes the scores every 30 seconds
    {
        while(true)
        {
            myScores.DownloadScores();
            yield return new WaitForSeconds(30);
        }
    }
}
