using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Puntaje", menuName = "Puntaje")]
public class Puntajes : ScriptableObject 
{
    // Ambos jugadores seleccionaron la opción correcta
    public int ambosBien;

    // El jugador principal seleccionó la correcta y el contrario la incorrecta
    public int unoBienOtroMal;

    // Ambos jugadores seleccionaron la opción incorrecta
    public int ambosMal;

    // El jugador principal seleccionó la opción incorrecta y el contrario la correcta
    public int unoMalOtroBien;
}
