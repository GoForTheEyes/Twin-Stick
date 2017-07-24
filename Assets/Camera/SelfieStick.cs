using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfieStick : MonoBehaviour {

    public float panSpeed;
    private Vector3 armRotation;
    public float rotationX, rotationY, rotationZ;
    Transform player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = player.position;
        //armRotation = new Vector3 (45f, -45f,0f) ;
        armRotation = new Vector3(rotationX, rotationY, rotationZ);

    }
	
	// Update is called once per frame
	void Update () {
        UpdateRotation();
        transform.position = player.position;
    }

    private void UpdateRotation()
    {
        armRotation.y += Input.GetAxis("RHoriz") * panSpeed;
        armRotation.x += Input.GetAxis("RVert") * panSpeed;
        transform.rotation = Quaternion.Euler(armRotation);  
    }

}
