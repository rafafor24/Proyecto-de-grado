using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MostrarDecMapa : MonoBehaviour
{
    public TextMeshProUGUI miDecision,suDecision;
    public DecisionesTomadas lasDecisiones;
    private CoordsPlayer misCoords, susCoords;

    public Dialogue[] decisionesTexto;
    private MenuLogic ml;

    // Start is called before the first frame update
    void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        misCoords = ml.getCoords();
        susCoords = ml.GetCoordsOther();
        Debug.Log("LasDecisiones.pos:"+ lasDecisiones.pos);
        Debug.Log("misCoords.decisionId" + misCoords.decisionId);
        Debug.Log("susCoords.decisionId" + susCoords.decisionId);
        Debug.Log("Mi:"+ decisionesTexto[lasDecisiones.pos].sentences[misCoords.decisionId]);
        Debug.Log("Su:"+ decisionesTexto[lasDecisiones.pos].sentences[susCoords.decisionId]);

    }

    // Update is called once per frame
    void Update()
    {
        if (lasDecisiones.pos != -1)
        {
            miDecision.text = decisionesTexto[lasDecisiones.pos].sentences[misCoords.decisionId];
            suDecision.text = decisionesTexto[lasDecisiones.pos].sentences[susCoords.decisionId];
        }
        
    }
}
