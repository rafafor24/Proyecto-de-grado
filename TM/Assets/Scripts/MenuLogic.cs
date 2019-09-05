using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
public class MenuLogic : MonoBehaviour
{
    public PhotonButtons photonB;

    public GameObject mainPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(this.transform);
        SceneManager.sceneLoaded += OnSceneFinishedLoading;
    }

    public void createNewRoom()
    {
        PhotonNetwork.CreateRoom(photonB.createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
    }

    public void joinOrCreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(photonB.joinRoomInput.text, roomOptions, TypedLobby.Default);
    }
    public void disableMenuUI()
    {
        PhotonNetwork.LoadLevel("Map");
    }

    private void OnJoinedRoom()
    {
        disableMenuUI();
        Debug.Log("Conectado a la sala");
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
}
