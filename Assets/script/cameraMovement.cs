using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public float mouseX;                                                                               //to make view up and down using mouse
    public static bool isInvert, FPP;
    public Camera TPPcam, FPPcam;

    void Update()
    {
        mouseX = Input.GetAxis("Mouse Y");
        if (isInvert)
        {
            transform.Rotate(-mouseX, 0, 0);
        }else
        {
            transform.Rotate(mouseX, 0, 0);
        }
       
        //for FPP or TPP
        if(FPP == true)
        {
            FPPcam.gameObject.SetActive(true);
            TPPcam.gameObject.SetActive(false);
        }
        else
        {
            FPPcam.gameObject.SetActive(false);
            TPPcam.gameObject.SetActive(true);
        }

        //Debug.Log(isInvert);    
    }
}
