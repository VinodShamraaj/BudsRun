using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    ScoreManager scoreManager;


    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }


    public void Restart(){

        scoreManager.ResetScore();
        SceneManager.LoadScene("GameScene");
    }

    public void Home(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
