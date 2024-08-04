using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePointManager : MonoBehaviour
{

    private static LifePointManager instance;
    public int lifePoints = 3;
    public int maxLifePoints = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public ScoreManager score;

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
            Update();
        }

        else
        {
            score.AddScore(50);
        }


    }

    void GameOver()
    {
       

    }
}
