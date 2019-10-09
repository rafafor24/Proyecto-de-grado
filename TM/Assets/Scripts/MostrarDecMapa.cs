using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarDecMapa : MonoBehaviour
{
    public TextMeshProUGUI miDecision,suDecision;

    public DecisionesTomadas lasDecisiones;

    public Dialogue[] decisionesTexto;

    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log("LasDecisiones.pos:"+ lasDecisiones.pos);
        Debug.Log("misCoords.decisionId" + lasDecisiones.mias[lasDecisiones.pos]);
        Debug.Log("susCoords.decisionId" + lasDecisiones.otro[lasDecisiones.pos]);
        Debug.Log("Mi:"+ decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.mias[lasDecisiones.pos]]);
        Debug.Log("Su:"+ decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.otro[lasDecisiones.pos]]);*/

    }

    // Update is called once per frame
    void Update()
    {
        if (lasDecisiones.pos != -1)
        {
            /*Debug.Log("EnIF");
            Debug.Log("Mi:" + decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.mias[lasDecisiones.pos]]);
            Debug.Log("Su:" + decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.otro[lasDecisiones.pos]]);*/
            miDecision.text = decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.mias[lasDecisiones.pos]];
            suDecision.text = decisionesTexto[lasDecisiones.pos].sentences[lasDecisiones.otro[lasDecisiones.pos]];
        }
        
    }
}
