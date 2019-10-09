using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MenuLogic : Photon.MonoBehaviour
{
    public PhotonButtons photonB;

    public GameObject mainPlayer;

    public GameObject mainPlayer2;

    public CoordsPlayer coordsPlayer1;//

    public CoordsPlayer coordsPlayer2;//

    public bool player1 = false;

    public int decAct=1;
    private string initialRoomName;

    public DecisionesTomadas decisionesTomadas;

    public Tiempo tiempo;

    public EsperarJugador esperarJugador;

    private MenuPrincipal mp;

    public GameObject roomExiste;

    private TypedLobby lobbyAmigos = new TypedLobby("LobbyAmigos", LobbyType.Default);

    private TypedLobby lobbyQuick = new TypedLobby("LobbyQuick", LobbyType.Default);

    
    private void Awake()
    {
        mp= GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();

        coordsPlayer1.x = 3;
        coordsPlayer1.y = 2;
        coordsPlayer1.estId = -1;
        coordsPlayer1.decisionId = -1;
        coordsPlayer1.perdio = false;

        coordsPlayer2.x = 3;
        coordsPlayer2.y = 2;
        coordsPlayer2.estId = -1;
        coordsPlayer2.decisionId = -1;
        coordsPlayer2.perdio = false;

        decisionesTomadas.pos = -1;
        decisionesTomadas.mias[0] = -1;
        decisionesTomadas.mias[1] = -1;
        decisionesTomadas.mias[2] = -1;

        decisionesTomadas.otro[0] = -1;
        decisionesTomadas.otro[1] = -1;
        decisionesTomadas.otro[2] = -1;

        esperarJugador.jugar[0] = false;
        esperarJugador.jugar[1] = false;
        esperarJugador.mostrarAviso = false;

        decisionesTomadas.calcular[0] = false;
        decisionesTomadas.calcular[1] = false;
        decisionesTomadas.calcular[2] = false;

        tiempo.MaxTime = 15;
        tiempo.ActualTimePlayer = 15;
        tiempo.ActualTimeOther = 15;

        if (GameObject.FindGameObjectsWithTag("MenuLogic").Length == 1)
        {
            DontDestroyOnLoad(this.transform);
        }
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void createNewRoom()
    {        
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, lobbyAmigos);
        player1 = true;
        initialRoomName = photonB.createRoomInput.text;
    }

    public void OnCreateRoomFailed()
    {
        roomExiste.SetActive(true);
    }

    public void joinOrCreateRoom()
    {
        initialRoomName = photonB.joinRoomInput.text;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, lobbyAmigos);
    }

    public void joinOrCreateRoomAgain()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        if (mp.quickGame)
        {
            Debug.Log("LobbyQuick");
            PhotonNetwork.JoinOrCreateRoom(initialRoomName, roomOptions, lobbyQuick);
        }
        else
        {
            Debug.Log("LobbyAmigos");
            PhotonNetwork.JoinOrCreateRoom(initialRoomName, roomOptions, lobbyAmigos);
        }
        
        disableMenuUI();
    }

    

    public void joinOrCreateRoomQuick()
    {
        player1 = false;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinRandomRoom();
        disableMenuUI();
    }

    void OnPhotonRandomJoinFailed()
    {
        player1 = true;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(null,roomOptions, lobbyQuick); //maxPlayer limit can be any amount
    }

    public void disableMenuUI()
    {
        PhotonNetwork.LoadLevel("Map");
    }

    private void OnJoinedRoom()
    {
        initialRoomName = PhotonNetwork.room.Name;
        disableMenuUI();
    }

    private void OnSceneFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map")
        {
            spawnPlayer();
        }
    }

    private void spawnPlayer()
    {
        if (player1)
        {
            PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
        }
        else
        {
            PhotonNetwork.Instantiate(mainPlayer2.name, mainPlayer2.transform.position, mainPlayer2.transform.rotation, 0);
        }
    }

    public CoordsPlayer getCoords()
    {
        return player1 ? coordsPlayer1 : coordsPlayer2;
    }

    public CoordsPlayer GetCoordsOther()
    {
        return player1 ? coordsPlayer2 : coordsPlayer1;
    }

    public void updateCoords(CoordsPlayer player)
    {
        if (player1)
        {
            coordsPlayer1 = player;
        }
        else
        {
            coordsPlayer2 = player;
        }
    }

    public void updateCoordXPlayer(int decId)
    {
        if (!player1)
        {
            coordsPlayer1.decisionId = decId;
        }
        else
        {
            coordsPlayer2.decisionId = decId;
        }
    }

    public EsperarJugador GetEsperarJugador()
    {
        return esperarJugador;
    }

    public DecisionesTomadas GetDecisionesTomadas()
    {
        return decisionesTomadas;
    }
}