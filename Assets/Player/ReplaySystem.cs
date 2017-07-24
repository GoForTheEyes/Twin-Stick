using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem: MonoBehaviour {

    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody myRigidbody;
    private GameManager gameManager;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (gameManager.started)
        {
            if (gameManager.recording)
            {
                Record();
            }
            else
            {
                PlayBack(gameManager.startPlayback);
            }
        }

    }

    void PlayBack (int startFrame)
    {
        myRigidbody.isKinematic = true;
        int frame = (Time.frameCount - startFrame) % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;

    }

    private void Record()
    {
        myRigidbody.isKinematic = false;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;
        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing time, rotation and position.
/// </summary>
public struct MyKeyFrame
{
    public float time; 
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float newTime, Vector3 newPosition, Quaternion newRotation)
    {
        time = newTime;
        position = newPosition;
        rotation = newRotation;
    }
}