using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowButtons : MonoBehaviour
{
    public GameObject buttons;

    public GameObject countdown;

    public GameObject titulo;

    public GameObject contexto;

    public Dialogue instrucciones;

    public GameObject butInstrucciones;

    public GameObject saltarI;

    private int tiempoLeer = 20;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowButtonPanel());        
    }

    public void saltar()
    {
        tiempoLeer = 0;
    }
    IEnumerator ShowButtonPanel()
    {
        contexto.GetComponentInChildren<TextMeshProUGUI>().text = instrucciones.sentences[0] +"\n"+ instrucciones.sentences[1];
        while(tiempoLeer>0)
        {
            countdown.GetComponentInChildren<TextMeshProUGUI>().text = "Podrás decidir en: "+ tiempoLeer.ToString()+" segundos.";
            tiempoLeer--;
            yield return new WaitForSeconds(1);
        }
        butInstrucciones.GetComponent<RectTransform>().anchoredPosition= new Vector3(400f, 62.105f, 0f);
        saltarI.SetActive(false);
        contexto.SetActive(false);
        countdown.gameObject.SetActive(false);
        titulo.SetActive(false);
        buttons.SetActive(true);
        buttons.GetComponent<TextoDecision>().StartCountDown();
    }
}
