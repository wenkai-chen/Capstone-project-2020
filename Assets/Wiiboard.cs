using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiiboard : GenericBoard
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        Debug.Log("Awake called.");
        WaketheBoard();

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        // Only Get Force Data and Device Number as Original Data
    }
    public void WaketheBoard()
    {
        Debug.Log("Awake called.");
        Wii.StartSearch();
        Wii.WakeUp();
        
    }
    public static int GetDeviceNumbers()
    {
        return Wii.GetRemoteCount();
    }
    public  static Vector4 Board_ForceRead(int number)
    {
        return Wii.GetBalanceBoard(number);
    }
    public static Vector4 RecordSensorError(int number)
    {
        Debug.Log("RecordSensorError is done");
        return Wii.GetBalanceBoard(number);
        
        // TobeFinished
    }
}
