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

        Debug.Log("On Joined Lobby");
    }
    private void OnDisconnectedFromPhoton()
    {
        if (buttonCon.activeSelf)
            buttonCon.SetActive(false);

        if (exito.activeSelf)
            exito.SetActive(false);

        error.SetActive(true);
        Debug.Log("Desconexion de photon");
    }



}
