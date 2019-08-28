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
}

