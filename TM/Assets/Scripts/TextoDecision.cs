using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TextoDecision : MonoBehaviour
{
    public Dialogue decisiones;

    public TextMeshProUGUI des1, des2, countdown;

    public GameObject desFinal;

    public int timeLimit = 20;

    private bool decidido;

    private CoordsPlayer coords;

    private MenuLogic ml;
    // Start is called before the first frame update
    void Start()
    {
        ml = GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>();
        coords = ml.getCoords();
        decidido = false;
        des1.text = decisiones.sentences[0];
        des2.text = decisiones.sentences[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Des1()
    {
        decidido = true;
        coords.decisionId = 0;
        ml.updateCoords(coords);
        PlayerPrefs.SetInt("decision", 1);
        gameObject.transform.position = new Vector3(0, -200, 0);
        desFinal.SetActive(true);
        desFinal.GetComponent<TextMeshProUGUI>().text += des1.text;
        StartCoroutine(ShowFinalDes());
    }
    public void Des2()
    {
        decidido = true;
        coords.decisionId = 1;
        ml.updateCoords(coords);
        PlayerPrefs.SetInt("decision", 2);
        gameObject.transform.position = new Vector3(0, -200, 0);
        desFinal.SetActive(true);
        desFinal.GetComponent<TextMeshProUGUI>().text += des2.text;
        StartCoroutine(ShowFinalDes());
    }

    IEnumerator ShowFinalDes()
    {
        yield return new WaitForSeconds(3);
        GameObject.Find("PhotonDontDestroy").GetComponent<MenuLogic>().joinOrCreateRoomAgain();
        PhotonNetwork.LoadLevel("Map");
    }

    public IEnumerator CountDown()
    {
        int i = timeLimit;
        while(i!=0&&!decidido)
        {
            countdown.text = "Tiempo Restante: "+i--;
            yield return new WaitForSeconds(1);
        }

        if (i == 0)
        {
            Des1();
        }
    }

    public void StartCountDown()
    {
        StartCoroutine(CountDown());
    }
}
