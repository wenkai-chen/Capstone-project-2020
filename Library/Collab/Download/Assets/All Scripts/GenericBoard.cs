using UnityEngine;


public class GenericBoard : MonoBehaviour
{
    public float Board_length;
    public float Board_width;
    //Board dimensions
    public Vector2 BoardPosition;
    // Board center position in coordinate 0 (Global coordinate)
    public Vector4 Board_Force;
    // x is top right , y is top left  z is bottom right, w is bottom left. units in kg
    public Vector4 Board_Forcestorage;
    // use this storage value to calibrition
    public Vector4 Board_Force_error_storage;
    // use this value for calibration;
    public float Board_Totalforce;
    // units in kg
    public float RotationAngle;

    // For Rotation Calculation
    // if calibration finished
    public  Vector2 Board_COPratio;
    public  Vector2 Board_COPratioStorage;
    public  Vector2 Board_COP;
    public  Vector2 Board_COPStorage;
    // COPratio at its own coordinate, ratio between -1 to +1;
    // COP velocity mm/sec
    public int BoardNumber;
    // a  special tag to distinguish board
    public Vector2 SensorXRelative;
    public Vector2 SensorYRelative;
    public Vector2 SensorZRelative;
    public Vector2 SensorWRelative;
    public Vector2 SensorXinGlobal;
    public Vector2 SensorYinGlobal;
    public Vector2 SensorZinGlobal;
    public Vector2 SensorWinGlobal;
    public Vector4 CalibratedForce;
    float x;
    float y;

    void Awake()
    {
    
    }

    // Start is called before the first frame update， Initailize
    void Start()
    {
        
    }
    // Update is called once per frame

    void Update()
    {


    }
    void FixedUpdate()
    {
        

    }

    // Step 1: EliminateError

    public void ForceRangeCheck()
    {
        if (Board_Force.x < 0)
        {
            Board_Force.x = 0;
        }
        if (Board_Force.y < 0)
        {
            Board_Force.y = 0;
        }
        if (Board_Force.z < 0)
        {
            Board_Force.z = 0;
        }
        if (Board_Force.w < 0)
        {
            Board_Force.w = 0;
        }
    }
    // Step2 Force Range Check
    public float CalculateTotalForce()
    {
        Board_Totalforce = CalibratedForce.x + CalibratedForce.y + CalibratedForce.z + CalibratedForce.w;
        return Board_Totalforce;
    }
    // Step3 Total Force
    public Vector2 COPRatioCalculationInLocalCoordinate()
    {
        x = ((Board_Force.x + Board_Force.z) * Board_length / 2 - (Board_Force.y + Board_Force.w) * Board_length / 2) / Board_Totalforce;
        y = ((Board_Force.x + Board_Force.y) * Board_width / 2 - (Board_Force.w + Board_Force.z) * Board_width / 2) / Board_Totalforce;
        Board_COPratioStorage = Board_COP;
        Board_COP.Set(x,y);
        return Board_COP;
    }
    // Step 4 Local COP


    // Step 5 Local COPCheck
    public void COPRatioRangeCheck( )
    {
        if (Board_COP.x > 1)
        {
            Board_COP.x = 1;
        }
        if (Board_COP.y > 1)
        {
            Board_COP.y = 1;
        }
        if (Board_COP.x < -1)
        {
            Board_COP.x = -1;
        }
        if (Board_COP.y < -1)
        {
            Board_COP.y = -1;
        }
    }
    public Vector4 EliminateError(GenericBoard inputboard)
    {
        inputboard.CalibratedForce.x = inputboard.Board_Force.x - inputboard.Board_Force_error_storage.x;
        inputboard.CalibratedForce.y = inputboard.Board_Force.y - inputboard.Board_Force_error_storage.y;
        inputboard.CalibratedForce.z = inputboard.Board_Force.z - inputboard.Board_Force_error_storage.z;
        inputboard.CalibratedForce.w = inputboard.Board_Force.w - inputboard.Board_Force_error_storage.w;
        return inputboard.CalibratedForce;
    }






}

