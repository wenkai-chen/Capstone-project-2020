using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measurement : GenericBoard
{
    
    public static Vector2 GlobalCOP;
    public static Vector2 GlobalCOPStorage;
    public static Vector2 GlobalVelocity;
    public static GenericBoard Board0;

    public static  GenericBoard Board1;

    public static GenericBoard Board2;

    public  static GenericBoard Board3;

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
    public static bool WhetherStart = false;
    public static bool WhetherCalibriate = false;
    private int i;
    public string Username;
    public bool testmode=false;

    // Start is called before the first frame update
    void Start()
    {
        Time.fixedDeltaTime = PlayerPrefs.GetFloat("DeltaTime");
        Board0 = gameObject.AddComponent<GenericBoard>();
        Board1 = gameObject.AddComponent<GenericBoard>();
        Board2 = gameObject.AddComponent<GenericBoard>();
        Board3 = gameObject.AddComponent<GenericBoard>();
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
        Board0.RotationAngle = PlayerPrefs.GetFloat("Board0_angle");
        Board1.RotationAngle = PlayerPrefs.GetFloat("Board1_angle");
        Board2.RotationAngle = 0;
        Board3.RotationAngle = 0;
        Board0.Board_length = PlayerPrefs.GetFloat("Board_Length");
        Board0.Board_width = PlayerPrefs.GetFloat("Board_Width");
        Board1.Board_length = PlayerPrefs.GetFloat("Board_Length");
        Board1.Board_width = PlayerPrefs.GetFloat("Board_Width");
        Board2.Board_length = PlayerPrefs.GetFloat("Board_Length");
        Board2.Board_width = PlayerPrefs.GetFloat("Board_Width");
        Board3.Board_length = PlayerPrefs.GetFloat("Board_Length");
        Board3.Board_width = PlayerPrefs.GetFloat("Board_Width");
        Board0.BoardPosition.Set(0f, 0f);
        Board1.BoardPosition.Set(PlayerPrefs.GetFloat("Board1_x"), PlayerPrefs.GetFloat("Board1_y"));
        Board0.Board_Force_error_storage.Set(0.0f, 0.0f, 0.0f, 0.0f);
        Board1.Board_Force_error_storage.Set(0.0f, 0.0f, 0.0f, 0.0f);




        foreach (GenericBoard item in Boards)
        {
            // Calculate Initial Sensor Position
            

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
    void FixedUpdate()
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
        
        if (testmode == false)
        {
            DeviceNumbers = Wii.GetRemoteCount();
            foreach (GenericBoard item in Boards)

            {
                item.Board_Force = Wiiboard.Board_ForceRead(item.BoardNumber);
                item.CalibratedForce = EliminateError(item);
                item.Board_Totalforce = item.CalculateTotalForce();
            }
            Debug.Log(Board0.Board_Force);
            Debug.Log("This is Board0.Board_Force");
            Debug.Log(Board0.CalibratedForce);
            Debug.Log("This is Board0.CalibratedForce");
            Debug.Log(Board0.Board_Totalforce);
            Debug.Log("This is Board0.Board_Totalforce");
            GlobalTotalForce = CalculateGlobalTotalForce();
            COPRatioCalculationInGlobalCoordinate();
            GlobalVelocity = VelocityCalculationInGlobalCoordinate();
        }
        
        if (testmode == true)
        {
            
            Testdataset();
            foreach (GenericBoard item in Boards)
            {
                item.CalibratedForce=EliminateError(item);
                item.Board_Totalforce=item.CalculateTotalForce();
            }
            GlobalTotalForce = CalculateGlobalTotalForce();
            COPRatioCalculationInGlobalCoordinate();        
            GlobalVelocity=VelocityCalculationInGlobalCoordinate();

        }


    }



    //Fuction Defination
    public static void COPRatioCalculationInGlobalCoordinate()
    {
        GlobalCOPStorage = GlobalCOP;
        float tempx;
        float tempy;
        if (DeviceNumbers == 1)
        {
            

            tempx = (Board0.SensorXinGlobal.x * Board0.Board_Force.x + Board0.SensorYinGlobal.x * Board0.Board_Force.y + Board0.SensorZinGlobal.x * Board0.Board_Force.z + Board0.SensorWinGlobal.x * Board0.Board_Force.w) / GlobalTotalForce;
            tempy = (Board0.SensorXinGlobal.y * Board0.Board_Force.x + Board0.SensorYinGlobal.y * Board0.Board_Force.y + Board0.SensorZinGlobal.y * Board0.Board_Force.z + Board0.SensorWinGlobal.y * Board0.Board_Force.w) / GlobalTotalForce;
            GlobalCOP.Set(tempx, tempy);
        }
        if (DeviceNumbers == 2)
        {

            tempx = (Board0.SensorXinGlobal.x * Board0.CalibratedForce.x + Board0.SensorYinGlobal.x * Board0.CalibratedForce.y + Board0.SensorZinGlobal.x * Board0.CalibratedForce.z + Board0.SensorWinGlobal.x * Board0.CalibratedForce.w
                + Board1.SensorXinGlobal.x * Board1.CalibratedForce.x + Board1.SensorYinGlobal.x * Board1.CalibratedForce.y + Board1.SensorZinGlobal.x * Board1.CalibratedForce.z + Board1.SensorWinGlobal.x * Board1.CalibratedForce.w) 
                / GlobalTotalForce;
            tempy = (Board0.SensorXinGlobal.y * Board0.CalibratedForce.x + Board0.SensorYinGlobal.y * Board0.CalibratedForce.y + Board0.SensorZinGlobal.y * Board0.CalibratedForce.z + Board0.SensorWinGlobal.y * Board0.CalibratedForce.w
                + Board1.SensorXinGlobal.y * Board1.CalibratedForce.x + Board1.SensorYinGlobal.y * Board1.CalibratedForce.y + Board1.SensorZinGlobal.y * Board1.CalibratedForce.z + Board1.SensorWinGlobal.y * Board1.CalibratedForce.w
                ) / GlobalTotalForce;
            GlobalCOP.Set(tempx, tempy);
        }

        
    }
    public static Vector2 VelocityCalculationInGlobalCoordinate()
    {
        Velocityx=((GlobalCOP.x- GlobalCOPStorage.x)/ updatetime)/1000;
        Velocityy= ((GlobalCOP.y - GlobalCOPStorage.y) / updatetime)/1000;
        GlobalVelocity.Set(Velocityx, Velocityy);
        return GlobalVelocity;
    }
    public static void Testdataset()
    {
        DeviceNumbers = 1;
        // These are used for test
        Board0.Board_Force.x = 81f;
        Board0.Board_Force.y = 81f;
        Board0.Board_Force.z = 81f;
        Board0.Board_Force.w = 81f;
        
        Board1.Board_Force.x = 81f;
        Board1.Board_Force.y = 81f;
        Board1.Board_Force.z = 81f;
        Board1.Board_Force.w = 81f;
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

