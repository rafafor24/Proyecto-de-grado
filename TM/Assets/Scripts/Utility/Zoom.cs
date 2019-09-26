using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public Camera laCamara;
    private void Update()
    {
        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");
        if (ScrollWheelChange != 0)
        {                                            //If the scrollwheel has changed
            float R = ScrollWheelChange * 15;                                   //The radius from current camera
            float PosX = laCamara.transform.eulerAngles.x + 90;              //Get up and down
            float PosY = -1 * (laCamara.transform.eulerAngles.y - 90);       //Get left to right
            PosX = PosX / 180 * Mathf.PI;                                       //Convert from degrees to radians
            PosY = PosY / 180 * Mathf.PI;                                       //^
            float X = R * Mathf.Sin(PosX) * Mathf.Cos(PosY);                    //Calculate new coords
            float Z = R * Mathf.Sin(PosX) * Mathf.Sin(PosY);                    //^
            float Y = R * Mathf.Cos(PosX);                                      //^
            float CamX = laCamara.transform.position.x;                      //Get current camera postition for the offset
            float CamY = laCamara.transform.position.y;                      //^
            float CamZ = laCamara.transform.position.z;                      //^
            float newZ = CamZ + Z;
            if (newZ > -3)//Limite zooms
            {
                newZ = -3;
            }
            else if (newZ < -23)
            {
                newZ = -23;
            }
            laCamara.transform.position = new Vector3(CamX + X, CamY + Y, newZ);//Move the main camera    
        }
    
    }
}
