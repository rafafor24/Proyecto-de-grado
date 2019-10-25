using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ControlTiempoInterfaz : MonoBehaviour
{

    public Slider sliderTiempo;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI timeActual;
    public Tiempo tiempo;

    private CoordsPlayer coordsPlayer;
    private CoordsPlayer coordsOther;

    public DecisionesTomadas decisionesTomadas;

    public GameObject timeReducedObject;
    public TextMeshProUGUI timeReducedText;

    public Puntajes puntajes;
    private MenuLogic ml;

    public float speed = 500.0f;
    private bool moving;
    private float distanceInic;
    private int minutesReduc;


    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        coordsPlayer = ml.getCoords();
        coordsOther = ml.GetCoordsOther();
        distanceInic = Vector3.Distance(timeReducedObject.transform.position, timeActual.transform.position);
        moving = false;
        if (decisionesTomadas.pos == -1)
        {
            ChangeMaxTime(tiempo.MaxTime);
            ChangeTimeActual(tiempo.ActualTimePlayer);
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            ChangeMaxTime(tiempo.MaxTime);
            ChangeTimeActual(tiempo.ActualTimePlayer);
        }
    }

    private void Update()
    {
        if (moving)
        {
            float step = speed * Time.deltaTime;
            float actualScale = Vector3.Distance(timeReducedObject.transform.position, timeActual.transform.position) / distanceInic;

            timeReducedObject.transform.position = Vector3.MoveTowards(timeReducedObject.transform.position, timeActual.transform.position, 5);
            if(timeReducedObject.transform.localScale.x > 0.2f && timeReducedObject.transform.localScale.y > 0.2f)
            {
                timeReducedObject.transform.localScale =  new Vector3(actualScale,actualScale, 1);
            }

            if (Vector3.Distance(timeReducedObject.transform.position, timeActual.transform.position) < 0.001f)
            {
                moving = false;
                timeReducedObject.SetActive(false);
                tiempo.ActualTimePlayer = tiempo.ActualTimePlayer - minutesReduc;
                timeActual.SetText(tiempo.ActualTimePlayer.ToString());
                sliderTiempo.value = tiempo.ActualTimePlayer;
                minutesReduc = 0;
            }
        }

        if (decisionesTomadas.pos > -1 && decisionesTomadas.pos < 3)
        {

            int dec1 = decisionesTomadas.mias[decisionesTomadas.pos];
            int dec2 = decisionesTomadas.otro[decisionesTomadas.pos];
            bool calc = decisionesTomadas.calcular[decisionesTomadas.pos];


            if (calc)
            {
                bool bDec1 = dec1 == 1;
                bool bDec2 = dec2 == 1;

                int ptj = CambiarTiempos(bDec1, bDec2);
                int ptj2 = CambiarTiempos(bDec2, bDec1);

                ReduceTimeActualPlayer(ptj);
                ReduceTimeActualOther(ptj2);

                decisionesTomadas.calcular[decisionesTomadas.pos] = false;
                decisionesTomadas.pos++;
            }
        }

        if (tiempo.ActualTimePlayer < 0)
        {
            coordsPlayer.perdio = true;
            StartCoroutine(EsperarCambio());
        }else if (tiempo.ActualTimePlayer == 0)
        {
            if (coordsPlayer.x == 6 && coordsPlayer.y == 2)
            {
                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
            }
            else
            {
                coordsPlayer.perdio = true;
                StartCoroutine(EsperarCambio());
            }
        }
        else
        {
            if (coordsOther.perdio && (GameObject.FindGameObjectsWithTag("Player").Length < 2))
            {
                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
            }
            else if(coordsPlayer.x == 6 && coordsPlayer.y == 2 && coordsOther.x == 6 && coordsOther.y == 2)
            {

                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
            }else if (tiempo.ActualTimePlayer==tiempo.ActualTimeOther && decisionesTomadas.pos == 3)
            {
                PhotonNetwork.LoadLevel("Ganar");
                PhotonNetwork.LeaveRoom();
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
        tiempo.ActualTimePlayer = time;
        tiempo.ActualTimeOther = time;
        timeActual.SetText(tiempo.ActualTimePlayer.ToString());
        sliderTiempo.value = tiempo.ActualTimePlayer;
    }

    public void ReduceTimeActualPlayer(int time)
    {
        timeReducedObject.SetActive(true);
        timeReducedText.SetText("-"+time+" min");
        StartCoroutine(ShowReducedTime());
        minutesReduc = time;

    }

    public void ReduceTimeActualOther(int time)
    {
        tiempo.ActualTimeOther = tiempo.ActualTimeOther - time;
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

    IEnumerator ShowReducedTime()
    {
        yield return new WaitForSeconds(3);
        moving = true;
    }

}
