using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menupausa;
    private bool enable;

    
    public void switchViewMenu()
    {
        if (enable)
        {
            menupausa.SetActive(false);
            enable = false;
        }
        else
        {
            menupausa.SetActive(true);
            enable = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switchViewMenu();
        }

       
            if (Input.GetKeyDown("space"))
            {
                Debug.Log(PhotonNetwork.connectionState);
                Debug.Log(PhotonNetwork.room.Name);
                Debug.Log(PhotonNetwork.lobby.Name);
            }
        
    }

    public void ClickMenuPrincipal()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LeaveLobby();
        SceneManager.LoadScene(0);
    }

    public void ClickSalir()
    {
        Application.Quit();
    }
}
