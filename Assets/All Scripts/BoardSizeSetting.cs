using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class BoardSizeSetting : GenericBoard
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
            inputLength.text = "100";
            inputWidth.text = "80";
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
            Board_length = float.Parse(inputLength.GetComponent<InputField>().text);
        });
        inputWidth.onValueChanged.AddListener(delegate
        {
            Board_width = float.Parse(inputWidth.GetComponent<InputField>().text);
        });

        inputLength.onEndEdit.AddListener(delegate
        {
            Board_length = float.Parse(inputLength.GetComponent<InputField>().text);
        });
        inputWidth.onEndEdit.AddListener(delegate
        {
            Board_width = float.Parse(inputWidth.GetComponent<InputField>().text);
        });

        
    }
}
