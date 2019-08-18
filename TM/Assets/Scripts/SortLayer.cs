using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    { 
    
        GetComponent<Renderer>().sortingLayerID = transform.parent.GetComponent<Renderer>().sortingLayerID;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
