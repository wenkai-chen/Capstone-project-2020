using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BoardSizeSetting: MonoBehaviour
{
    public Dropdown Boardtype;
    public InputField inputLength;
    public InputField inputWidth;
    public string BoardTypeString;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        BoardTypeString = Boardtype.options[Boardtype.value].text;
        if (BoardTypeString == "Wii Board")
        {
            inputLength.readOnly = true;
            inputWidth.readOnly = true;
            inputLength.text = "433";
            inputWidth.text = "238";
            PlayerPrefs.SetFloat("Board_Width", 238);
            PlayerPrefs.SetFloat("Board_Length", 433);
            
            PlayerPrefs.SetFloat("DeltaTime", 0.02f);
        }
        else if (BoardTypeString == "Fourier Board")
        {
            inputLength.readOnly = true;
            inputWidth.readOnly = true;
            inputLength.text = "999";
            inputWidth.text = "999";
        }
        else if (BoardTypeString == "Customized Board")
        {
            inputLength.readOnly = false;
            inputWidth.readOnly = false;
        }


        inputLength.onValueChanged.AddListener(delegate
        {

            PlayerPrefs.SetFloat("Board_Length", float.Parse(inputLength.GetComponent<InputField>().text));

        });
        inputWidth.onValueChanged.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board_Width", float.Parse(inputWidth.GetComponent<InputField>().text));
        });

        inputLength.onEndEdit.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board_Length", float.Parse(inputLength.GetComponent<InputField>().text));
        });
        inputWidth.onEndEdit.AddListener(delegate
        {
            PlayerPrefs.SetFloat("Board_Width", float.Parse(inputWidth.GetComponent<InputField>().text));
        });

        
    }
}
