using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeCtr : MonoBehaviour {
    public static NodeCtr instance;
    public List<Node> nodes = new List<Node>();
    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
        }
	}

    public void TheNodeVideo(int num,string path) {
        for (int i = 0; i < nodes.Count; i++)
        {
            if (i != num)
            {
                nodes[i].videoCtr.StopVideo();

            }
            else {
                nodes[i].videoCtr.PlayVideo(path);
            }
        }
    }

    public void StopAll() {
        foreach (var item in nodes)
        {
            item.videoCtr.StopVideo();
        }
    }
}
