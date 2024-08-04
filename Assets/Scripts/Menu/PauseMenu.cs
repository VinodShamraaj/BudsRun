using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    //[SerializeField] GameObject pauseMenu;
    //[SerializeField] GameObject pauseButton;
    [SerializeField] SoundManager sound;

    [SerializeField] Button soundButton, restartButton, settingButton;

    [SerializeField] Sprite soundOffSprite;
    [SerializeField] Sprite soundOnSprite;

    [Header("Volume Setting")]
    [SerializeField] private Text volumeTextValue = null;
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private SoundManager gameSound = null;
    ScoreManager scoreManager;


    public bool isSoundOn = true;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    void Update()
    {
        SetVolume(gameSound.GetMasterVolume());
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

    public void Pause()
    {
        //pauseMenu.SetActive(true);
        //pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        //pauseMenu.SetActive(false);
        //pauseButton.SetActive(true);
        Time.timeScale = 1;

    }

    public void Replay()
    {
        scoreManager.ResetScore();
        SceneManager.LoadScene("GameScene");
    }

    public void Setting()
    {
        // return to setting menu
    }


    public void SoundButtonClicked() {

        if (isSoundOn)
            SoundOff();
        
        else    
            SoundOn();     
    }

    public void SoundOff() {
        isSoundOn = false;
        sound.MuteMusic();
        soundButton.image.sprite = soundOffSprite;
       

    }

    public void SoundOn()
    {
        isSoundOn = true;
        sound.UnMuteMusic();
        soundButton.image.sprite = soundOnSprite;
    }

    public void SetVolume(float volume)
    {
        // Not sure how audio works here
        volumeTextValue.text = (volume * 100).ToString("0");
        volumeSlider.value = volume;
        gameSound.SetMasterVolume(volume);
    }
}
