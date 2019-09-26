using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCharPhoton : Photon.MonoBehaviour
{

    public bool devTest = false;

    public PhotonView photonView;

    public float moveSpeed = 100f;

    private Vector3 selfPos;

    public GameObject plCam;

    private GameObject sceneCam;

    private CoordsPlayer coords;

    private CoordsPlayer coordsOther;

    public Animator animator;

    private TextMeshProUGUI decision;

    public DecisionesTomadas decisionesTomadas;

    public Dialogue[] dec;

    private MenuLogic ml;

    private EsperarJugador ej;

    private bool guardado = false;

    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        decision = GameObject.Find("DecisionActual").GetComponent<TextMeshProUGUI>();
        coords = ml.getCoords();
        coordsOther = ml.GetCoordsOther();
        ej = ml.GetEsperarJugador();
        transform.position = new Vector3(coords.x * 7, coords.y * 7, 0);
    }

    private void Awake()
    {
        if (!devTest && photonView.isMine)
        {
            sceneCam = GameObject.Find("Main Camera");
            sceneCam.SetActive(false);
            plCam.SetActive(true);
        }
    }

    private void Update()
    {
        if (!devTest)
        {
            if (photonView.isMine)
            {
                checkInput();
            }
            else
            {
                smoothNetMov();
            }
        }
        else
        {
            checkInput();
        }

    }
    
    private void checkInput()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;
        int posInterna = decisionesTomadas.pos == -1 ? 0 : decisionesTomadas.pos;
        if (coords.decisionId != -1)
        {
            decision.text = dec[posInterna].sentences[coords.decisionId];//ml.decAct-1
        }
    }

    private void smoothNetMov()
    {
        transform.position = Vector3.Lerp(transform.position, selfPos, Time.deltaTime * 8);
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.isWriting)
        {

            stream.SendNext(transform.position);
            stream.SendNext(coords.decisionId);
            stream.SendNext(ej.jugar[0]);
            stream.SendNext(coords.perdio);

        }
        else
        {
            selfPos = (Vector3)stream.ReceiveNext();
            int tal = (int)stream.ReceiveNext();
            bool otroJugar = (bool)stream.ReceiveNext();
            bool perdioOtro = (bool)stream.ReceiveNext();
            coordsOther.perdio = perdioOtro;

            ej.jugar[1] = otroJugar;
            
            if (decisionesTomadas.pos == -1)
            {
                decisionesTomadas.pos++;
            }

            decision.text = dec[decisionesTomadas.pos].sentences[coords.decisionId];
            GameObject.Find("DecisionOtro").GetComponent<TextMeshProUGUI>().text = dec[decisionesTomadas.pos].sentences[tal];


            if (decisionesTomadas.pos < 3 && !guardado
                && tal != -1 && coords.decisionId != -1 &&
                decisionesTomadas.mias[decisionesTomadas.pos] == -1 && decisionesTomadas.otro[decisionesTomadas.pos] == -1)
            {
                decisionesTomadas.mias[decisionesTomadas.pos] = tal;
                decisionesTomadas.otro[decisionesTomadas.pos] = coords.decisionId;
                decisionesTomadas.calcular[decisionesTomadas.pos] = true;
                guardado = true;
            }
        }
    }

    private void OnDestroy()
    {
    }

    public void ChangeTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

}