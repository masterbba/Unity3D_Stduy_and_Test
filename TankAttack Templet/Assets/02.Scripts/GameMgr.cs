using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMgr : MonoBehaviour
{
    public Text txtConnect;
    public Text txtLogMsg;
    private PhotonView pv;

	void Awake ()
    {
        pv = GetComponent<PhotonView>();
        CreateTank();
        PhotonNetwork.isMessageQueueRunning = true;
        GetConnectPlayerCount();
    }

    void Start()
    {
        string msg = "\n<color=#00ff00>[" + PhotonNetwork.player.name + "] Connected</color>";
        pv.RPC("LogMsg", PhotonTargets.AllBuffered, msg);
    }

	void CreateTank ()
    {
        float pos = Random.Range(-100.0f, 100.0f);
        PhotonNetwork.Instantiate("Tank", new Vector3(pos, 20.0f, pos), Quaternion.identity, 0);
	}

    void GetConnectPlayerCount()
    {
        Room currRoom = PhotonNetwork.room;
        txtConnect.text = currRoom.playerCount.ToString() + "/" + currRoom.maxPlayers.ToString();
    }

    void OnPhotonPlayerConnected(PhotonPlayer newPlayer)
    {
        GetConnectPlayerCount();
    }

    void OnPhotonPlayerDisconnected(PhotonPlayer outPlayer)
    {
        GetConnectPlayerCount();
    }

    [PunRPC]
    void LogMsg(string msg)
    {
        txtLogMsg.text = txtLogMsg.text + msg;
    }

    public void OnClickExitRoom()
    {
        string msg = "\n<color=#00ff00>[" + PhotonNetwork.player.name + "] Disconnected</color>";
        pv.RPC("LogMsg", PhotonTargets.AllBuffered, msg);

        PhotonNetwork.LeaveRoom();
    }

    void OnLeftRoom()
    {
        Application.LoadLevel("scLobby");
    }
}
