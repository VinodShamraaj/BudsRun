using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointManager : MonoBehaviour
{
    public int lifePoints = 3; // Current life points
    public int maxLifePoints = 3; // Maximum life points
    public bool takeDamage = false;
    public bool takeHeart = false;
    public Image[] hearts; // Array of heart UI images
    public Sprite fullHeart; // Sprite for a full heart
    public Sprite emptyHeart; // Sprite for an empty heart
    public Transform player;

    void Start()
    {
        UpdateHearts();

    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lifePoints)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            hearts[i].enabled = (i < maxLifePoints);
        }
    }

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {

    }



    void Update()
    {

        if (takeDamage) 
        {
            ReduceLifePoint();
        }
        if (takeHeart) 
        {
            IncreaseLifePoint();
        }
    }

    public void ReduceLifePoint()
    {
        if (lifePoints > 0)
        {
            lifePoints--;
            Debug.Log("Life Point Reduced!");
            UpdateHearts();

            if (lifePoints < 1)
            {
                GameOver();
            }
        }
    }

    public void IncreaseLifePoint()
    {
        if (lifePoints < maxLifePoints)
        {
            lifePoints++;
            Debug.Log("Life Point Increased!");
            UpdateHearts();
        }

        else
        {
            Debug.Log("Maximum Health");
        }
    }

   

    void GameOver()
    {
        // Logic for game over
        Debug.Log("Game Over!");

        // frame to final score
    }
}
