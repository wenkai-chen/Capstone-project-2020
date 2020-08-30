using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class plot : MonoBehaviour

{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SingleBoardTest.Singleboard_Startstatus == true)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(500 + 400 *Board0.Board0_COPratio[0].x, 300 + 200 * Board0.Board0_COPratio[0].y);
        }
        if (Board0.Board0_Totalforce[0] < 5)
        {
            SingleBoardTest.Singleboard_Startstatus = false;
        }
        if (Board0.Board0_Totalforce[0] > 5)
        {
            SingleBoardTest.Singleboard_Startstatus = true;
        }
        if (SingleBoardTest.Singleboard_Startstatus == false)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(500 , 300);
        }

    }
}
