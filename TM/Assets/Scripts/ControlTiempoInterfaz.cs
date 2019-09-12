using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ControlTiempoInterfaz : MonoBehaviour
{

    public Slider sliderTiempo;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI timeActual;
    public Tiempo tiempo;
    private ControlTiempoPuntaje ctp;
    private bool dec1;
    private bool dec2;

    private void Start()
    {          
        ctp = GetComponent<ControlTiempoPuntaje>();
        if ((GameObject.Find("DecisionActual").GetComponent<TextMeshProUGUI>().text == "----------------")
            )//Primera vez entra
        {
            ChangeMaxTime(15);
            ChangeTimeActual(15);
        }
        else//llegar despues de un minijuego
        {
            dec1 = (GameObject.Find("DecisionActual").GetComponent<TextMeshProUGUI>().text == "Hacer la Fila");
            dec2 = (GameObject.Find("DecisionOtro").GetComponent<TextMeshProUGUI>().text == "Hacer la fila");
            
            int ptj = ctp.CambiarTiempos(dec1, dec2);
            Debug.Log(ptj);
            ReduceTimeActual(ptj);
            Debug.Log(tiempo.ActualTime);
        }
        
        
    }

    public void ChangeMaxTime(int time)
    {
        tiempo.MaxTime = time;
        sliderTiempo.maxValue = tiempo.MaxTime;
        maxTime.SetText(tiempo.MaxTime.ToString());
    }

    public void ChangeTimeActual(int time)
    {
        tiempo.ActualTime = time;
        timeActual.SetText(tiempo.ActualTime.ToString());
        sliderTiempo.value = tiempo.ActualTime;
    }

    public void ReduceTimeActual(int time)
    {
        tiempo.ActualTime = tiempo.ActualTime - time;
        timeActual.SetText(tiempo.ActualTime.ToString());
        sliderTiempo.value = tiempo.ActualTime;
    }
}

