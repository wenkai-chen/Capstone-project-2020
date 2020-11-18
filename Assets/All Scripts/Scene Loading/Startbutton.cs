using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Runtime.InteropServices;
using System.IO;

public class Startbutton : MonoBehaviour
{
    // Start is called before the first frame update
    public void Trytostart()
   {
        Measurement.WhetherStart = true;
        Debug.Log("start");

   }

    public void Trytostop()
    {
        Measurement.WhetherStart = false;
        Debug.Log("stop");
    }

    public void Geterror()
    {
        Measurement.Board0.Board_Force_error_storage = Wiiboard.Board_ForceRead(0);
        Measurement.Board1.Board_Force_error_storage = Wiiboard.Board_ForceRead(1);
        Measurement.Board2.Board_Force_error_storage = Wiiboard.Board_ForceRead(2);
        Measurement.Board3.Board_Force_error_storage = Wiiboard.Board_ForceRead(3);
        // These value are used for calibriation
    }
    
    public void GotoSavingPage()
    {
        SceneManager.LoadScene(5);
    }
}
