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
        GetDeviceNumbers();
        Board_Forceupdate(0);
        Board_Forceupdate(1);
        Board_Forceupdate(2);
        Board_Forceupdate(3);
        // Only Get Force Data and Device Number as Original Data
    }
    public static void WaketheBoard()
    {
        Debug.Log("Awake called.");
        Wii.StartSearch();
        Wii.WakeUp();
        
    }
    public static void GetDeviceNumbers()
    {
        DeviceNumbers = Wii.GetRemoteCount();
    }
    public static void Board_Forceupdate(int number)
    {
        // Get Force Calibriated/ Not Calibriated
        Board_Forcestorage[number] = Board_Force[number];
        Board_Force[number] = Wii.GetBalanceBoard(number);
        // You can replace Wii.GetBalanceBoard(number) with your original force data(Vector4)
        // Minus Error
        Board_Totalforce[number] = Board_Force[number].x + Board_Force[number].y + Board_Force[number].z + Board_Force[number].w;
    }
    public static void Calibrition()
    {
        Debug.Log("Calibrition Succeed");
        // TobeFinished
    }
}
