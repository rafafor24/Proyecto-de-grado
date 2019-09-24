using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    
        //GetComponent<MeshRenderer>().sortingLayerID = 3;
        GetComponent<MeshRenderer>().sortingLayerName = "Estaciones";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
