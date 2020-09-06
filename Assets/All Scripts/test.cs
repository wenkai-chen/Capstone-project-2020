using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System.IO;
using System;



public  class test : MonoBehaviour
{
    public int connectednumbers;
    public static Vector4 Allforce;
    public static Vector4 Allforce2;
    public static Vector2 COPdataold1;
    public static Vector2 COPdataold2;
    public static float velocityx;
    public static float velocityy;
    public float forcex;
    public float forcey;
    public float forcez;
    public float forcew;
    public float forcex2;
    public float forcey2;
    public float forcez2;
    public float forcew2;
    public static float Totalforceleft;
    public static float Totalforceright;
    private static Vector4 tempforce1;
    private static Vector4 tempforce2;
    public Vector2 Copdata;
    public Vector2 Copdata2;
    public static float copx;
    public static float copy;
    public static float copx2;
    public static float copy2;
  

    public static class CSVManager
    {
        // Start is called before the first frame update
        public static string reportDirectoryName = "Report";
        public static string reportFileName = "report.csv";
        public static string reportSeparator = ",";
        public static string[] reportheaders = new string[5] { "name", "x", "y", "z", "w" };
        public static string timeStampheader = "time stamp";
        #region Interactions

        public static void AppendToReport(string[] strings)
        {
            VerifyDiretory();
            VerifyFile();
            using (StreamWriter sw = File.AppendText(GetFilePath()))
            {
                string finalString = "";
                for (int i = 0; i < strings.Length; i++)
                {
                    if (finalString != "")
                    {
                        finalString += reportSeparator;
                    }
                    finalString += strings[i];

                }
                finalString += reportSeparator + GetTimeStamp();
                sw.WriteLine(finalString);
            }
        }
        public static void CreateReport()
        {
            using (StreamWriter sw = File.CreateText(GetFilePath()))
            {
                string finalString = "";
                for (int i = 0; i < reportheaders.Length; i++)
                {
                    if (finalString != "")
                    {
                        finalString += reportSeparator;
                    }
                    finalString += reportheaders[i];
                }
                finalString += reportSeparator + timeStampheader;
                sw.WriteLine(finalString);

            }
        }
   
        #endregion


        public static void VerifyDiretory()
        {
            string dir = GetDirectoryPath();
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
        public static void VerifyFile()
        {
            string file = GetFilePath();
            if (!File.Exists(file))
            {
                CreateReport();
            }
        }
        static string GetDirectoryPath()
        {
            return Application.dataPath + "/" + reportDirectoryName;
        }
        static string GetFilePath()
        {
            return GetDirectoryPath() + "/" + reportFileName;
        }
        static string GetTimeStamp()
        {
            return System.DateTime.Now.ToString();
        }
    }
    
    void Awake()
    {
        
        Debug.Log("Awake called.");
        Wii.StartSearch();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start called.");
        COPdataold1.x = 0;
        COPdataold1.y = 0;
        COPdataold2.x = 0;
        COPdataold2.y = 0;
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        
        Wii.WakeUp();
       
        
        Wii.StartSearch();
 
        if (Input.GetKeyDown(KeyCode.R))
        {
            tempforce1 = Wii.GetBalanceBoard(0);
            tempforce2 = Wii.GetBalanceBoard(1);
        }
        //hand eliminate error
        Allforce = Wii.GetBalanceBoard(0);
        Allforce2 = Wii.GetBalanceBoard(1);
        Copdata = Wii.GetCenterOfBalance(0);
        Copdata2 = Wii.GetCenterOfBalance(1);
        COPdataold1.x = copx;
        copx = Copdata.x;
        if (copx>1 || copx<-1)
        {
            copx = 0;
        }
        velocityx = (Copdata.x - COPdataold1.x) / Time.fixedDeltaTime;
        // use old to calculate velocity
        COPdataold1.y = copy;
        copy = Copdata.y;
        if (copy > 1 || copy < -1)
        {
            copy = 0;
        }
        velocityy = (Copdata.y - COPdataold1.y) / Time.fixedDeltaTime;
        forcex = Allforce.x- tempforce1.x;
        if (forcex < 0)
        {
            forcex = 0;
        }

        forcey = Allforce.y- tempforce1.y;
        if (forcey < 0)
        {
            forcey = 0;
        }

        forcez = Allforce.z- tempforce1.z;
        if (forcez < 0)
        {
            forcez = 0;
        }

        forcew = Allforce.w- tempforce1.w;
        if (forcew < 0)
        {
            forcew = 0;
        }


        //CSVManager.AppendToReport(
        //    new string[5]{
        //        "Patient",forcex.ToString(),
        //        forcey.ToString(),
        //        forcex.ToString(),
        //        forcez.ToString(),
        //    }
        //);
        Allforce = Wii.GetBalanceBoard(1);
        forcex2 = Allforce.x- tempforce2.x;
        if (forcex2 < 0)
        {
            forcex2 = 0;
        }
        forcey2 = Allforce.y- tempforce2.y;
        if (forcey2 < 0)
        {
            forcey2 = 0;
        }
        forcez2 = Allforce.z- tempforce2.z;
        if (forcez2 < 0)
        {
            forcez2 = 0;
        }
        forcew2 = Allforce.w- tempforce2.w;
        if (forcew < 0)
        {
            forcew = 0;
        }
        
        // sum force for right board
        
        // sum force for left board
        // COP left in grand coordinate(mm)

        // COP right in grand coordinate(mm)
    }
}
