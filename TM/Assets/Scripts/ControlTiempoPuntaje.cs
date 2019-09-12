using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTiempoPuntaje : MonoBehaviour
{
    public Puntajes puntajes;

    //True Hizo Fila
    public int CambiarTiempos(bool des1, bool des2)
    {
        int rpta = -1;

        if (des1 && des2)
        {
            rpta = puntajes.ambosBien;
        }else if (des1 && !des2)
        {
            rpta = puntajes.unoBienOtroMal;
        }else if (!des1 && des2)
        {
            rpta = puntajes.unoMalOtroBien;
        }else if (!des1 && !des2)
        {
            rpta = puntajes.ambosMal;
        }

        return rpta;
    }
}
