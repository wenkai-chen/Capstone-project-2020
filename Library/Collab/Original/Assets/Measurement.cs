using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measurement : MonoBehaviour
{
    public static Vector2 GlobalCOP=new Vector2(0,0);
    public static Vector2 GlobalCOPStorage;
    public static Vector2 GlobalVelocity;
    public static GenericBoard Board0 = new GenericBoard();
    public static GenericBoard Board1 = new GenericBoard();
    public static GenericBoard Board2 = new GenericBoard();
    public static GenericBoard Board3 = new GenericBoard();
    List<GenericBoard> Boards=new List<GenericBoard>();
    public static float Globalx =new float();
    public static float Globaly = new float();
    public static float GlobalTotalForce;
    public static float Velocityx;
    public static float Velocityy;

    // Instance All Boards
    public static float updatetime;
    public static int DeviceNumbers;
    public static Vector4 zerovector = new Vector4(0, 0, 0, 0);
    public static bool WhetherStart = true;
    public static bool WhetherCalibriate = false;
    private int i;
    public string Username;
    public bool testmode=true;

    // Start is called before the first frame update
    void Start()
    {
        Wii.StartSearch();
        Wii.WakeUp();
        Boards.Add(Board0);
        Boards.Add(Board1);
        Boards.Add(Board2);
        Boards.Add(Board3);
        Board0.BoardNumber = 0;
        Board1.BoardNumber = 1;
        Board2.BoardNumber = 2;
        Board3.BoardNumber = 3;
        updatetime=0.02F;
        Board0.RotationAngle = 90;
        Board1.RotationAngle = 90;
        Board2.RotationAngle = 0;
        Board3.RotationAngle = 0;
        Board0.Board_length = 400f;
        Board0.Board_width = 200f;
        Board1.Board_length = 400f;
        Board1.Board_width = 200f;
        Board2.Board_length = 400f;
        Board2.Board_width = 200f;
        Board3.Board_length = 400f;
        Board3.Board_width = 200f;
        Board0.BoardPosition.Set(0f, 0f);
        Board1.BoardPosition.Set(500f, 0f);




        foreach (GenericBoard item in Boards)
        {
            // Calculate Initial Sensor Position
            item.RotationMatrix = new float[,] { { Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle), -Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) }, { Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle), Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) } };

            item.SensorXRelative.x = Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length - Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;
            item.SensorXRelative.y = Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length + Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;

            item.SensorYRelative.x = -Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length - Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;
            item.SensorYRelative.y = -Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length + Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;

            item.SensorZRelative.x = Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length + Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;
            item.SensorZRelative.y = Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length - Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;

            item.SensorWRelative.x =-Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length + Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;
            item.SensorWRelative.y =-Mathf.Sin(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_length - Mathf.Cos(Mathf.Deg2Rad * item.RotationAngle) * 1 / 2 * item.Board_width;

            item.SensorXinGlobal = item.BoardPosition + item.SensorXRelative;
            item.SensorYinGlobal = item.BoardPosition + item.SensorYRelative;
            item.SensorZinGlobal = item.BoardPosition + item.SensorZRelative;
            item.SensorWinGlobal = item.BoardPosition + item.SensorWRelative;
            
        }

    }
    void Awake()
    {
        Debug.Log("Awake called.");
        Debug.Log("Awake called.");
        Wii.StartSearch();
        Wii.WakeUp();

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Test Mode Begins");
            testmode = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("Test Mode Stops");
            testmode = false;
        }
        /*
        if (testmode == false)
        {
            DeviceNumbers = Wii.GetRemoteCount();
            foreach (GenericBoard item in Boards)
            {
                item.Board_Force = Wiiboard.Board_ForceRead(item.BoardNumber);
                item.EliminateError();
                item.CalculateTotalForce();
                item.COPRatioCalculationInLocalCoordinate();
                item.COPRatioRangeCheck();
            }
            COPRatioCalculationInGlobalCoordinate();
            VelocityCalculationInGlobalCoordinate();
        }
        */
        if (testmode == true)
        {
            
            Testdataset();
            foreach (GenericBoard item in Boards)
            {
                item.EliminateError();
                item.Board_Totalforce=item.CalculateTotalForce();
                item.Board_COP=item.COPRatioCalculationInLocalCoordinate();
            }
            GlobalTotalForce = CalculateGlobalTotalForce();
            GlobalCOP = COPRatioCalculationInGlobalCoordinate();        
            GlobalVelocity=VelocityCalculationInGlobalCoordinate();

        }


    }



    //Fuction Defination
    public static Vector2 COPRatioCalculationInGlobalCoordinate()
    {
        GlobalCOPStorage = GlobalCOP;
        if (DeviceNumbers == 1)
        {
            float tempx;
            float tempy;
            tempx = (Board0.SensorXinGlobal.x * Board0.Board_Force.x + Board0.SensorYinGlobal.x * Board0.Board_Force.y + Board0.SensorZinGlobal.x * Board0.Board_Force.z + Board0.SensorWinGlobal.x * Board0.Board_Force.w) / GlobalTotalForce;
            tempy = (Board0.SensorXinGlobal.y * Board0.Board_Force.x + Board0.SensorYinGlobal.y * Board0.Board_Force.y + Board0.SensorZinGlobal.y * Board0.Board_Force.z + Board0.SensorWinGlobal.y * Board0.Board_Force.w) / GlobalTotalForce;         
            GlobalCOP.Set(tempx, tempy);
        }
        if (DeviceNumbers == 2)
        {
            float tempx;
            float tempy;
            tempx = (Board0.SensorXinGlobal.x * Board0.Board_Force.x + Board0.SensorYinGlobal.x * Board0.Board_Force.y + Board0.SensorZinGlobal.x * Board0.Board_Force.z + Board0.SensorWinGlobal.x * Board0.Board_Force.w
                   + Board1.SensorXinGlobal.x * Board1.Board_Force.x + Board1.SensorYinGlobal.x * Board1.Board_Force.y + Board1.SensorZinGlobal.x * Board1.Board_Force.z + Board1.SensorWinGlobal.x * Board1.Board_Force.w) 
                   / GlobalTotalForce;
            tempy = (Board0.SensorXinGlobal.y * Board0.Board_Force.x + Board0.SensorYinGlobal.y * Board0.Board_Force.y + Board0.SensorZinGlobal.y * Board0.Board_Force.z + Board0.SensorWinGlobal.y * Board0.Board_Force.w
                   + Board1.SensorXinGlobal.y * Board1.Board_Force.x + Board1.SensorYinGlobal.y * Board1.Board_Force.y + Board1.SensorZinGlobal.y * Board1.Board_Force.z + Board1.SensorWinGlobal.y * Board1.Board_Force.w) 
                   / GlobalTotalForce;
            GlobalCOP.Set(tempx, tempy);
        }
        
        return GlobalCOP;
    }
    public static Vector2 VelocityCalculationInGlobalCoordinate()
    {
        Velocityx=(GlobalCOP.x- GlobalCOPStorage.x)/ updatetime;
        Velocityy= (GlobalCOP.y - GlobalCOPStorage.y) / updatetime;
        GlobalVelocity.Set(Velocityx, Velocityy);
        return GlobalVelocity;
    }
    public static void Testdataset()
    {
        DeviceNumbers = 2;
        // These are used for test
        Board0.Board_Force.x = 21f;
        Board0.Board_Force.y = 21f;
        Board0.Board_Force.z = 21f;
        Board0.Board_Force.w = 21f;
        Board0.Board_Force_error_storage.Set(1f,1f,1f,1f);
        Board1.Board_Force.x = 1f;
        Board1.Board_Force.y = 1f;
        Board1.Board_Force.z = 1f;
        Board1.Board_Force.w = 1f;
        Board1.Board_Force_error_storage.Set(1f, 1f, 1f, 1f);
    }
    public float CalculateGlobalTotalForce()
    {
        if (DeviceNumbers == 1)
        {
            GlobalTotalForce = Board0.Board_Totalforce;
        }
        if (DeviceNumbers == 2)
        {
            GlobalTotalForce = Board0.Board_Totalforce+ Board1.Board_Totalforce;
        }
        if (DeviceNumbers == 3)
        {
            GlobalTotalForce = Board0.Board_Totalforce + Board1.Board_Totalforce + Board2.Board_Totalforce;
        }
        if (DeviceNumbers == 4)
        {
            GlobalTotalForce = Board0.Board_Totalforce + Board1.Board_Totalforce + Board2.Board_Totalforce + Board3.Board_Totalforce;
        }
        return GlobalTotalForce;
    }

}

