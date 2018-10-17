using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn : MonoBehaviour {
    public Animator animator;
    public NextBtnCtr nextBtnCtr;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void Show() {
        animator.SetBool("Show", true);
    }

    public void Hide() {
        animator.SetBool("Show", false);
    }

    public void MoveLeft() {
        CameraMover cameraMover = CameraMover.instance;
        cameraMover.CurrentNodeNum--;

       // Debug.Log("current num is : " + cameraMover.CurrentNodeNum.ToString());
      cameraMover.MoveCameraToPos(cameraMover.nodes[cameraMover.CurrentNodeNum]);

        UpdateBtn(cameraMover.CurrentNodeNum);

    }

    public void MoveRight() {
        CameraMover cameraMover = CameraMover.instance;
        cameraMover.CurrentNodeNum++;
        cameraMover.MoveCameraToPos(cameraMover.nodes[cameraMover.CurrentNodeNum]);
        UpdateBtn(cameraMover.CurrentNodeNum);

    }


    public void UpdateBtn(int num) {
        nextBtnCtr.ShowAll(num);

    }
}
