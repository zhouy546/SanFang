using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public static CameraMover instance;
    public Transform CameraDefaultTrans;


    LTDescr move;
    LTDescr rot;

    private int currentNodeNum;
    public int CurrentNodeNum {
        get { return currentNodeNum; }
        set {
            if (currentNodeNum <= NodeCtr.instance.nodes.Count - 1&&currentNodeNum>=0)
            {
                if (value == -1)
                {
                    return;
                }
                else if(value == NodeCtr.instance.nodes.Count) { return; }
                currentNodeNum = value;
               // Debug.Log(currentNodeNum);

            }

        }
    }

    bool isMoving =false;
    // Use this for initialization
	void Start () {
        if (instance == null) {
            instance = this;
        }
	}



    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            MoveCameraToPos(CameraDefaultTrans);
            CanvasCtr.instance.HideAll();
            foreach (var item in NodeCtr.instance.nodes)
            {
                item.TurnOnCollider();
                item.videoCtr.StopVideo();
            }
            Debug.Log("返回");



        }

	}

    public void MoveCameraToPos(Node node) {
        if (rot != null && move != null) {
            LeanTween.cancel(rot.id);
            LeanTween.cancel(move.id);
        }
        currentNodeNum = NodeCtr.instance.nodes.IndexOf(node);

        this.transform.SetParent(node.CameraTrans);
        rot =  LeanTween.rotateLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f);
        move =    LeanTween.moveLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f).setOnComplete(()=>isMoving=false);


        Debug.Log(NodeCtr.instance.nodes.IndexOf(node)+"udp");
        int num = NodeCtr.instance.nodes.IndexOf(node);
        string path = ValueSheet.VideoLoaction[num];

        NodeCtr.instance.TheNodeVideo(num, path);

       // }
    }

    public void MoveCameraToPos(Transform CameraTrans)
    {
        if (rot != null && move != null)
        {
            LeanTween.cancel(rot.id);
            LeanTween.cancel(move.id);
        }

        this.transform.SetParent(CameraTrans);
        rot = LeanTween.rotateLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f);
        move = LeanTween.moveLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f).setOnComplete(() => isMoving = false);
        // }
    }
}
