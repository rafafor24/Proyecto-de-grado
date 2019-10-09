﻿using System.Collections;
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
            if (numPlayers == 1)
            {
                cargando.SetActive(false);
                esperandoJugador.SetActive(true);
            }
            else if (numPlayers == 2)
            {
                cargando.SetActive(false);
                esperandoJugador.SetActive(false);
            }
            else if (numPlayers == 0)
            {
                cargando.SetActive(true);

                esperandoJugador.SetActive(false);
            }
        }
        else
        {
            numPlayers = 0;
        }
    }

}
