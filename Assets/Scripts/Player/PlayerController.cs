using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool isCollision = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Obstacle" && isCollision)
        {
            // Handle Collission stuff here
            Destroy(col.gameObject);
        }
    }

    public void ToggleCollision()
    {
        isCollision = !isCollision;
    }
}
