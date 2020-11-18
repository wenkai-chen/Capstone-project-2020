using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StandingSettingMenu : MonoBehaviour
{
    public InputField IDNumber;

    public void BacktoMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void GoPositionAngleSetting()
    {
        SceneManager.LoadScene(7);
    }

    void Update()
    {
        IDNumber.onValueChanged.AddListener(delegate
        {

            PlayerPrefs.SetString("UserName", IDNumber.GetComponent<InputField>().text);

        });
    }



}
