using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PasarInstrucciones : MonoBehaviour
{
    public GameObject parte1;
    public GameObject parte2;

    public GameObject sig;
    public GameObject ant;

    public void siguienteParte()
    {                    
        sig.SetActive(false);        
        ant.SetActive(true);
        parte1.SetActive(false);
        parte2.SetActive(true);
    }
    
    public void anteriorParte()
    {
        sig.SetActive(true);
        ant.SetActive(false);
        parte1.SetActive(true);
        parte2.SetActive(false);
    }     
    
}
