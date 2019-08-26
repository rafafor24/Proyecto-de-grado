using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonButtons : MonoBehaviour
{

    public MenuLogic mLogic;

    public InputField createRoomInput, joinRoomInput;

    public void onCLickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
        {
            PhotonNetwork.CreateRoom(createRoomInput.text, new RoomOptions() { MaxPlayers = 2 }, null);
            Debug.Log(PhotonNetwork.GetRoomList().Length);
        }
    }
    public void onCLickJoinedRoom()
    {
        Debug.Log(PhotonNetwork.GetRoomList().Length);
        if (joinRoomInput.text.Length >= 1)
        {
            Debug.Log(joinRoomInput.text);
            PhotonNetwork.JoinRoom(joinRoomInput.text);
        }
    }

    private void OnJoinedRoom()
    {
        mLogic.disableMenuUI();
        Debug.Log("Conectado a la sala");
    }

}
