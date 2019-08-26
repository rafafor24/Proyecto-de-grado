﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonManager : Photon.MonoBehaviour
{
    [SerializeField]private GameObject player;
    [SerializeField]private GameObject lobbyCamera;
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("1.0");
    }

    
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("Room", new RoomOptions() { MaxPlayers = 2 }, TypedLobby.Default);
    }
    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("Astronaut",player.transform.position,Quaternion.identity,0);
        lobbyCamera.SetActive(false);
    }

}
