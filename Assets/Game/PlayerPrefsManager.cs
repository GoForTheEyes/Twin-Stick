using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour {


	const string MASTER_VOLUME_KEY = "master_volume";
	const string DIFFICULTY_KEY = "difficulty";
	const string LEVEL_KEY = "level_unlocked_";

	
	
	// Method to set current volume
	public static void SetMasterVolume (float volume) {
		if (volume >= 0f && volume <=1f) {
			PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
		} else {
			Debug.LogError ("Master volume out of range");
		}
	}
	
	//Function to return speed
	public static float GetAttackerSpeed(string key) {
		return PlayerPrefs.GetFloat(key);
	}
	
    // Function to return current volume
	public static float GetMasterVolume () {
		return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
	}
	
	//Method to unlock levels
	public static void UnlockLevel (int level) {
		if (level <= SceneManager.sceneCountInBuildSettings - 1) {
			PlayerPrefs.SetInt (LEVEL_KEY + level.ToString (), 1); // Use 1 for true 
		} else {
			//the total number of levels is less than the level requested; the level doesn't exist
			Debug.LogError ("Trying to unlock level not in build order");
		}
	}
	
	// Function to return if level is unlocked 
	public static bool IsLevelUnlocked(int level) {
		int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString ());
		bool isLevelUnlocked = (levelValue == 1);

        int levelCount = SceneManager.sceneCountInBuildSettings;
        if (level <= levelCount - 1) {
			return isLevelUnlocked;
		} else {
			//the total number of levels is less than the level requested; the level doesn't exist
			Debug.LogError ("Trying to query level not in build order");
			return false;
		}
	}
	
	// Method to set difficulty
	public static void SetDifficulty (float difficulty) {
		if (difficulty >= 1f && difficulty <=3f) {
			PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
		} else {
			Debug.LogError ("Difficulty out of range");
		}
	}
	
	// Function to return difficulty
	public static float GetDifficulty () {
		return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
	}
	
	
	
}
