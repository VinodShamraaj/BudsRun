using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScoreTester : MonoBehaviour
{
    [SerializeField] private Text score;
    [SerializeField] private InputField username;

    public UnityEvent<string, int> submitScoreEvent;

    private ScoreManager scoreManager;

    private void Awake(){
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Start(){
        score.text = scoreManager.score.ToString();
    }

    public void SubmitScore(){
        submitScoreEvent.Invoke(username.text, int.Parse(score.text));
        HighScores.UploadScore(username.text, int.Parse(score.text));
    }
}
