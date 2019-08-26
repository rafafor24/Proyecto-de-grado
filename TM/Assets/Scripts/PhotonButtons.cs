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
        }
    }
    public void onCLickJoinedRoom()
    {
        if (joinRoomInput.text.Length >= 1)
        {
            PhotonNetwork.JoinRoom(joinRoomInput.text);
        }
    }

    private void OnJoinedRoom()
    {
        mLogic.disableMenuUI();
        Debug.Log("Conectado a la sala");
    }

}
