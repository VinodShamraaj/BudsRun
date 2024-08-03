using UnityEngine;

public class PowerUpFlightTicket : MonoBehaviour
{
    [SerializeField] private float duration = 5f;
    PlayerController playerController;

    private bool hasPickup = false;

    private void Update()
    {
        if (hasPickup && duration < 0)
        {
            hasPickup = true;
            playerController.ToggleCollision();
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
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            playerController = collision.GetComponent<PlayerController>();
            playerController.ToggleCollision();
            hasPickup = true;
        }
    }
}
