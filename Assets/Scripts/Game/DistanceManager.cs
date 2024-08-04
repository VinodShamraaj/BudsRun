using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;
    public Text distanceText;
    private Vector3 startPosition;
    private static Distance instance;

    void Start()
    {
        if (player != null)
        {
            startPosition = player.position;
        }

        Update();
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(startPosition, player.position);
            UpdateDistanceText(distance);
        }
    }

    void UpdateDistanceText(float distance)
    {
        if (distanceText != null)
        {
            distanceText.text = distance.ToString("F2") + " meters";
        }
    }

    public void Reset()
    {
        startPosition = player.position;
        Update();
    }
}
