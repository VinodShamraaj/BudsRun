using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Dan.Main;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private List<Text> names;
    [SerializeField] private List<Text> scores;

    [SerializeField] private Text firstName = null;
    [SerializeField] private Text firstScore = null;
    [SerializeField] private Text score = null;

    private ScoreManager scoreManager;

    private void Start() {
        GetLeaderboard();

        if(score) {
            scoreManager = FindObjectOfType<ScoreManager>();
            score.text = scoreManager.score.ToString();
        }
    }

    public void GetLeaderboard(){
        Leaderboards.bunsLeaderboard.GetEntries((msg)=> {
            int loopLength = (msg.Length < names.Count) ? msg.Length : names.Count;
            for (int i = 0; i < loopLength; ++i) {
                names[i].text = msg[i].Username;
                scores[i].text = msg[i].Score.ToString();
            }

            if(firstName && firstScore) {
                firstName.text = names[0].text;
                firstScore.text = scores[0].text;
            }
        });
    }

    public void SetLeaderboardEntry(string username, int score) {
        Leaderboards.bunsLeaderboard.UploadNewEntry(username, score, (msg) => {
            GetLeaderboard();
        });
    }
}
