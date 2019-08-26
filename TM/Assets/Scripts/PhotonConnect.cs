using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour
{
    public string versionName = "0.1";

    public GameObject buttonCon, exito, error;
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);

        Debug.Log("Conectandose a photon");
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);

        Debug.Log("Coneccion a Master!");

    }

    private void OnJoinedLobby()
    {
        buttonCon.SetActive(false);
        exito.SetActive(true);

        Debug.Log("On Joined Lobby");
    }
    private void OnDisconnectedFromPhoton()
    {
        if (buttonCon.active)
            buttonCon.SetActive(false);

        if (exito.active)
            exito.SetActive(false);

        error.SetActive(true);
        Debug.Log("Desconexion de photon");
    }



}
