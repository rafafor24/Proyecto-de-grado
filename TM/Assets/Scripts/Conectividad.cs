using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conectividad : MonoBehaviour
{

   
    public string versionName = "0.2";//0.2 Version para pruebas

    public ConectividadEventual conectividadEventual;
    private MenuPrincipal mp;
    private MenuLogic ml;
    private TypedLobby lobbyAmigos = new TypedLobby("LobbyAmigos", LobbyType.Default);

    private TypedLobby lobbyQuick = new TypedLobby("LobbyQuick", LobbyType.Default);
    // Start is called before the first frame update

    private void Start()
    {
        mp = GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Room name: " + PhotonNetwork.room.Name);
        Debug.Log("Room #: " + PhotonNetwork.room.PlayerCount);
        Debug.Log("R4egion: " + PhotonNetwork.CloudRegion); 
        Debug.Log("Lobby name: " + PhotonNetwork.lobby.Name);
        
        /*MenuLogic ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        if (PhotonNetwork.connected)
        {
            Debug.Log("##################GOOD");
            if (conectividadEventual.fallo)
            {
                Debug.Log("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$ENTRA IF");
                conectividadEventual.fallo = false;
                Debug.Log("$$$$$$$$$$$$$$$$$$ROOM" + PhotonNetwork.room);
                ml.joinOrCreateRoomQuick();
                Debug.Log("$$$$$$$$$$$$$$$$$$ROOM" + PhotonNetwork.room);
            }

        }
        else
        {
            Debug.Log("##################RIP");
            conectividadEventual.fallo = true;
            PhotonNetwork.ConnectUsingSettings(versionName);

        }*/
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

        Debug.Log("Coneccion a Master!, Lobby name: "+PhotonNetwork.lobby.Name);

    }
    private void OnJoinedLobby()
    {

        /*if (mp.quickGame)
        {
            ml.joinOrCreateRoomQuick();
        }
        else
        {
            ml.joinOrCreateRoomAgain();
        }*/
        ml.joinOrCreateRoomAgain();
        Debug.Log("On Joined Lobby, Room Name:"+PhotonNetwork.room.Name);
    }

    private void OnDisconnectedFromPhoton()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
        Debug.Log("Desconexion de photon");
    }

 
}
