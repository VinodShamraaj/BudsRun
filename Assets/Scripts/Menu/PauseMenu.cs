using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    SoundManager sound;

    // Update is called once per frame
    public void Pause()
    {
        pauseMenu.SetActive(true);
    }

    public void Setting()
    {
       // return to setting menu
    }

    void Resume()
    {
        pauseMenu.SetActive(false);
    }

    void SoundOff()
    {
       //sound off 
    }

    void SoundOn()
    {
        sound.PlayGameplayMusic();
    }

}
