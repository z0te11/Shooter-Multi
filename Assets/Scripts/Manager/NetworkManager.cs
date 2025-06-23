using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        base.OnEnable();
        EndGameController.onGameEnded += DisconnectPLayer;
    }

    public override void OnDisable()
    {
        base.OnDisable();
        EndGameController.onGameEnded -= DisconnectPLayer;
    }
    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.ConnectUsingSettings();
            Debug.Log("ConnectUsingSettings");
        }
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 2,
            IsVisible = false
        };
        PhotonNetwork.JoinOrCreateRoom("test", options, TypedLobby.Default);
        Debug.Log("Connected To Master");
    }

    public override void OnJoinedRoom()
    {
        var id = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("Joined Room with " + PhotonNetwork.CurrentRoom.PlayerCount + " players and ID is " + id);
        GameManager.instance.Play(id);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Не удалось найти комнату, создаём новую...");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 2 });
    }

    public void SayHelllo()
    {
        this.photonView.RPC("Hello", RpcTarget.All, (byte)PhotonNetwork.LocalPlayer.ActorNumber);
    }

    [PunRPC]
    public void Hello(byte playerId)
    {
        Debug.Log($"Player Id {playerId} said Hello!");
    }

    public void DisconnectPLayer()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.Disconnect();
            Debug.Log("Disconnect From Server");
        }
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
            Debug.Log("Leave from room");
        }
    }
}
