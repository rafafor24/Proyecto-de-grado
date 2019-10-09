﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CreateMap : MonoBehaviour
{
    public GameObject prefab;

    public GameObject prefabVia;

    public Stations stations;

    public StationsId stationsId;

    public int dist;

    private int idCount;
    // Start is called before the first frame update
    void Start()
    {
        idCount = 0;
        for (int i = 0; i < stations.x; i++)
        {
            for (int j = 0; j < stations.y; j++)
            {
                GameObject newObject = Instantiate(prefab, new Vector3(i * dist, j * dist, 0), Quaternion.identity);
                newObject.GetComponentInChildren<TextMeshPro>().text = stations.stationsNames[i];
                newObject.transform.GetChild(1).transform.position= new Vector3(10000.4f, 10000.4f, 1.4f);
                MoverJugador moverJugador=newObject.GetComponent<MoverJugador>();
                moverJugador.setId(idCount++);

                if (i == 6 && j == 2)
                {
                    Debug.Log("ES true");
                    moverJugador.estadoMeta();
                    moverJugador.metaBool = true;
                }
                

                stationsId = (StationsId)newObject.GetComponent("StationsId");
                stationsId.idX = i;
                stationsId.idY = j;

                if (i != (stations.x-1))
                {
                Instantiate(prefabVia, new Vector3(4+(i * dist), j * dist, 0), Quaternion.identity);               
                }
                if (j != (stations.y - 1))
                {
                    GameObject prefY = Instantiate(prefabVia, new Vector3(i * dist, 4 + (j * dist), 0), Quaternion.identity);
                    prefY.transform.Rotate(0, 0, 90, Space.Self);
                }

                }
            }
    }    
}
