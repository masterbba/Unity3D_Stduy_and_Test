using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PhotonInit : MonoBehaviour
{
    public string version = "v1.0";
    public InputField userID;

	void Awake ()
    {
        PhotonNetwork.ConnectUsingSettings(version);
	}

    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby!");
        userID.text = GetSuerID();
        PhotonNetwork.JoinRandomRoom();
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
    }

    public void OnClickJoinRandomRoom()
    {
        PhotonNetwork.player.name = userID.text;
        PlayerPrefs.SetString("USER_ID", userID.text);
        PhotonNetwork.JoinRandomRoom();
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
