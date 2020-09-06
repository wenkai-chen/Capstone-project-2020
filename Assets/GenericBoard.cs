using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericBoard : MonoBehaviour
{

    public static float[] Board_length = new float[4];
    public static float[] Board_width = new float[4];
    //Board dimensions
    public static float[] Board_x = new float[4];
    public static float[] Board_y = new float[4];
    // Board center position in coordinate 0 (Global coordinate)
    public static Vector4[] Board_Force = new Vector4[4];
    // x is top right , y is top left  z is bottom right, w is bottom left. units in kg
    public static Vector4[] Board_Forcestorage = new Vector4[4];
    // use this storage value to calibrition
    public static Vector4[] Board_Force_error_storage = new Vector4[4];
    // use this value for calibration;
    public static float Board_updatetime;
    // update time can be only 0.1s，0.05s，0.02s, for all boards.
    public static float[] Board_Totalforce = new float[4];
    // units in kg
    public static Vector4[] Board_Force_Calibrition_Storage = new Vector4[4];
    public static float[,] RotationMatrixBoard0 = new float[2, 2];
    public static float[,] RotationMatrixBoard1 = new float[2, 2];
    public static float[,] RotationMatrixBoard2 = new float[2, 2];
    public static float[,] RotationMatrixBoard3 = new float[2, 2];
    public static float[] RotationAngle= new float[4];

    // For Rotation Calculation
    // if calibration finished
    public static Vector2[] Board_COPratio = new Vector2[4];
    public static Vector2[] Board_COPratioStorage = new Vector2[4];
    public static Vector2[] Board_COP = new Vector2[4];
    public static Vector2[] Board_COPStorage = new Vector2[4];
    // COPratio at its own coordinate, ratio between -1 to +1;
    public static Vector2[] Velocity = new Vector2[4];
    // COP velocity mm/sec
    public static int DeviceNumbers;
    public static Vector4 zerovector = new Vector4(0, 0, 0, 0);
    public static bool WhetherStart = false;
    public static bool WhetherCalibriate = false;
    private int i;
    public static string Username;


    // Start is called before the first frame update， Initailize
    void Start()
    {
        Board_Initialize();
    }
    // Update is called once per frame

    private void Update()
    {


    }
    void FixedUpdate()
    {
        for (i = 0; i >= 3; i = i + 1)
        {
            EliminateError(i);
            ForceRangeCheck(i);
            COPRatioCalculationInLocalCoordinate(i);
            COPRatioCalculationInGlobalCoordinate();
            COPRatioRangeCheck(i);
            ConvertCOPRatioToLength(i);
            VelocityCalculation(i);

        }

    }
    public static void COPRatioCalculationInLocalCoordinate(int number)
    {
        // TobeFinished
    }
    public static void COPRatioCalculationInGlobalCoordinate()
    {
        // TobeFinished
    }
    public static void ForceRangeCheck(int number)
    {
        // TobeFinished
    }
    public static void EliminateError(int number)
    {
        // TobeFinished
    }
    public static void ConvertCOPRatioToLength(int number)
    {
        Board_COPStorage[number].x = Board_COPratioStorage[number].x * Board_length[number] / 2;
        Board_COPStorage[number].y = Board_COPratioStorage[number].y * Board_length[number] / 2;
        Board_COP[number].x = Board_COPratio[number].x * Board_length[number] / 2;
        Board_COP[number].y = Board_COPratio[number].y * Board_length[number] / 2;
    }
    public static void VelocityCalculation(int number)
    {
        Velocity[number].x = (Board_COP[number].x - Board_COPStorage[number].x) / Board_updatetime;
        Velocity[number].y = (Board_COP[number].y - Board_COPStorage[number].y) / Board_updatetime;
    }
    public static void COPRatioRangeCheck(int number)
    {
        if (Board_COPratio[number].x > 1)
        {
            Board_COPratio[number].x = 1;
        }
        if (Board_COPratio[number].y > 1)
        {
            Board_COPratio[number].y = 1;
        }
        if (Board_COPratio[number].x < -1)
        {
            Board_COPratio[number].x = -1;
        }
        if (Board_COPratio[number].y < -1)
        {
            Board_COPratio[number].y = -1;
        }
    }
    private static void Board_Initialize()
    {
        // To Initialize Values
        Board_length[0] = 438.0f;
        Board_width[0] = 238.0f;
        Board_length[1] = 438.0f;
        Board_width[1] = 238.0f;
        Board_length[2] = 438.0f;
        Board_width[2] = 238.0f;
        Board_length[3] = 438.0f;
        Board_width[3] = 238.0f;
        Board_x[0] = 0.0f;
        Board_y[0] = 0.0f;
        Board_x[1] = 260.0f;
        Board_y[1] = 0.0f;
        Board_x[2] = 520.0f;
        Board_y[2] = 0.0f;
        Board_x[3] = 780.0f;
        Board_y[3] = 0.0f;
        // Initialize Board Position
        Board_updatetime = 0.02f;
        Board_Force[0].Set(0, 0, 0, 0);
        Board_Force[1].Set(0, 0, 0, 0);
        Board_Force[2].Set(0, 0, 0, 0);
        Board_Force[3].Set(0, 0, 0, 0);
        Board_Forcestorage[0].Set(0, 0, 0, 0);
        Board_Forcestorage[1].Set(0, 0, 0, 0);
        Board_Forcestorage[2].Set(0, 0, 0, 0);
        Board_Forcestorage[3].Set(0, 0, 0, 0);
        Board_Force_error_storage[0].Set(0, 0, 0, 0);
        Board_Force_error_storage[1].Set(0, 0, 0, 0);
        Board_Force_error_storage[2].Set(0, 0, 0, 0);
        Board_Force_error_storage[3].Set(0, 0, 0, 0);
        // Empty All Force
        RotationMatrixBoard0 =new float [,]{ {1,2},{3,4} };
        RotationMatrixBoard1 =new float [,]{ {1,2},{3,4} };
        RotationMatrixBoard2 =new float [,]{ {1,2},{3,4} };
        RotationMatrixBoard3 =new float [,]{ {1,2},{3,4} };
        // Initialize Rotation
    }
    


}

