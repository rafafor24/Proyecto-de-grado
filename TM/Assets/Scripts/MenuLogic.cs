using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MenuLogic : Photon.MonoBehaviour
{
    public PhotonButtons photonB;

    public GameObject mainPlayer;

    public CoordsPlayer coordsPlayer1;//

    public CoordsPlayer coordsPlayer2;//

    private bool player1=false;

    private string initialRoomName;




    private void Awake()
    {
        coordsPlayer1.x = 2;
        coordsPlayer1.y = 2;
        coordsPlayer1.estId = -1;
        coordsPlayer1.decisionId = -1;

        coordsPlayer2.x = 3;
        coordsPlayer2.y = 2;
        coordsPlayer2.estId = -1;
        coordsPlayer2.decisionId = -1;

        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void createNewRoom()
    {
        player1 = true;
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
        initialRoomName = photonB.createRoomInput.text;
    }

    public void joinOrCreateRoom()
    {
        initialRoomName = photonB.joinRoomInput.text;
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }

    public void joinOrCreateRoomAgain()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(initialRoomName, roomOptions, TypedLobby.Default);
        disableMenuUI();
    }

    public void disableMenuUI()
    {
        PhotonNetwork.LoadLevel("Map");
    }

    private void OnJoinedRoom()
    {
        disableMenuUI();        
        Debug.Log(PhotonNetwork.room.Name);
        Debug.Log("Conectado a la sala"+PhotonNetwork.GetRoomList().Length);
    }

    private void OnSceneFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if (scene.name == "Map")
        {
            spawnPlayer();

        }
    }

    

    private void spawnPlayer()
    {
        PhotonNetwork.Instantiate(mainPlayer.name, mainPlayer.transform.position, mainPlayer.transform.rotation, 0);
    }

    public CoordsPlayer getCoords()
    {
        return player1 ? coordsPlayer1 : coordsPlayer2;
    }

    public void updateCoords(CoordsPlayer player)
    {
        Debug.Log("x: " + player.x +" y: "+ player.y +" dec: "+ player.decisionId +" est: "+ player.estId);
        if (player1)
        {
            coordsPlayer1 = player;
        }
        else
        {
            coordsPlayer2 = player;
        }

        Debug.Log("x: " + coordsPlayer1.x + " y: " + coordsPlayer1.y + " dec: " + coordsPlayer1.decisionId + " est: " + coordsPlayer1.estId);
        Debug.Log("x: " + coordsPlayer2.x + " y: " + coordsPlayer2.y + " dec: " + coordsPlayer2.decisionId + " est: " + coordsPlayer2.estId);

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
}
