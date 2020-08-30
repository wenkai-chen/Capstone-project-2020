using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    void Update()

    {
        Wii.WakeUp();
         theX = (((Board0.Board0_x[0] - 0.5f * Board0.Board0_width[0]) * (Board0.Board0_sensor[0].w + Board0.Board0_sensor[0].z))
                 + ((Board0.Board0_x[0] + 0.5f * Board0.Board0_width[0]) * (Board0.Board0_sensor[0].x + Board0.Board0_sensor[0].y))
                 + ((Board0.Board0_x[1] - 0.5f * Board0.Board0_width[1]) * (Board0.Board0_sensor[1].w + Board0.Board0_sensor[1].z))
                 + ((Board0.Board0_x[1] + 0.5f * Board0.Board0_width[1]) * (Board0.Board0_sensor[1].x + Board0.Board0_sensor[1].y)))
                 / (Board0.Board0_Totalforce[0] + Board0.Board0_Totalforce[1]); 

            theY = (((Board0.Board0_y[0] - 0.5f * Board0.Board0_length[0]) * (Board0.Board0_sensor[0].x + Board0.Board0_sensor[0].z))
                + ((Board0.Board0_y[0] + 0.5f * Board0.Board0_length[0]) * (Board0.Board0_sensor[0].w + Board0.Board0_sensor[0].y))
                + ((Board0.Board0_y[1] - 0.5f * Board0.Board0_length[1]) * (Board0.Board0_sensor[1].x + Board0.Board0_sensor[1].z))
                + ((Board0.Board0_y[1] + 0.5f * Board0.Board0_length[1]) * (Board0.Board0_sensor[1].w + Board0.Board0_sensor[1].y)))
                / (Board0.Board0_Totalforce[0] + Board0.Board0_Totalforce[1]); 

        theX = (Board0.Board0_COPratio[0].y*Board0.Board0_Totalforce[0])+ ((Board0.Board0_COPratio[1].y+ (Board0.Board0_x[1])/ Board0.Board0_width[1]) * Board0.Board0_Totalforce[1]);

        theY = (-Board0.Board0_COPratio[0].x * Board0.Board0_Totalforce[0]) + (-Board0.Board0_COPratio[1].x * Board0.Board0_Totalforce[1]) / (Board0.Board0_Totalforce[0] + Board0.Board0_Totalforce[1]);

    
        GetComponent<RectTransform>().anchoredPosition = new Vector2(250 + theX*150,325 + theY*225);
       
    }
}