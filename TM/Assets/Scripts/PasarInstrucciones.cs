using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasarInstrucciones : MonoBehaviour
{
    public GameObject[] partes;

    private int actual;

    private DecisionesTomadas decisiones;
    private MenuLogic ml;

    private void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        actual = 0;
        decisiones = ml.GetDecisionesTomadas();
    }

    public void siguienteParte()
    {
        actual++;
        if (actual == partes.Length)
        {
            actual = 0;
        }
        aux();
    }


    public void anteriorParte()
    {
        actual--;
        if (actual <0)
        {
            actual = partes.Length-1;
        }
        aux();
    }

    private void aux()
    {
        for (int i = 0; i < partes.Length; i++)
        {
            if (i == actual)
            {
                partes[i].SetActive(true);
            }
            else
            {
                partes[i].SetActive(false);
            }
        }
    }

    public void jugar()
    {
        if (decisiones.pos == -1)
        {
            PhotonNetwork.LoadLevel("Decision #1");
        }
        else if (decisiones.pos == 0)
        {
            PhotonNetwork.LoadLevel("Decision #1");
        }
        else if (decisiones.pos == 1)
        {
            PhotonNetwork.LoadLevel("Decision #2");
        }
        else if (decisiones.pos == 2)
        {
            PhotonNetwork.LoadLevel("Decision #3");
        }
    }
}
