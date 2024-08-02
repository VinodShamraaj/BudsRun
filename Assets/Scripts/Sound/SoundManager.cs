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

    private void Awake()
    {
        ManageSingleton();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayMainMenuMusic();
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
        PlayClip(mainMenuMusic, mainMenuMusicVolume);
    }

    public void PlayGameplayMusic()
    {
        PlayClip(gameplayMusic, gameplayMusicVolume);
    }

    public void PlayPowerUpMusic()
    {
        PlayClip(powerUpMusic, powerUpMusicVolume);
    }

    public void PlayBossMusic()
    {
        PlayClip(bossMusic, bossMusicVolume);
    }

    public void PlayEndingMusic()
    {
        PlayClip(endingMusic, endingMusicVolume);
    }

    private static void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
    }
}
