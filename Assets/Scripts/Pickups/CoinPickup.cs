using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int coinScore = 50;
    [SerializeField] private SoundManager soundManager;

    private ScoreManager scoreManager;

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.PlayCoinSound();
            scoreManager.AddScore(coinScore);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
