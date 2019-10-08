using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEsperandoJugador : MonoBehaviour
{
    public GameObject esperandoJugador;

    public GameObject cargando;
    
    public int numPlayers = 0;
    
    private void Update()
    {
        numPlayers = GameObject.FindGameObjectsWithTag("Player").Length;
        if (SceneManager.GetActiveScene().name == "Map")
        {
            Debug.Log("En Map: " + numPlayers);
            if (numPlayers == 1)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("Esperando Jugador 2");
            }
            else if (numPlayers == 2)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(0, 0, 0);
                Debug.Log("Hay 2");
            }
            else if (numPlayers == 0)
            {
                cargando.SetActive(true);
                Debug.Log("Hay 0");
            }
        }
        else
        {
            Debug.Log("En No Map: " + numPlayers);
            numPlayers = 0;
            Debug.Log("En NO Map: " + numPlayers);
        }
    }

}
