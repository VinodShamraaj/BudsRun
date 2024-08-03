using UnityEngine;

public class PowerUpMoneyGun : MonoBehaviour, IPowerUpDuration
{
    [SerializeField] float duration = 5f;
    [SerializeField] float distanceMagnet = 5f;
    [SerializeField] float coinSpeed = 0.2f;
    [SerializeField] private SoundManager soundManager;

    private bool hasPickup = false;

    public bool GetHasPickup()
    {
        return hasPickup;
    }

    private void Update()
    {
        if (hasPickup && duration < 0)
        {
            soundManager.PlayGameplayMusic();
            hasPickup = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (hasPickup)
        {
            // Create coin magnet 

            CoinPickup[] coinPickupList = FindObjectsOfType<CoinPickup>();

            foreach (CoinPickup coin in coinPickupList)
            {
                float distance = Vector2.Distance(gameObject.transform.position, coin.transform.position);

                if (distance < distanceMagnet)
                {
                    coin.transform.position = Vector2.MoveTowards(coin.transform.position, gameObject.transform.position, coinSpeed);
                }
            }
            duration = duration - Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.PlayPowerUpMusic();
            hasPickup = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
