using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void ClickMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ClickJuego()
    {
        SceneManager.LoadScene(2);
    }


    public void ClickJuegoRapido()
    {
        SceneManager.LoadScene(1);
    }

    public void ClickSalir()
    {
        Application.Quit();
    }
}
