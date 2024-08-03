using UnityEngine;

public class CoinPickup : MonoBehaviour
{
    [SerializeField] private int coinScore = 50;
    [SerializeField] private ScoreManager scoreManger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            scoreManger.AddScore(coinScore);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
