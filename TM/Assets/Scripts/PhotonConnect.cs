using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnect : MonoBehaviour
{
    public string versionName = "0.2";//0.2 Version para pruebas

    public GameObject buttonCon, exito, error;

    private TypedLobby lobbyAmigos = new TypedLobby("LobbyAmigos", LobbyType.Default);

    private TypedLobby lobbyQuick = new TypedLobby("LobbyQuick", LobbyType.Default);


    private MenuPrincipal mp;
    private void Awake()
    {
        mp = GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();

        if (PhotonNetwork.connectionState.ToString().Equals("Disconnected"))
        {
            PhotonNetwork.ConnectUsingSettings(versionName);
        }
        else
        {
            buttonCon.SetActive(false);

            MenuLogic ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
            if (mp.quickGame)
            {
                ml.joinOrCreateRoomQuick();
            }
            else
            {
                exito.SetActive(true);
            }
        }

        //Debug.Log("Conectandose a photon");
    }

    private void OnConnectedToMaster()
    {
        if (mp.quickGame)
        {
            PhotonNetwork.JoinLobby(lobbyQuick);

        }
        else
        {
            PhotonNetwork.JoinLobby(lobbyAmigos);
        }

    }

    private void OnJoinedLobby()
    {
        buttonCon.SetActive(false);

        MenuPrincipal mp = GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();
        MenuLogic ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        if (mp.quickGame)
        {
            ml.joinOrCreateRoomQuick();
        }
        else
        {
            exito.SetActive(true);
        }        
    }
    private void OnDisconnectedFromPhoton()
    {
        if (buttonCon.activeSelf)
            buttonCon.SetActive(false);

        if (exito.activeSelf)
            exito.SetActive(false);

        error.SetActive(true);
    }
}
