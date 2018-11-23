using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Transform CameraTrans;
    public Collider mCollider;
    public VideoCtr videoCtr;

    public Animator animator;
    //public string UDPMessage;

	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Show() {
        animator.SetBool("Show", true);
    }

    public void Hide() {
        animator.SetBool("Show", false);

    }

    public void TurnOffCollider() {
        mCollider.enabled = false;
    }

    public void TurnOnCollider() {
        mCollider.enabled = true;
    }
}
