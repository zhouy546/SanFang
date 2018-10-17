using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Transform CameraTrans;
    public Collider mCollider;
    public VideoCtr videoCtr;
    //public string UDPMessage;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOffCollider() {
        mCollider.enabled = false;
    }

    public void TurnOnCollider() {
        mCollider.enabled = true;
    }
}
