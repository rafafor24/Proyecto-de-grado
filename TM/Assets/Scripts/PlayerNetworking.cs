﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetworking : MonoBehaviour
{
    [SerializeField] private GameObject playerCamara;
    [SerializeField] private MonoBehaviour[] scriptsToIgnore;

    PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        Initialize();
    }

    void Initialize()
    {
        if (photonView.isMine)
        {

        }
        else
        {
            playerCamara.SetActive(false);
            foreach(MonoBehaviour item in scriptsToIgnore)
            {
                item.enabled=false;
            }
        }
    }

}
