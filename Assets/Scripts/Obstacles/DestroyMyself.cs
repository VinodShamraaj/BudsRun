
using UnityEngine;

public class DestroyMyself : MonoBehaviour
{
    void Update()
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.x < -3)
        {
            Destroy(gameObject);
        }

    }
}
