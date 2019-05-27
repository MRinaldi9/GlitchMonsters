using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "Master Volume";
    const string DIFFICULTY_KEY = "Difficulty";
    const string LEVEL_KEY = "Level_unlocked_";

    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0 && volume <= 1)
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        else
            Debug.LogError("Volume is out of range");
    }
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        else
            Debug.LogError("Trying to unlock level not in build order");
    }

    public static bool IsLevelUnlocked(int level)
    {
        int value = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        if (value == 1 && level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return true;
        }
        else
        {
            if (value != 1 && level <= SceneManager.sceneCountInBuildSettings - 1)
                Debug.LogError("The level that you had choose isn't unlocked");
            else
                Debug.LogError("You are try to unlock a level that there isn't on the SceneIndex");
            return false;
        }
    }
    public static void SetDifficulty(int difficulty)
    {
        if (difficulty >= 1 && difficulty <= 3)
            PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
        else
            Debug.LogError("Difficulty set is out of range");
    }
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY);
    }
}
