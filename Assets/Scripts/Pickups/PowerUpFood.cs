using UnityEngine;

public class PowerUpFood : MonoBehaviour
{
    private LifePointManager lifePointManager;

    private void Awake()
    {
        lifePointManager = FindObjectOfType<LifePointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            lifePointManager.IncreaseLifePoint();
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
