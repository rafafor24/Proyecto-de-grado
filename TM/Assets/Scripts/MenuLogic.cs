﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    public GameObject connectedMenu;

    public void disableMenuUI()
    {
        connectedMenu.SetActive(false);
    }
}
