using System.Collections;
using System.Collections.Generic;
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
        test.whetherstart=true;
   }

    public void Trytostop()
    {
        test.whetherstart = false;
    }

    public void geterror()
    {
        test.calibration();
    }

    public void GotoSavingPage()
    {
        SceneManager.LoadScene(5);
    }
}
