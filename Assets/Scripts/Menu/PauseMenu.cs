using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] GameObject pauseMenu;
    [SerializeField] SoundManager sound;

    [SerializeField] Image soundButtonImage;
    [SerializeField] Sprite soundOffSprite;
    [SerializeField] Sprite soundOnSprite;
    [SerializeField] Button soundButton, pauseButton, restartButton, settingButton;


    void Start()
    {
        soundButton.onClick.AddListener(SoundOn);
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (sound != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

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
        // restartButton.onClick.AddListener();
    }


    public void SoundOff()
    {
        Debug.Log("You have clicked Sound Off");
        sound.MuteMusic();
        soundButtonImage.sprite = soundOffSprite;

    }

    public void SoundOn()
    {
        Debug.Log("You have clicked Sound On!");
        sound.PlayGameplayMusic();
        soundButtonImage.sprite = soundOnSprite;

    }

}
