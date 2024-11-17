using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisionLevelTransition : MonoBehaviour
{
    public string playerOneTag = "Plus";
    public string playerTwoTag = "Minus";
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag(playerOneTag) && gameObject.CompareTag(playerTwoTag)) ||
            (collision.gameObject.CompareTag(playerTwoTag) && gameObject.CompareTag(playerOneTag)))
        {
            Debug.Log("Players collided! Loading next level...");
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // Unlock the next level
            int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
            if (nextSceneIndex > unlockedLevel)
            {
                PlayerPrefs.SetInt("UnlockedLevel", nextSceneIndex);
                PlayerPrefs.Save();
            }

            // Load the next level
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels to load! Game finished.");
        }
    }
}