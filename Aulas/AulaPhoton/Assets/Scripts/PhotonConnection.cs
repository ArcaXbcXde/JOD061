using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class PhotonConnection : MonoBehaviourPunCallbacks {

    public byte maxPlayers = 4;
    
    public InputField inputField;
    public Button button;

    private void Awake() {
        

    }

    public void OnClickConnectar() {

        inputField.interactable = false;
        button.interactable = false;

        if (PhotonNetwork.IsConnected == false) {

            Debug.Log("Conectando ao servidor...");
            PhotonNetwork.GameVersion = "0.0.0";
            PhotonNetwork.NickName = inputField.text;
            PhotonNetwork.ConnectUsingSettings();
            return;
        }
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("GameScene");
    }

    public override void OnConnectedToMaster() {

        Debug.Log("Conectado ao servidor!");
        button.GetComponentInChildren<Text>().text = "Iniciar";
        button.interactable = true;
        PhotonNetwork.AutomaticallySyncScene = true;

    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = this.maxPlayers;
        PhotonNetwork.JoinOrCreateRoom("JOD061", options, TypedLobby.Default);
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.Log("Desconectado por " + cause.ToString());
    }

    public override void OnCreatedRoom() {
        Debug.Log("Entrou na sala " + PhotonNetwork.CurrentRoom.Name);
        Debug.Log("Total de jogadores: " + PhotonNetwork.CurrentRoom.PlayerCount.ToString());
        PhotonNetwork.LoadLevel("GameScene");
    }


}
