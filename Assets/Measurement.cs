using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measurement : GenericBoard
{
    public static Vector2 GlobalCOP;
    public static Vector2 GlobalCOPStorage;
    public static Vector2 GlobalVelocity;
    public static GenericBoard Board0;
    public static GenericBoard Board1;
    public static GenericBoard Board2;
    public static GenericBoard Board3;
    List<GenericBoard> Boards=new List<GenericBoard>();
    public static float Globalx;
    public static float Globaly;
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

    // Start is called before the first frame update
    void Start()
    {
        Boards.Add(Board0);
        Boards.Add(Board1);
        Boards.Add(Board2);
        Boards.Add(Board3);
        Board0.BoardNumber = 0;
        Board1.BoardNumber = 1;
        Board2.BoardNumber = 2;
        Board3.BoardNumber = 3;
        foreach (GenericBoard item in Boards)
        {
            // Calculate Initial Sensor Position
            item.RotationMatrix = new float[,] { { Mathf.Cos(Mathf.Deg2Rad * RotationAngle), -Mathf.Sin(Mathf.Deg2Rad * RotationAngle) }, { Mathf.Sin(Mathf.Deg2Rad * RotationAngle), Mathf.Cos(Mathf.Deg2Rad * RotationAngle) } };

            item.SensorXRelative.x = Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length - Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;
            item.SensorXRelative.y = Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length + Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;

            item.SensorYRelative.x = -Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length - Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;
            item.SensorYRelative.y = -Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length + Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;

            item.SensorZRelative.x = Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length + Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;
            item.SensorZRelative.y = Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length - Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;

            item.SensorWRelative.x =-Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length + Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;
            item.SensorWRelative.y =-Mathf.Sin(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_length - Mathf.Cos(Mathf.Deg2Rad * RotationAngle) * 1 / 2 * Board_width;

            item.SensorXinGlobal = item.BoardPosition + item.SensorXRelative;
            item.SensorYinGlobal = item.BoardPosition + item.SensorYRelative;
            item.SensorZinGlobal = item.BoardPosition + item.SensorZRelative;
            item.SensorWinGlobal = item.BoardPosition + item.SensorWRelative;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
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
    public static Vector2 COPRatioCalculationInGlobalCoordinate()
    {
        GlobalCOPStorage= GlobalCOP;
        Globalx = ((Board0.Board_COP.x + Board0.BoardPosition.x) * Board0.Board_Totalforce
            + (Board1.Board_COP.x + Board1.BoardPosition.x) * Board1.Board_Totalforce
            + (Board2.Board_COP.x + Board1.BoardPosition.x) * Board2.Board_Totalforce
            + (Board3.Board_COP.x + Board1.BoardPosition.x) * Board3.Board_Totalforce)
            / (Board0.Board_Totalforce + Board1.Board_Totalforce + Board2.Board_Totalforce + Board3.Board_Totalforce);
        Globaly = ((Board0.Board_COP.y + Board0.BoardPosition.y) * Board0.Board_Totalforce
    + (Board1.Board_COP.y + Board1.BoardPosition.y) * Board1.Board_Totalforce
    + (Board2.Board_COP.y + Board1.BoardPosition.y) * Board2.Board_Totalforce
    + (Board3.Board_COP.y + Board1.BoardPosition.y) * Board3.Board_Totalforce)
    / (Board0.Board_Totalforce + Board1.Board_Totalforce + Board2.Board_Totalforce + Board3.Board_Totalforce);
        GlobalCOP.Set(Globalx, Globaly);
        return GlobalCOP;
    }
    public static Vector2 VelocityCalculationInGlobalCoordinate()
    {
        Velocityx=(GlobalCOP.x- GlobalCOPStorage.x)/ updatetime;
        Velocityy= (GlobalCOP.y - GlobalCOPStorage.y) / updatetime;
        GlobalVelocity.Set(Velocityx, Velocityy);
        return GlobalVelocity;
    }


}

