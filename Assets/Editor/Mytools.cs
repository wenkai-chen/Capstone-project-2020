using UnityEditor;
using UnityEngine;

public static class Mytools 
{

    [MenuItem("My Tools/Add to report %F1")]
    static void DEV_AppendToReport()
    {
        CSVManager.AppendToReport(
            new string[5]{
                "Patient",Random.Range(0,11).ToString(),
                Random.Range(0,11).ToString(),
                Random.Range(0,11).ToString(),
                Random.Range(0,11).ToString(),
            }
        );
        EditorApplication.Beep();

    }

    [MenuItem("My Tools/Reset report %F2")]
    static void DEV_ResetReport()
    {
        CSVManager.CreateReport();

    }
}
