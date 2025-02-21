using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class NetworkManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 4,
            IsVisible = false
        };
        PhotonNetwork.JoinOrCreateRoom("test", options, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        var id = PhotonNetwork.LocalPlayer.ActorNumber;
        Debug.Log("Joined Room with " + PhotonNetwork.CurrentRoom.PlayerCount + " players and ID is " + id);
        GameManager.instance.Play();
        
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
}
