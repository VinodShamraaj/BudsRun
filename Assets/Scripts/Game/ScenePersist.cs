using UnityEngine;

public class ScenePersist : MonoBehaviour
{
    /// <summary>
    /// Persist enemies, pickup, coins, etc... for the current level 
    /// if player still have lives
    /// </summary>
    private void Awake()
    {
        int numScenePersists = FindObjectsOfType<ScenePersist>().Length;

        if (numScenePersists > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
