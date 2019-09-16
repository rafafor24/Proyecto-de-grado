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
        DontDestroyOnLoad(this.transform);
    }

    public void ClickMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickJuego()
    {
        quickGame = false;
        SceneManager.LoadScene(2);
    }


    public void ClickJuegoRapido()
    {
        numPartida += 0.5f;
        quickGame = true;
        SceneManager.LoadScene(2);
    }

    public void ClickSalir()
    {
        Application.Quit();
    }
}
