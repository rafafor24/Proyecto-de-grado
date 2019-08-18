using UnityEngine;

[CreateAssetMenu(fileName= "Stations", menuName = "Stations")]
public class Stations : ScriptableObject
{
    public int[] x;
    public int[] y;
    public string[] stationsNames;
}
