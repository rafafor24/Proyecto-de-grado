using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class controlTiempo : MonoBehaviour
{

    public Slider sliderTiempo;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI timeActual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeMaxTime(int time)
    {
        maxTime.SetText(time.ToString());
    }

    void ChangeTimeActual(int time)
    {
        timeActual.SetText(time.ToString());
    }
}
