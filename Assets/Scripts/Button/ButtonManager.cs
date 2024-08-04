using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public void Restart(){
        SceneManager.LoadScene("GameScene");
    }

    public void Home(){
        SceneManager.LoadScene("MainMenuScene");
    }
}
