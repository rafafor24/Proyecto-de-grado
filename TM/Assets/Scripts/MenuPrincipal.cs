using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{

    public bool quickGame;

    public float numPartida;

    private void Awake()
    {
        //if (GameObject.FindGameObjectsWithTag("MainMenu").Length==1)
        {
            DontDestroyOnLoad(this.transform);
        }
        
    }

    public void ClickMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickJuego()
    {
        MenuPrincipal mp = GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();
        mp.quickGame = false;
        SceneManager.LoadScene(2);
    }


    public void ClickJuegoRapido()
    {
        numPartida += 0.5f;
        MenuPrincipal mp = GameObject.Find("MainMenuDontDestroy").GetComponent<MenuPrincipal>();
        mp.quickGame = true;
        SceneManager.LoadScene(2);
    }

    public void ClickSalir()
    {
        Application.Quit();
    }
}
