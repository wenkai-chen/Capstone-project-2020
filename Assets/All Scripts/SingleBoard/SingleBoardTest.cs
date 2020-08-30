using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SingleBoardTest : MonoBehaviour
{
    public GameObject SingleBoard_COPy;
    public GameObject SingleBoard_COPx;
    public GameObject SingleBoard_COP_velocityx;
    public GameObject SingleBoard_COP_velocityy;
    public GameObject SingleBoard_COP_TotalForce;
    // Start is called before the first frame update
    public static bool Singleboard_Startstatus;
    void Start()
    {
        Singleboard_Startstatus = true;
        SingleBoard_COPy = GameObject.Find("Main Camera/Canvas/Data and Text/Data/COPYdata");
        SingleBoard_COPx = GameObject.Find("Main Camera/Canvas/Data and Text/Data/COPXdata");
        SingleBoard_COP_velocityx = GameObject.Find("Main Camera/Canvas/Data and Text/Data/VelocityXdata");
        SingleBoard_COP_velocityy = GameObject.Find("Main Camera/Canvas/Data and Text/Data/VelocityYdata");
        SingleBoard_COP_TotalForce = GameObject.Find("Main Camera/Canvas/Data and Text/Data/ForceData");
    }

    // Update is called once per frame
    void Update()
    {
        if (Singleboard_Startstatus == true)
        {
            SingleBoard_COPy.GetComponent<TMP_Text>().text = Board0.Board0_COP[0].y.ToString("0.00");
            SingleBoard_COPx.GetComponent<TMP_Text>().text = Board0.Board0_COP[0].x.ToString("0.00");
            SingleBoard_COP_velocityx.GetComponent<TMP_Text>().text = Board0.Velocity[0].x.ToString("0.00");
            SingleBoard_COP_velocityy.GetComponent<TMP_Text>().text = Board0.Velocity[0].y.ToString("0.00");
            SingleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = Board0.Board0_Totalforce[0].ToString("0.00");
        }
        else if (Singleboard_Startstatus == false)
        {
            SingleBoard_COPy.GetComponent<TMP_Text>().text = 999.ToString("0.00");
            SingleBoard_COPx.GetComponent<TMP_Text>().text = 999.ToString("0.00");
            SingleBoard_COP_velocityx.GetComponent<TMP_Text>().text = 999.ToString("0.000");
            SingleBoard_COP_velocityy.GetComponent<TMP_Text>().text = 999.ToString("0.000");
            SingleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = 999.ToString("0.000");
        }
        
    }
}
