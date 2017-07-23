using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    
    public int startPlayback = 0;
    public bool recording = true;
    public bool started = false;

    // Use this for initialization
    void Start () {
        PlayerPrefsManager.UnlockLevel(2);
        print("Level1: " + PlayerPrefsManager.IsLevelUnlocked(1));
        print("Level2: " + PlayerPrefsManager.IsLevelUnlocked(2));
    }

	// Update is called once per frame
	void Update () {
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
    }
}
