using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBtnCtr : MonoBehaviour {
    public List<Btn> btns = new List<Btn>();
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowAll(int num) {
        if (num == 0)
        {
            btns[0].Hide();
            btns[1].Show();
        }
        else if (num == CameraMover.instance.nodes.Count - 1)
        {
            btns[0].Show();
            btns[1].Hide();
        }
        else {
            foreach (Btn btn in btns)
            {
                btn.Show();
            }
        }


    }

    public void HideAll() {
        foreach (Btn btn in btns)
        {
            btn.Hide();
        }
    }

}
