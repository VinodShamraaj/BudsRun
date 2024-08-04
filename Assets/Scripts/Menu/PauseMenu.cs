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
 

    public bool isSoundOn = true;


    void Start()
    {
       
    }

    void Update()
    {
      
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
        SceneManager.LoadScene(1);
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


}
