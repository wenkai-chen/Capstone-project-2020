using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DataSaving : MonoBehaviour
{


    public static class CSVManager
    {
        // Start is called before the first frame update
        public static string reportDirectoryName = "COPReport";
        public static string reportFileName = "COPreport.csv";
        public static string reportSeparator = ",";
        public static string[] reportheaders = new string[6] { "Name", "TotalForce", "COP X", "COP Y", "Velocity X", "Velocity Y" };
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
            return DateTime.Now.ToString();
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
        Time.fixedDeltaTime = PlayerPrefs.GetFloat("DeltaTime");
    }

    // Update is called once per frame
    void FixedUpdate()

    {

        Wii.WakeUp();


        Wii.StartSearch();


        if (Measurement.WhetherStart == true)
        {
            CSVManager.reportFileName = PlayerPrefs.GetString("UserName") + "COPreport.csv";
            CSVManager.AppendToReport(
           new string[6]{
               
               PlayerPrefs.GetString("UserName"),
               Measurement.GlobalTotalForce.ToString(),
               Measurement.GlobalCOP.x.ToString(),
               Measurement.GlobalCOP.y.ToString(),
               Measurement.GlobalVelocity.x.ToString(),
               Measurement.GlobalVelocity.y.ToString()
           });
        }
    }
}
        
        
      


