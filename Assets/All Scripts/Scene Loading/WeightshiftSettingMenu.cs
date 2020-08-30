using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeightshiftSettingMenu : MonoBehaviour
{
    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void GoWeightshiftAssessment()
    {
        SceneManager.LoadScene(6);
    }
    
}
