
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    private IPowerUpDuration powerUp;

    private void Awake()
    {
        powerUp = GetComponent<IPowerUpDuration>();
    }

    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < -3)
        {
            if (powerUp != null && powerUp.GetHasPickup())
            {
                return;
            }

            Destroy(gameObject);
        }

    }
}
