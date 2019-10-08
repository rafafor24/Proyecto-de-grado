using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasarInstrucciones : MonoBehaviour
{
    public GameObject[] partes;

    public int actual;

    private void Start()
    {
        actual = 0;
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
}
