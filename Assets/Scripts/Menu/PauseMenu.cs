using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] SoundManager sound;

    // Update is called once per frame
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Setting()
    {
       // return to setting menu
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void Restart()
    {
        //restart game
    }

    void SoundOff()
    {
        sound.MuteMusic();
    }

    void SoundOn()
    {
        sound.PlayGameplayMusic();
    }

}
