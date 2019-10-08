using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlEsperandoJugador : MonoBehaviour
{
    private MenuLogic ml;

    public GameObject esperandoJugador;

    public GameObject cargando;
    // Start is called before the first frame update
    void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
    }

    private void Update()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        if (SceneManager.GetActiveScene().name == "Map")
        {
            Debug.Log("En Map: " + ml.numPlayers);
            if (ml.numPlayers == 1)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(1, 1, 1);
                Debug.Log("Esperando Jugador 2");
            }
            else if (ml.numPlayers == 2)
            {
                cargando.SetActive(false);
                esperandoJugador.transform.localScale = new Vector3(0, 0, 0);
                Debug.Log("Hay 2");
            }
            else if (ml.numPlayers == 0)
            {
                cargando.SetActive(true);
                Debug.Log("Hay 0");
            }
        }
        else
        {
            Debug.Log("En No Map: " + ml.numPlayers);
            ml.numPlayers = 0;
            Debug.Log("En NO Map: " + ml.numPlayers);
        }
    }

}
