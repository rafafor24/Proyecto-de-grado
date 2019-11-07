using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DecisionesFinales : MonoBehaviour
{
    public TextMeshProUGUI Decision1Txt;
    public TextMeshProUGUI Decision2Txt;
    public TextMeshProUGUI Decision3Txt;

    public TextMeshProUGUI Decision1pts;
    public TextMeshProUGUI Decision2pts;
    public TextMeshProUGUI Decision3pts;

    public TextMeshProUGUI PuntajeFinal;

    public DecisionesTomadas decisionesTomadas;

    public Puntajes puntajes;

    private int tiempo = 15;


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<decisionesTomadas.mias.Length;i++)
        {
            bool dec1 = decisionesTomadas.mias[i]==1;
            bool dec2 = decisionesTomadas.otro[i]==1;

            int ptj = CambiarTiempos(dec1, dec2);

            if (i==0)
            {
                if (decisionesTomadas.mias[i]==1)
                {
                    Decision1Txt.SetText("1. No te colaste");
                }
                else if (decisionesTomadas.mias[i] == 0)
                {
                    Decision1Txt.SetText("1. Te colaste");
                }
                Decision1pts.SetText("-"+ptj+" min");
                tiempo -= ptj;

            }
            else if (i == 1)
            {
                if (decisionesTomadas.mias[i] == 1)
                {
                    Decision2Txt.SetText("2. Alertaste");
                }
                else if (decisionesTomadas.mias[i] == 0)
                {
                    Decision2Txt.SetText("2. No alertaste");
                }
                Decision2pts.SetText("-" + ptj + " min");
                tiempo -= ptj;
            }
            else if (i == 2)
            {
                if (decisionesTomadas.mias[i] == 1)
                {
                    Decision3Txt.SetText("3. Ayudaste");
                    Decision3pts.SetText("-" + ptj + " min");
                    tiempo -= ptj;
                }
                else if (decisionesTomadas.mias[i] == 0)
                {
                    Decision3Txt.SetText("3. No ayudaste");
                    Decision3pts.SetText("-" + ptj + " min");
                    tiempo -= ptj;
                }
                else
                {
                    Decision3Txt.SetText("3. N/A");
                    Decision3pts.SetText("N/A");
                }
                
            }
        }
        PuntajeFinal.SetText(tiempo+" min");
    }

    public int CambiarTiempos(bool des1, bool des2)
    {
        int rpta = -1;

        if (des1 && des2)
        {
            rpta = puntajes.ambosBien;
        }
        else if (des1 && !des2)
        {
            rpta = puntajes.unoMalOtroBien;
        }
        else if (!des1 && des2)
        {
            rpta = puntajes.unoBienOtroMal;
        }
        else if (!des1 && !des2)
        {
            rpta = puntajes.ambosMal;
        }

        return rpta;
    }
}
