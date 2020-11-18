using System.Collections;

using UnityEngine;
using TMPro;

public class DoubleBoardTest : Measurement
{
    public GameObject DoubleBoard_COPy;
    public GameObject DoubleBoard_COPx;
    public GameObject DoubleBoard_COP_velocityx;
    public GameObject DoubleBoard_COP_velocityy;
    public GameObject DoubleBoard_COP_TotalForce;
    public GameObject DoubleBoard_Device_Number;
    // Start is called before the first frame update
    // Start is called before the first frame update
    public static bool DoubleBoard_Startstatus;
    void Start()
    {
        DoubleBoard_Startstatus = true;
        DoubleBoard_COPx = GameObject.Find("Main Camera/Canvas/Data and Text/Data/DoubleBoardCOPXdata");
        DoubleBoard_COPy = GameObject.Find("Main Camera/Canvas/Data and Text/Data/DoubleBoardCOPYdata");
        DoubleBoard_COP_velocityx = GameObject.Find("Main Camera/Canvas/Data and Text/Data/VelocityXData");
        DoubleBoard_COP_velocityy = GameObject.Find("Main Camera/Canvas/Data and Text/Data/VelocityYData");
        DoubleBoard_COP_TotalForce = GameObject.Find("Main Camera/Canvas/Data and Text/Data/ForceData");
        DoubleBoard_Device_Number = GameObject.Find("Main Camera/Canvas/Data and Text/Data/DeviceNumberData");
    }

    // Update is called once per frame
    void Update()
    {
        DoubleBoard_Device_Number.GetComponent<TMP_Text>().text = Measurement.DeviceNumbers.ToString(); 
    }
    void FixedUpdate()
    {
        DoubleBoard_Device_Number.GetComponent<TMP_Text>().text = DeviceNumbers.ToString();

        if (WhetherStart == true)
        {
            DoubleBoard_COPy.GetComponent<TMP_Text>().text = GlobalCOP.y.ToString("0.00");
            DoubleBoard_COPx.GetComponent<TMP_Text>().text = GlobalCOP.x.ToString("0.00");
            DoubleBoard_COP_velocityx.GetComponent<TMP_Text>().text = GlobalVelocity.x.ToString("0.00");
            DoubleBoard_COP_velocityy.GetComponent<TMP_Text>().text = GlobalVelocity.y.ToString("0.00");
            DoubleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = GlobalTotalForce.ToString("0.00");
        }
        else if (WhetherStart == false)
        {
            DoubleBoard_COPy.GetComponent<TMP_Text>().text = 0.ToString("0.0");
            DoubleBoard_COPx.GetComponent<TMP_Text>().text = 0.ToString("0.0");
            DoubleBoard_COP_velocityx.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            DoubleBoard_COP_velocityy.GetComponent<TMP_Text>().text = 999.ToString("0.0");
            DoubleBoard_COP_TotalForce.GetComponent<TMP_Text>().text = 999.ToString("0.0");
        }

    }
}
