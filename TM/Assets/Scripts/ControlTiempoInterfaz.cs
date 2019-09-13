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

    public DecisionesTomadas decisionesTomadas;


    private void Start()
    {          
        ctp = GetComponent<ControlTiempoPuntaje>();
        if(decisionesTomadas.pos==-1)
        {
            ChangeMaxTime(15);
            ChangeTimeActual(15);
        }
        
        
    }

    
    private void Update()
    {

        if (decisionesTomadas.pos > -1 && decisionesTomadas.pos<3)
        {

            int dec1 = decisionesTomadas.mias[decisionesTomadas.pos];
            int dec2 = decisionesTomadas.otro[decisionesTomadas.pos];
            
            if (!decisionesTomadas.calculado[decisionesTomadas.pos] && dec1 != -1 && dec2 != -1)
            {
                bool bDec1 = dec1 == 1;
                bool bDec2 = dec2 == 1;

                Debug.Log("dec1 bool: "+bDec1);
                Debug.Log("dec2 bool: "+bDec2);

                int ptj = ctp.CambiarTiempos(bDec1, bDec2);
                Debug.Log("ptj: " + ptj);
                ReduceTimeActual(ptj);
                decisionesTomadas.calculado[decisionesTomadas.pos] = true;
            }
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

