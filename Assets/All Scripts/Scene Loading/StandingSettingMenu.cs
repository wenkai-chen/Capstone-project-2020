using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StandingSettingMenu : MonoBehaviour
{
    

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoStandingAssessment()
    {
        SceneManager.LoadScene(4);
    }



    
}
