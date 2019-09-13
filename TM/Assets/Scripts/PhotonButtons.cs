using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhotonButtons : MonoBehaviour
{

    public MenuLogic mLogic;

    public TMP_InputField createRoomInput, joinRoomInput;

    public void onCLickCreateRoom()
    {
        if (createRoomInput.text.Length >= 1)
        {
            mLogic.createNewRoom();
        }
    }
    public void onCLickJoinedRoom()
    {
        if (joinRoomInput.text.Length >= 1)
        {
            mLogic.joinOrCreateRoom();
        }
    }

}
