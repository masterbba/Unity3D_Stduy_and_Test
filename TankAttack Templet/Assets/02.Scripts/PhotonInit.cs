using UnityEngine;
using System.Collections;

public class PhotonInit : MonoBehaviour
{
    public string version = "v1.0";
	void Awake ()
    {
        PhotonNetwork.ConnectUsingSettings(version);
	}

    void OnJoinedLobby()
    {
        Debug.Log("Entered Lobby!");
        PhotonNetwork.JoinRandomRoom();
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
        CreateTank();
    }

    void CreateTank()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
        Debug.Log("CreateTank");
    }

    void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
