using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour {
    public static CameraMover instance;
    public Transform CameraDefaultTrans;


    LTDescr move;
    LTDescr rot;

    private float resetTime;

    public int screenPosNum=0;

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
        resetTime = ValueSheet.ResetTime;

        if (instance == null) {
            instance = this;
        }

        StartCoroutine(CountDown());
	}


    IEnumerator CountDown() {

        resetTime--;

        yield return new WaitForSeconds(1f);

        if (resetTime == 0) {
            MoveCameraToPos(CameraDefaultTrans);
            CanvasCtr.instance.HideAll();
            // CanvasCtr.instance.HideAll();
            foreach (var item in NodeCtr.instance.nodes)
            {
                item.TurnOnCollider();
                item.videoCtr.StopVideo();

                item.Show();
            }
            resetTime = ValueSheet.ResetTime;

            Debug.Log("返回");

        }


        StartCoroutine(CountDown());
    }


    // Update is called once per frame
    void Update () {

        if (Input.GetKeyDown(KeyCode.Escape)) {
            MoveCameraToPos(CameraDefaultTrans);
           // CanvasCtr.instance.HideAll();
            foreach (var item in NodeCtr.instance.nodes)
            {
                item.TurnOnCollider();
                item.videoCtr.StopVideo();

                item.Show();
            }
            Debug.Log("返回");



        }

	}

    public void MoveCameraToPos(Node node) {
        resetTime = ValueSheet.ResetTime;
        if (rot != null && move != null) {
            LeanTween.cancel(rot.id);
            LeanTween.cancel(move.id);
        }
        currentNodeNum = NodeCtr.instance.nodes.IndexOf(node);

        this.transform.SetParent(node.CameraTrans);
        rot =  LeanTween.rotateLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f);
        move =    LeanTween.moveLocal(this.gameObject, Vector3.zero, 1f).setDelay(0.25f).setOnComplete(()=>isMoving=false);


        Debug.Log(NodeCtr.instance.nodes.IndexOf(node)+"udp");
       StartCoroutine( MoveScreen(NodeCtr.instance.nodes.IndexOf(node)));
    }

    public void MoveCameraToPos(Transform CameraTrans)
    {
        resetTime = ValueSheet.ResetTime;
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


    public IEnumerator MoveScreen(int targetPos) {

        screenPosNum = targetPos;
        //  int leftRight = screenPosNum - targetPos;

        //    Debug.Log("Hide UI");

        NodeCtr.instance.StopAll();
       CanvasCtr.instance.HideAll();

        foreach (var item in NodeCtr.instance.nodes)
        {
            item.Show();
        }

        int num = targetPos + 1;

        SendUPDData.instance.udp_Send(num.ToString(),29020);

        

        yield return new WaitForSeconds(0f);


    }
}
