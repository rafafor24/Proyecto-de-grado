using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CoordsPlayer", menuName = "CoordsPlayer")]

public class CoordsPlayer : ScriptableObject
{
    public new string name;

    
    public int x;
    public int y;
    public int estId;
    public int decisionId;

    public Vector3 posicion;

    public CoordsPlayer(int pX,int pY, int pEstId, int pDecisionId, Vector3 pPosicion)
    {
        x = pX;
        y = pY;
        estId = pEstId;
        decisionId = pDecisionId;
        posicion = pPosicion;
    }
}

