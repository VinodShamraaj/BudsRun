using UnityEngine;

public class PowerUpMoneyGun : MonoBehaviour
{
    [SerializeField] float duration = 5f;
    [SerializeField] float distanceMagnet = 5f;
    [SerializeField] float coinSpeed = 0.2f;

    private bool hasPickup = false;

    private void Update()
    {
        if (hasPickup && duration < 0)
        {
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
            hasPickup = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
