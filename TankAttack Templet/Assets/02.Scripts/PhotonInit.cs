﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotonInit : MonoBehaviour
{
    public string version = "v1.0";
    public InputField userID;
    public InputField roomName;

	void Awake ()
    {
        PhotonNetwork.ConnectUsingSettings(version);
        roomName.text = "ROOM_" + Random.Range(0, 999).ToString("000");
	}

    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby!");
        userID.text = GetSuerID();
        //PhotonNetwork.JoinRandomRoom();
    }

    string GetSuerID()
    {
        string userId = PlayerPrefs.GetString("USER_ID");
        if( string.IsNullOrEmpty(userId) )
        {
            userId = "USER_" + Random.Range(0, 999).ToString("000");
        }

        return userId;
    }

    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("No Room!");
        
        RoomOptions option = new RoomOptions();
        option.isVisible = true;
        option.isOpen = true;
        option.maxPlayers = 20;
        TypedLobby typedLobby = new TypedLobby();

        PhotonNetwork.CreateRoom("MyRoom", option, typedLobby);
    }

    void OnJoinedRoom()
    {
        Debug.Log("Enter Room");
        //CreateTank();
        StartCoroutine(this.LoadBattleField());
    }

    IEnumerator LoadBattleField()
    {
        PhotonNetwork.isMessageQueueRunning = false;
        AsyncOperation ao = Application.LoadLevelAsync("scBattleField");
        yield return ao;
    }

    public void OnClickJoinRandomRoom()
    {
        Debug.Log("aaaaaaaaaaaaaaaaaaaaaa");
        PhotonNetwork.player.name = userID.text;
        PlayerPrefs.SetString("USER_ID", userID.text);
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnClickCreateRoom()
    {
        string _roomName = roomName.text;
        if( string.IsNullOrEmpty(roomName.text) )
        {
            _roomName = "ROOM_" + Random.Range(0, 999).ToString("000");
        }

        PhotonNetwork.player.name = userID.text;
        PlayerPrefs.SetString("USER_ID", userID.text);

        RoomOptions roomOption = new RoomOptions();
        roomOption.isOpen = true;
        roomOption.isVisible = true;
        roomOption.maxPlayers = 20;

        PhotonNetwork.CreateRoom(_roomName, roomOption, TypedLobby.Default);
    }

    void OnPhotonCreateRoomFailed(object[] codeAndMsg )
    {
        Debug.Log("Create Room Failed = " + codeAndMsg[1]);
    }

    /*void CreateTank()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
        Debug.Log("CreateTank");
    }*/

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
