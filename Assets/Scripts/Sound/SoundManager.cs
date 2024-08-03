using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    private static AudioSource audioSource;

    [Header("Master Volume")]
    [SerializeField] private float masterVolume = 1f;

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
    [SerializeField] private AudioClip powerUpSound;
    [SerializeField][Range(0f, 1f)] private float powerUpSoundVolume = 1f;
    [SerializeField] private AudioClip[] hurtSound = new AudioClip[0];
    [SerializeField][Range(0f, 1f)] private float hurtSoundVolume = 1f;
    [SerializeField] private AudioClip dieSound;
    [SerializeField][Range(0f, 1f)] private float dieSoundVolume = 1f;

    [Header("Menu")]
    [SerializeField] private AudioClip menuClick;
    [SerializeField][Range(0f, 1f)] private float menuClickVolume = 1f;

    private float currentTime = 0f;
    private AudioClip currentMusic;

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
    public void PlayPowerUpSound()
    {
        PlayClip(powerUpSound, powerUpSoundVolume);
    }
    public void PlayHurtSound()
    {
        AudioClip randomSound = hurtSound[Random.Range(0, hurtSound.Length)];

        PlayClip(randomSound, hurtSoundVolume);
    }

    public void PlayDieSound()
    {
        PlayClip(dieSound, dieSoundVolume);
    }

    public void PlayMenuClick()
    {
        PlayClip(menuClick, menuClickVolume);
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public void SetMasterVolume(float volume)
    {
        masterVolume = volume;
        AudioListener.volume = volume;
    }

    public void PauseMusic()
    {
        audioSource.Pause();
    }

    public void ResumeMusic()
    {
        audioSource.UnPause();
    }

    public void MuteMusic()
    {
        audioSource.mute = true;
    }

    public void UnMuteMusic()
    {
        audioSource.mute = false;
    }


    private void PlayClip(AudioClip clip, float volume)
    {
        Vector3 cameraPos = Camera.main.transform.position;
        AudioSource.PlayClipAtPoint(clip, cameraPos, volume * masterVolume);
    }

    private void PlayBackgroundMusic(AudioClip clip, float volume)
    {
        audioSource.loop = true;
        audioSource.clip = clip;
        audioSource.volume = volume * masterVolume;
        audioSource.Play();
    }
}
