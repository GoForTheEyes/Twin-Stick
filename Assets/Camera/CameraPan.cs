using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPan : MonoBehaviour {

    Transform player;

    public Vector3 initialPos, initialRot;

	// Use this for initialization
	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(player);
    }



    // Update is called once per frame - after Update
    void LateUpdate ()
    {
        //update position
        transform.LookAt(player);
    }

    



}
