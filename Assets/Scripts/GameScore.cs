using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{

    [SerializeField] private Text score;
    // Start is called before the first frame update
    ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();


    }



    // Update is called once per frame
    void Update()
    {
        print(scoreManager.score);
        score.text = scoreManager.score.ToString();
    }
}
