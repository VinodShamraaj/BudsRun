using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private SoundManager gameSound = null;

    // Start is called before the first frame update
    void Start()
    {
        if(gameSound != null) {
            gameSound.PlayMainMenuMusic();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetVolume(float volume) {
        // Not sure how audio works here
        AudioListener.volume = volume;
        volumeTextValue.text = volume.ToString("0.0");
        gameSound.SetMasterVolume(volume);
    }
}
