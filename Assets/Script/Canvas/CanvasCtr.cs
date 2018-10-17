using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCtr : MonoBehaviour {
    public static CanvasCtr instance;

    public NextBtnCtr NextBtnCtr;
	// Use this for initialization
	void Start () {
        if (instance == null)
        {
            instance = this;
        }
	}



    // Update is called once per frame
    void Update () {
		
	}

    public  void ShowAll(int num) {      
        NextBtnCtr.ShowAll(num);
    }

    public void HideAll() {
        NextBtnCtr.HideAll();
    }

}
