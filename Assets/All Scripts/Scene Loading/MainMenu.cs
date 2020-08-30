using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoStandingSetting()
    {
        SceneManager.LoadScene("StandingSetting");
    }

    public void GoWeightshiftSetting()
    {
        SceneManager.LoadScene("WeightshiftSetting");
    }

    public void GoSteppingSetting()
    {
        SceneManager.LoadScene("SteppingSetting");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
