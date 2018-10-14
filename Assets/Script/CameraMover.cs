using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public Transform CameraDefaultTrans;
    public List<Node> nodes = new List<Node>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Q)) {
            MoveCameraToPos(nodes[0].CameraTrans);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            MoveCameraToPos(nodes[1].CameraTrans);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            MoveCameraToPos(nodes[2].CameraTrans);
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            MoveCameraToPos(CameraDefaultTrans);
        }
	}

    public void MoveCameraToPos(Transform transform) {
        this.transform.SetParent(transform);

        LeanTween.rotateLocal(this.gameObject, Vector3.zero, 1f);
        LeanTween.moveLocal(this.gameObject, Vector3.zero, 1f);
    }
}
