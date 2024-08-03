using UnityEngine;

public class PowerUpMoneyBag : MonoBehaviour, IPowerUpDuration
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private float pickupSpawnTime = 2f;
    [SerializeField] private SoundManager soundManager;

    private bool hasPickup = false;
    private PickupSpawner pickupSpawner;

    private void Awake()
    {
        pickupSpawner = FindObjectOfType<PickupSpawner>();
    }

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
            pickupSpawner.SetPickupSpawnTime(pickupSpawner.GetOriginalPickupSpawnTime());
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else if (hasPickup)
        {
            duration = duration - Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            soundManager.PlayPowerUpMusic();
            pickupSpawner.SetPickupSpawnTime(pickupSpawnTime);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            hasPickup = true;
        }
    }
}
