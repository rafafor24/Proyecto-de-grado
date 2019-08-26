using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtons : MonoBehaviour
{
    public GameObject buttons;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowButtonPanel());
        
    }

    IEnumerator ShowButtonPanel()
    {
        print(Time.time);
        yield return new WaitForSeconds(3);        
        buttons.SetActive(true);
        print(Time.time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
