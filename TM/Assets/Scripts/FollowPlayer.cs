using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject jugador;

    private Vector3 posInitJugador;
    private Vector3 posInitCamara;
    // Start is called before the first frame update
    void Start()
    {
        posInitJugador = jugador.transform.position;
        posInitCamara = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cambio = jugador.transform.position - posInitJugador;
        transform.position = posInitCamara + cambio;
    }
}
