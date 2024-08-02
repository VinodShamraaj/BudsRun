using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private static AudioSource audioSource;

    [Header("Music")]
    [SerializeField] private AudioClip mainMenuMusic;
    [SerializeField][Range(0f, 1f)] private float mainMenuMusicVolume = 1f;
    [SerializeField] private AudioClip gameplayMusic;
    [SerializeField][Range(0f, 1f)] private float gameplayMusicVolume = 1f;
    [SerializeField] private AudioClip powerUpMusic;
    [SerializeField][Range(0f, 1f)] private float powerUpMusicVolume = 1f;
    [SerializeField] private AudioClip bossMusic;
    [SerializeField][Range(0f, 1f)] private float bossMusicVolume = 1f;
    [SerializeField] private AudioClip endingMusic;
    [SerializeField][Range(0f, 1f)] private float endingMusicVolume = 1f;

    [Header("SFX")]
    [SerializeField] private AudioClip jumpSound;
    [SerializeField][Range(0f, 1f)] private float jumpSoundVolume = 1f;
    [SerializeField] private AudioClip coinSound;
    [SerializeField][Range(0f, 1f)] private float coinSoundVolume = 1f;
    [SerializeField] private AudioClip hitSound;
    [SerializeField][Range(0f, 1f)] private float hitSoundVolume = 1f;

    [Header("Menu")]
    [SerializeField] private AudioClip menuClick;
    [SerializeField][Range(0f, 1f)] private float menuClickVolume = 1f;


    private void Awake()
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMainMenuMusic()
    {
        PlayBackgroundMusic(mainMenuMusic, mainMenuMusicVolume);
    }

    public void PlayGameplayMusic()
    {
        PlayBackgroundMusic(gameplayMusic, gameplayMusicVolume);
    }

    public void PlayPowerUpMusic()
    {
        PlayBackgroundMusic(powerUpMusic, powerUpMusicVolume);
    }

    public void PlayBossMusic()
    {
        PlayBackgroundMusic(bossMusic, bossMusicVolume);
    }

    public void PlayEndingMusic()
    {
        PlayClip(endingMusic, endingMusicVolume);
    }

    public void PlayJumpSound()
    {
        PlayClip(jumpSound, jumpSoundVolume);
    }

    public void PlayCoinSound()
    {
        PlayClip(coinSound, coinSoundVolume);
    }

    public void PlayHitSound()
    {
        PlayClip(hitSound, hitSoundVolume);
    }

    public void PlayMenuClick()
    {
        PlayClip(menuClick, menuClickVolume);
    }

    private static void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }

    private static void PlayBackgroundMusic(AudioClip clip, float volume)
    {
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.volume = volume;
        audioSource.Play();
    }
}
