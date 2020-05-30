using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks {



    void Start() {

        Debug.Log("Conectando ao servidor...");
        PhotonNetwork.GameVersion = "0.0.0";
        PhotonNetwork.NickName = "Player1";
        PhotonNetwork.ConnectUsingSettings();

    }

    public override void OnConnectedToMaster() {

        Debug.Log("Conectado ao servidor!");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom("JOD061", options, TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.Log("Desconectado por " + cause.ToString());
    }

    public override void OnCreatedRoom() {
        Debug.Log("Entrou na sala " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Total de jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());
    }

}
