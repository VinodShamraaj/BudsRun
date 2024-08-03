using UnityEngine;

public class PowerUpFood : MonoBehaviour
{
    [SerializeField] LifePointManager lifePointManager;

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
