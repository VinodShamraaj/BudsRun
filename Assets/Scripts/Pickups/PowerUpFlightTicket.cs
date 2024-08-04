using UnityEngine;

public class PowerUpFlightTicket : MonoBehaviour, IPowerUpDuration
{
    [SerializeField] private float duration = 5f;
    [SerializeField] private SoundManager soundManager;

    PlayerController playerController;

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
            playerController.SetCollision(true);
            playerController.ResetEffect();
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
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController = collision.GetComponent<PlayerController>();
            playerController.SetCollision(false);
            playerController.SetInvincibilityEffect();
            hasPickup = true;
        }
    }
}
