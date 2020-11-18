using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PositionAngleSetting : MonoBehaviour
{
    public InputField Board0_x;
    public InputField Board0_y;
    public InputField Board0_angle;
    public InputField Board1_x;
    public InputField Board1_y;
    public InputField Board1_angle;
    // Start is called before the first frame update
    public void BacktoStandingSetting()
    {
        SceneManager.LoadScene(1);
    }

    public void GoStandingAssessment()
    {
        SceneManager.LoadScene(4);
    }
    public void Start()
    {
        PlayerPrefs.SetFloat("Board0_angle", 0f);
        PlayerPrefs.SetFloat("Board1_angle", 0f);
        PlayerPrefs.SetFloat("Board1_x", 300f);
        PlayerPrefs.SetFloat("Board1_y", 0f);
    }
    // Update is called once per frame
    void Update()
    {
        Board0_x.readOnly = true;
        Board0_y.readOnly = true;
        Board0_x.text = "0";
        Board0_y.text = "0";

        Board0_angle.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board0_angle", float.Parse(Board0_angle.GetComponent<InputField>().text));
        });

        Board1_x.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board1_x", float.Parse(Board1_x.GetComponent<InputField>().text));
        });

        Board1_y.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board1_y", float.Parse(Board1_y.GetComponent<InputField>().text));
        });

        Board1_angle.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board1_angle", float.Parse(Board1_angle.GetComponent<InputField>().text));
        });

    }
}
