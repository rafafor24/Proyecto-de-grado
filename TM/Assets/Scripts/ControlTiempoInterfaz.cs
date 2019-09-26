using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class ControlTiempoInterfaz : MonoBehaviour
{

    public Slider sliderTiempo;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI timeActual;
    public Tiempo tiempo;

    private CoordsPlayer coordsPlayer;
    private CoordsPlayer coordsOther;

    public DecisionesTomadas decisionesTomadas;

    public Puntajes puntajes;
    private MenuLogic ml;

    //True Hizo Fila

    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        coordsPlayer = ml.getCoords();
        coordsOther = ml.GetCoordsOther();
        if (decisionesTomadas.pos == -1)
        {
            ChangeMaxTime(15);
            ChangeTimeActual(15);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            ChangeMaxTime(15);
            ActualizarTiempoInterfaz();
        }
    }

    private void Update()
    {
        if (decisionesTomadas.pos > -1 && decisionesTomadas.pos < 3)
        {

            int dec1 = decisionesTomadas.mias[decisionesTomadas.pos];
            int dec2 = decisionesTomadas.otro[decisionesTomadas.pos];
            bool calc = decisionesTomadas.calcular[decisionesTomadas.pos];
            //Debug.Log("Entra al if del update dec1: " + dec1 + " dec2: " + dec2 + " calcular=" + calc);


            if (calc)
            {
                bool bDec1 = dec1 == 1;
                bool bDec2 = dec2 == 1;

                //Debug.Log("dec1 bool: " + bDec1 + " dec2 bool: " + bDec2);

                int ptj = CambiarTiempos(bDec1, bDec2);
                //Debug.Log("ptj: " + ptj);
                ReduceTimeActual(ptj);
                decisionesTomadas.calcular[decisionesTomadas.pos] = false;
                decisionesTomadas.pos++;
            }
        }

        if (tiempo.ActualTime < 0)
        {
            coordsPlayer.perdio = true;
            StartCoroutine(EsperarCambio());
        }
        else
        {
            //Debug.Log("length "+GameObject.FindGameObjectsWithTag("Player").Length);
            //Debug.Log("pos "+decisionesTomadas.pos);
            if (coordsOther.perdio && (GameObject.FindGameObjectsWithTag("Player").Length < 2 || coordsPlayer.x == 6 && coordsPlayer.x == 2))
            {
                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
            }
            else if(coordsPlayer.x == 6 && coordsPlayer.x == 2)
            {
                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
            }
        }
    }

    private void ActualizarTiempoInterfaz()
    {

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

    public int CambiarTiempos(bool des1, bool des2)
    {
        int rpta = -1;

        if (des1 && des2)
        {
            rpta = puntajes.ambosBien;
        }
        else if (des1 && !des2)
        {
            rpta = puntajes.unoMalOtroBien;
        }
        else if (!des1 && des2)
        {
            rpta = puntajes.unoBienOtroMal;
        }
        else if (!des1 && !des2)
        {
            rpta = puntajes.ambosMal;
        }

        return rpta;
    }

    IEnumerator EsperarCambio()
    {
        yield return new WaitForSeconds(5);
        PhotonNetwork.LoadLevel("Perder");
        PhotonNetwork.LeaveRoom();
    }

}
