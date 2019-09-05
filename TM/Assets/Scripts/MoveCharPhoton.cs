using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharPhoton : Photon.MonoBehaviour
{

    public bool devTest = false;

    public PhotonView photonView;

    public float moveSpeed = 100f;

    private Vector3 selfPos;

    public GameObject plCam;

    private GameObject sceneCam;

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

        }
        else
        {
            selfPos = (Vector3)stream.ReceiveNext();
        }
    }
}
