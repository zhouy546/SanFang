//*********************❤*********************
// 
// 文件名（File Name）：	DealWithUDPMessage.cs
// 
// 作者（Author）：			LoveNeon
// 
// 创建时间（CreateTime）：	Don't Care
// 
// 说明（Description）：	接受到消息之后会传给我，然后我进行处理
// 
//*********************❤*********************

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealWithUDPMessage : MonoBehaviour {

    //public FocusByUDP focusByUDPClass;//根据UDP数据处理相机移动的类
    private string dataTest;


    /// <summary>
    /// 消息处理
    /// </summary>
    /// <param name="_data"></param>
    public void MessageManage(string _data)
    {

        dataTest = _data;
        Debug.Log(dataTest);

        if (dataTest== (CameraMover.instance.screenPosNum+1).ToString())
        {


            Debug.Log("ShowUI");


            CanvasCtr.instance.ShowAll(CameraMover.instance.screenPosNum);

            foreach (var item in NodeCtr.instance.nodes)
            {
                item.Hide();
            }


            string path = ValueSheet.VideoLoaction[CameraMover.instance.screenPosNum];

            NodeCtr.instance.TheNodeVideo(CameraMover.instance.screenPosNum, path);
        }
    }
}
