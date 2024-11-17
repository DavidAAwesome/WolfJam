using UnityEngine;
using UnityEngine.UI;

public class ClearSaveData : MonoBehaviour
{
    // Method to clear the save data
    public void ClearSave()
    {
        // Deletes the "UnlockedLevel" key
        if (PlayerPrefs.HasKey("UnlockedLevel"))
        {
            PlayerPrefs.DeleteKey("UnlockedLevel");
            PlayerPrefs.Save();
            Debug.Log("Save data cleared. UnlockedLevel key deleted.");
        }
        else
        {
            Debug.Log("No save data found to clear.");
        }
    }
}
