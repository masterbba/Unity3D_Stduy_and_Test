﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoomData : MonoBehaviour
{
    [HideInInspector]
    public string roomName = "";
    [HideInInspector]
    public int connectPlayer = 0;
    [HideInInspector]
    public int maxPlayer = 0;

    public Text textRoomName;
    public Text textConnectInfo;
    
    public void DispRoomData()
    {
        textRoomName.text = roomName;
        textConnectInfo.text = "(" + connectPlayer.ToString() + "/" + maxPlayer.ToString() + ")";
    }
}
