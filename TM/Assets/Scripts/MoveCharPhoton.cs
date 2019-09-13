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

    public Animator animator;

    private TextMeshProUGUI decision;

    public DecisionesTomadas decisionesTomadas;

    public Dialogue dec;

    private MenuLogic ml;

    private bool guardado = false;

    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        decision = GameObject.Find("DecisionActual").GetComponent<TextMeshProUGUI>();
        coords = ml.getCoords();
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

        if (coords.decisionId != -1)
        {
            decision.text = dec.sentences[coords.decisionId];
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

        }
        else
        {
            selfPos = (Vector3)stream.ReceiveNext();
            int tal = (int)stream.ReceiveNext();
            GameObject.Find("DecisionOtro").GetComponent<TextMeshProUGUI>().text = dec.sentences[tal];

            if (decisionesTomadas.pos==-1)
            {
                decisionesTomadas.pos++;
                Debug.Log("Entra al if inicial");
            }else if(decisionesTomadas.pos<3 && !guardado
                && tal!=-1 && coords.decisionId!=-1 &&
                decisionesTomadas.mias[decisionesTomadas.pos]==-1 && decisionesTomadas.otro[decisionesTomadas.pos] == -1 )
            {
                Debug.Log("Entra a asignar decisiones en el espacio: "+decisionesTomadas.pos);
                decisionesTomadas.mias[decisionesTomadas.pos] = tal;
                decisionesTomadas.otro[decisionesTomadas.pos] = coords.decisionId;
                guardado=true;
                decisionesTomadas.pos++;
            }




            /*
            if (decisionesTomadas.otro[decisionesTomadas.pos] != -1)
            {
                decisionesTomadas.otro[decisionesTomadas.pos] = tal;
                Debug.Log("If1"+decisionesTomadas.pos);
            }

            if (decisionesTomadas.mias[decisionesTomadas.pos] != -1)
            {
                decisionesTomadas.mias[decisionesTomadas.pos] = coords.decisionId;
                Debug.Log("If1"+decisionesTomadas.pos);
            }*/

        }
    }

    private void OnDestroy()
    {
        //decisionesTomadas.pos += 1;
        Debug.Log(decisionesTomadas.pos);
    }

    public void ChangeTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

}
