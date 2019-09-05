using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ControlTiempo : MonoBehaviour
{

    public Slider sliderTiempo;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI timeActual;
    public Tiempo tiempo;

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
