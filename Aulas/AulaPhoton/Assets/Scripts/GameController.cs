using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class GameController : MonoBehaviourPunCallbacks {
    
    public void OnClickSair() {

        PhotonNetwork.LeaveRoom();
    }


    public override void OnPlayerEnteredRoom(Player newPlayer) {

        Debug.Log(newPlayer.NickName + " entrou na sala " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnLeftRoom() {


    }
}
