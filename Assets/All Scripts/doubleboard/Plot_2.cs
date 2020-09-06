using System.Collections;

using UnityEngine;
using System;
using TMPro;

public class Plot_2 : MonoBehaviour

{
    public float theX;
    public float theY;
    // Start is called before the first frame update
    void Start()
    {

    }
    void Awake()
    {

        Debug.Log("Awake called.");
        Wii.StartSearch();
        

    }
    // Update is called once per frame
    void FixedUpdate()

    {

        Wii.WakeUp();
        
        Wii.StartSearch();
        
        /*theX = (((Board.Board_x[0] - 0.5f * Board.Board_width[0]) * (Board.Board_sensor[0].w + Board.Board_sensor[0].z))
                + ((Board.Board_x[0] + 0.5f * Board.Board_width[0]) * (Board.Board_sensor[0].x + Board.Board_sensor[0].y))
                + ((Board.Board_x[1] - 0.5f * Board.Board_width[1]) * (Board.Board_sensor[1].w + Board.Board_sensor[1].z))
                + ((Board.Board_x[1] + 0.5f * Board.Board_width[1]) * (Board.Board_sensor[1].x + Board.Board_sensor[1].y)))
                / (Board.Board_Totalforce[0] + Board.Board_Totalforce[1]); 

        theY = (((Board.Board_y[0] - 0.5f * Board.Board_length[0]) * (Board.Board_sensor[0].x + Board.Board_sensor[0].z))
               + ((Board.Board_y[0] + 0.5f * Board.Board_length[0]) * (Board.Board_sensor[0].w + Board.Board_sensor[0].y))
               + ((Board.Board_y[1] - 0.5f * Board.Board_length[1]) * (Board.Board_sensor[1].x + Board.Board_sensor[1].z))
               + ((Board.Board_y[1] + 0.5f * Board.Board_length[1]) * (Board.Board_sensor[1].w + Board.Board_sensor[1].y)))
               / (Board.Board_Totalforce[0] + Board.Board_Totalforce[1]); */

        theX = ((GenericBoard.Board_COPratio[0].y * GenericBoard.Board_Totalforce[0]) + ((GenericBoard.Board_COPratio[1].y + (GenericBoard.Board_x[1]) / GenericBoard.Board_width[1]) * GenericBoard.Board_Totalforce[1]))/ (GenericBoard.Board_Totalforce[0] + GenericBoard.Board_Totalforce[1]);

        theY =( (-GenericBoard.Board_COPratio[0].x * GenericBoard.Board_Totalforce[0]) + (-GenericBoard.Board_COPratio[1].x * GenericBoard.Board_Totalforce[1])) / (GenericBoard.Board_Totalforce[0] + GenericBoard.Board_Totalforce[1]);
        Debug.Log(GenericBoard.Board_COPratio[0]);
        Debug.Log(GenericBoard.Board_COPratio[1]);
        Debug.Log(GenericBoard.Board_Totalforce[0]);
        Debug.Log(GenericBoard.Board_Totalforce[1]);
        if (GenericBoard.WhetherStart==true)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(250f + theX * 150f, 325f + theY * 225f);
        }
        if (GenericBoard.WhetherStart == false)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(250f, 325f);
        }

    }
}