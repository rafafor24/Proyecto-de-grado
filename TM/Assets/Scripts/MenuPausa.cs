using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject menupausa;
    private bool enable;   

    public void switchViewMenu()
    {
        if (enable)
        {
            menupausa.SetActive(false);
            enable = false;
        }
        else
        {
            menupausa.SetActive(true);
            enable = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        enable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switchViewMenu();
        }
    }
}
