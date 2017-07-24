using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    
    public int startPlayback = 0;
    public bool recording = true;
    public bool started = false;

    private bool isPaused = false;
    private bool wasPaused = false;
    private float fixedDeltaTime;

    // Use this for initialization
    void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        print("Level1: " + PlayerPrefsManager.IsLevelUnlocked(1));
        print("Level2: " + PlayerPrefsManager.IsLevelUnlocked(2));

        fixedDeltaTime = Time.fixedDeltaTime;
    }

	// Update is called once per frame
	void Update ()
    {
        if (!started && CrossPlatformInputManager.GetAxis("Horizontal") != 0)
        {
            started = true;
        }

        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            startPlayback = Time.frameCount;
        }

        if (!CrossPlatformInputManager.GetButton("Fire1"))
        {
            recording = true;
        }
        else
        {
            recording = false;
        }
        //Pause or Unpause
        UpdatePause();

        if (Input.GetKeyDown(KeyCode.P)) {
            isPaused = !isPaused;
        }
    }

    private void UpdatePause()
    {
        if (isPaused != wasPaused)
        {
            if (isPaused == true)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        //update wasPause Status
        wasPaused = isPaused;
    }

    void PauseGame()
    {
        Time.timeScale = 0;
        Time.fixedDeltaTime = 0;

    }

    void ResumeGame()
    {
        Time.timeScale = 1;
        Time.fixedDeltaTime = fixedDeltaTime;
    }

    //for iOS and Android pause
    private void OnApplicationPause(bool pauseStatus)
    {
        isPaused = pauseStatus;
    }

}
