using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int coinScore = 50;
    [SerializeField] private ScoreManager scoreManger;
    [SerializeField] private SoundManager soundManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.PlayCoinSound();
            scoreManger.AddScore(coinScore);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
