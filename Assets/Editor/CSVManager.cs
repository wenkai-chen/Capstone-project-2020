using System.IO;
using UnityEngine;

public  static class CSVManager
{
    // Start is called before the first frame update
    public static string reportDirectoryName = "Report";
    public static string reportFileName = "report.csv";
    public static string reportSeparator = ",";
    public static string[] reportheaders = new string[5] { "name", "x","y", "z", "w" };
    public static string timeStampheader = "time stamp";
# region Interactions

    public static void AppendToReport(string[] strings){
        VerifyDiretory();
        VerifyFile();
        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for(int i=0;i< strings.Length; i++)
            {
                if (finalString != "")
                {
                    finalString += reportSeparator;
                }
                finalString += strings[i];

            }
            finalString += reportSeparator+ GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }
    public static void CreateReport()
    {
        using (StreamWriter sw = File.CreateText(GetFilePath()))
        {
            string finalString = "";
            for(int i=0;i< reportheaders.Length;i++){
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
        if(!File.Exists(file)){
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
