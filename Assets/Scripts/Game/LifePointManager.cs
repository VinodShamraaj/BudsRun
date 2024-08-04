using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointManager : MonoBehaviour
{
    public int lifePoints = 3;
    public int maxLifePoints = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {

    }

    void Update()
    {

        foreach (Image img in hearts)
        {
            img.sprite = emptyHeart;
        }

        for(int i =0; i < lifePoints; i++) {

            hearts[i].sprite = fullHeart;

        }

    }

    public void ReduceLifePoint()
    {
        if (lifePoints > 0)
        {
            lifePoints--;
            Debug.Log("Life Point Reduced!");
            Update();

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
            Update();
        }

        else
        {
            Debug.Log("Maximum Health");
        }


    }



    void GameOver()
    {
        Debug.Log("Game Over!");

    }
}
