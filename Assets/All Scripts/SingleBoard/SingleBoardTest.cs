using System.Collections;

using UnityEngine;
using TMPro;

public class SingleBoardTest : Measurement
{
    public GameObject SingleBoard_COPy;
    public GameObject SingleBoard_COPx;
    public GameObject SingleBoard_COP_velocityx;
    public GameObject SingleBoard_COP_velocityy;
    public GameObject SingleBoard_COP_TotalForce;
    public GameObject SingleBoard_Device_Number;
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
        SingleBoard_Device_Number= GameObject.Find("Main Camera/Canvas/Data and Text/Data/DeviceNumberData");
    }
    void Awake()
    {

        Debug.Log("Awake called.");
        Wii.StartSearch();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        SingleBoard_Device_Number.GetComponent<TMP_Text>().text = DeviceNumbers.ToString();

        if (WhetherStart == true)
        {
            
            SingleBoard_COPx.GetComponent<TMP_Text>().text = GlobalCOPStorage.x.ToString("0.00");
            SingleBoard_COPy.GetComponent<TMP_Text>().text = GlobalCOPStorage.y.ToString("0.00");
            SingleBoard_COP_velocityx.GetComponent<TMP_Text>().text = GlobalVelocity.x.ToString("0.00");
            SingleBoard_COP_velocityy.GetComponent<TMP_Text>().text = GlobalVelocity.y.ToString("0.00");
            SingleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = GlobalTotalForce.ToString("0.00");
        }
        else if (WhetherStart == false)
        {
            SingleBoard_COPy.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            SingleBoard_COPx.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            SingleBoard_COP_velocityx.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            SingleBoard_COP_velocityy.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            SingleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = 999.ToString("0.0");
        }
        
    }

}


