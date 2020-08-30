using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
