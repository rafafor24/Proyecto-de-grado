using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextoDecision : MonoBehaviour
{
    public Dialogue decisiones;

    public TextMeshProUGUI des1, des2;
    // Start is called before the first frame update
    void Start()
    {
        des1.text = decisiones.sentences[0];
        des2.text = decisiones.sentences[1];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Des1()
    {
        des1.text = "YESSSSSSSSSSSSSSSSSSSSS";
        gameObject.transform.position = new Vector3(0, -200, 0);

    }
    public void Des2()
    {
        des2.text = "YESSSSSSSSSSSSSSSSSSSSS";

    }
}
