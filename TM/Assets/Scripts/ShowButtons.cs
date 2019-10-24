using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowButtons : MonoBehaviour
{
    public GameObject buttons;

    public TextMeshProUGUI countdown;

    public GameObject titulo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowButtonPanel());        
    }

    IEnumerator ShowButtonPanel()
    {
        countdown.gameObject.SetActive(true);
        countdown.text = "3";
        yield return new WaitForSeconds(1);
        countdown.text = "2";
        yield return new WaitForSeconds(1);
        countdown.text = "1";
        yield return new WaitForSeconds(1);
        countdown.gameObject.SetActive(false);
        titulo.SetActive(false);
        buttons.SetActive(true);
        buttons.GetComponent<TextoDecision>().StartCountDown();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
