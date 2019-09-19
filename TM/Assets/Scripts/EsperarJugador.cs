using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EsperarJugador", menuName = "EsperarJugador")]
public class EsperarJugador : ScriptableObject
{
    public bool[] jugar;

    public bool mostrarAviso;
}
