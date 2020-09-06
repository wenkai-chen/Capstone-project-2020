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
        GenericBoard.WhetherStart = true;
   }

    public void Trytostop()
    {
        GenericBoard.WhetherStart = false;
    }

    public void Geterror()
    {
        
        // These value are used for calibriation
    }
    
    public void GotoSavingPage()
    {
        SceneManager.LoadScene(5);
    }
}
