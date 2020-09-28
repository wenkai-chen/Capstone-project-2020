﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Runtime.InteropServices;
using System.IO;
using System;



public  class test : MonoBehaviour
{
   
  
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
        
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        
        Wii.WakeUp();
       
        
        Wii.StartSearch();
 
       


        //CSVManager.AppendToReport(
        //    new string[5]{
        //        "Patient",forcex.ToString(),
        //        forcey.ToString(),
        //        forcex.ToString(),
        //        forcez.ToString(),
        //    }
        //);
        
        // sum force for right board
        
        // sum force for left board
        // COP left in grand coordinate(mm)

        // COP right in grand coordinate(mm)
    }
}
