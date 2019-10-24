using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VerInstrucciones : MonoBehaviour
{
    public GameObject instrucciones;
    public TextMeshProUGUI textoBoton;

    private bool activo=false;
    public void toggleInstrucciones()
    {
        instrucciones.SetActive(!activo);
        activo = !activo;
        if (activo)
        {
            textoBoton.text = "Ocultar Tiempos";
        }
        else
        {
            textoBoton.text = "Mostrar Tiempos";

        }
    }
}
