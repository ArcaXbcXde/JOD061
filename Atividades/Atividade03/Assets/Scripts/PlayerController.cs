using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class PlayerController : NetworkBehaviour {

    public float moveSpeed = 0.2f;
    public float moveRotation = 20;

    private void Update() {

        if (isLocalPlayer) {

            transform.Translate(0, 0, Input.GetAxis("Vertical") * moveSpeed);
            transform.Rotate(0, Input.GetAxis("Horizontal") * moveRotation, 0);
        }
    }

}
