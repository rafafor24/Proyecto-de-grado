using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject prefab;

    public Stations stations;

    private float dist = 2.3f;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            GameObject newObject= Instantiate(prefab, new Vector3(stations.x[i]*dist , stations.y[(i)]*dist, 0), Quaternion.identity);
            newObject.GetComponentInChildren<TextMesh>().text = stations.stationsNames[i];
        }
    }    
}
