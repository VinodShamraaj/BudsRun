using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Transform player;
    public Text distanceText;
    private Vector3 startPosition;

    void Start()
    {
        if (player != null)
        {
            startPosition = player.position;
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
}
