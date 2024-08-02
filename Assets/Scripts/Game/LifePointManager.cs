using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointManager : MonoBehaviour
{
    public int lifePoints = 3;
    public Text lifeText;

    void Start()
    {
        UpdateLifeText();
    }

    public void ReduceLifePoint()
    {
        lifePoints--;
        UpdateLifeText();
        if (lifePoints <= 0)
        {
            GameOver();
        }
    }

    void UpdateLifeText()
    {
        if (lifeText != null)
        {
            lifeText.text = "Life: " + lifePoints.ToString();
        }
    }

    void GameOver()
    {
        // Handle game over logic here
        Debug.Log("Game Over!");
    }
}
