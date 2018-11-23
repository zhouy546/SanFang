using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraRayCast : MonoBehaviour {
    public Camera mCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)) {

            Ray mRay = mCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(mRay, out hit))
            {
                if (hit.collider.gameObject.tag == "Node") {
                    Node node = hit.collider.GetComponent<Node>();

                    CameraMover cameraMover = CameraMover.instance;

                    Debug.Log("Hit");

                    foreach (var item in NodeCtr.instance.nodes)
                    {
                        item.TurnOffCollider();
                    }

                    int num = NodeCtr.instance.nodes.IndexOf(node);

                   // CanvasCtr.instance.ShowAll(num);

                    cameraMover.MoveCameraToPos(node);

                    

                }
            }
        }
	}
}
