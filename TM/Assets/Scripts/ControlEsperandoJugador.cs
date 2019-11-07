using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEsperandoJugador : MonoBehaviour
{
    public GameObject esperandoJugador;

    public GameObject cargando;

    public GameObject sinConexion;
    
    public int numPlayers = 0;

    private bool entro = false;

    private void Update()
    {
        numPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (SceneManager.GetActiveScene().name == "Map")
        {
            if (numPlayers == 1)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(1, 1, 1);
                entro = true;
            }
            else if (numPlayers == 2 && entro)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(0, 0, 0);
                entro = false;
            }
            else if (numPlayers == 0)
            {
                cargando.SetActive(true);
            }
            
            if (PhotonNetwork.connectionState.ToString().Equals("Disconnected"))
            {
                cargando.SetActive(false);
                esperandoJugador.SetActive(false);
                sinConexion.SetActive(true);
            }
        }
        else
        {
            numPlayers = 0;
        }
    }

}
