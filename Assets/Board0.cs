using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board0 : MonoBehaviour
{
 
    public static float[] Board0_length = new float[4];
    public static float[] Board0_width  = new float[4];
    //Board dimensions
    public static float[] Board0_x = new float[4];
    public static float[] Board0_y = new float[4];
    // Board center position in coordinate 0 (Global coordinate)
    public static Vector4[] Board0_sensor = new Vector4 [4];
    // x is top right , y is top left  z is bottom right, w is bottom left. units in kg
    public static Vector4[] Board0_sensorstorage = new Vector4[4];
    // use this storage value to calibrition
    public Vector4[] Board0_sensor_error_storage = new Vector4[4];
    // use this value for calibration;
    public float Board0_updatetime;
    // update time can be only 0.1s，0.05s，0.02s, for all boards.
    public static float[] Board0_Totalforce = new float[4];
    // units in kg
    public bool[] Board0_calibrationstate=new bool[4];
    // if calibration finished
    public static Vector2[] Board0_COPratio=new Vector2 [4];
    public static Vector2[] Board0_COPratioStorage = new Vector2[4];
    public static Vector2[] Board0_COP = new Vector2[4];
    public static Vector2[] Board0_COPStorage = new Vector2[4];
    // COPratio at its own coordinate, ratio between -1 to +1;
    public static Vector2[] Velocity= new Vector2[4];
    // COP velocity mm/sec
    public static int DeviceNumbers;
    public Vector4 zerovector = new Vector4(0,0,0,0);

    
    



    // Start is called before the first frame update， Initailize
    void Start()
    {
        Board0_Initialize();
    }
    // Update is called once per frame
    void Awake()
    {

        Debug.Log("Awake called.");
        Wii.StartSearch();

    }
    private void Update()
    {
        
    }
    void FixedUpdate()
    {
        Wii.WakeUp();
        Wii.StartSearch();
        Board0_Forceupdate(0);
        Board0_COPratioupdate(0);
        Board0_COPupdate(0);
        Board0_Velocityupdate(0);
        Board0_Forceupdate(1);
        Board0_COPratioupdate(1);
        Board0_COPupdate(1);
        Board0_Velocityupdate(1);
        DeviceNumbers = Wii.GetRemoteCount();
        // Update all forces；
        // Update COP ratio;
        // Update COP location in its own coordinate;
        // Update COP Velocity X and Y;
    }
    private void Board0_Forceupdate(int number)
    {
        // Get Force Calibriated/ Not Calibriated
        Board0_sensorstorage[number] = Board0_sensor[number];
        Board0_sensor[number] = Wii.GetBalanceBoard(number);
        Board0_Totalforce[number] = Board0_sensor[number].x + Board0_sensor[number].y + Board0_sensor[number].z + Board0_sensor[number].w;
    }
    private void Board0_COPratioupdate(int number)
    {
        Board0_COPratioStorage[number] = Board0_COPratio[number];
        Board0_COPratio[number] =Wii.GetCenterOfBalance(number);
        if (Board0_COPratio[number].x > 1)
        {
            Board0_COPratio[number].x = 1;
        }
        if (Board0_COPratio[number].y > 1)
        {
            Board0_COPratio[number].y = 1;
        }
        if (Board0_COPratio[number].x <- 1)
        {
            Board0_COPratio[number].x = -1;
        }
        if (Board0_COPratio[number].y <- 1)
        {
            Board0_COPratio[number].y = -1;
        }
    }
    private void Board0_COPupdate(int number)
    {
        Board0_COPStorage[number].x = Board0_COPratioStorage[number].x * Board0_length[number] / 2;
        Board0_COPStorage[number].y = Board0_COPratioStorage[number].y * Board0_length[number] / 2;
        Board0_COP[number].x = Board0_COPratio[number].x * Board0_length[number] / 2;
        Board0_COP[number].y = Board0_COPratio[number].y * Board0_length[number] / 2;
    }
    private void Board0_Velocityupdate(int number)
    {
        Velocity[number].x = (Board0_COP[number].x - Board0_COPStorage[number].x)/Board0_updatetime;
        Velocity[number].y = (Board0_COP[number].y - Board0_COPStorage[number].y) / Board0_updatetime;
    }
    private void Board0_Initialize()
    {
        // To Initialize Values
        Board0_length[0] = 438.0f;
        Board0_width[0] = 238.0f;
        Board0_length[1] = 438.0f;
        Board0_width[1] = 238.0f;
        Board0_x[0] = 0.0f;
        Board0_y[0] = 0.0f;
        Board0_x[1] = 260.0f;
        Board0_y[1] = 0.0f;
        Board0_updatetime = 0.02f;
        Board0_calibrationstate[0] = false;
        Board0_calibrationstate[1] = false;
        Board0_sensor[0].Set(0, 0, 0, 0);
        Board0_sensor[1].Set(0, 0, 0, 0);
        Board0_sensorstorage[0].Set(0,0,0,0);
        Board0_sensorstorage[1].Set(0,0,0,0);
        Board0_sensor_error_storage[0].Set(0,0,0,0);
        Board0_sensor_error_storage[1].Set(0,0,0,0);




    }
    public void GetDeviceNumbers()
    {
        DeviceNumbers = Wii.GetRemoteCount();
    }
    public void Calibration(int number)
    {
        Board0_sensor_error_storage[number] = Board0_sensor[number];
    }


}

