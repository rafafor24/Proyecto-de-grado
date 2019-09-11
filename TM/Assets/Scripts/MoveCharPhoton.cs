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

    public TextMeshProUGUI decision;

    public Dialogue dec;

    private MenuLogic ml;

    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
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
            decision.text = "Ultima Decision: " + dec.sentences[coords.decisionId];
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

            Debug.Log((int)stream.ReceiveNext());
        }
    }

    public void ChangeTrigger(string trigger)
    {
        animator.SetTrigger(trigger);
    }

}
