using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanControl : MonoBehaviour
{
    public GameObject human;


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
        Wii.StartSearch();

        if (Measurement.WhetherStart == true)
        {
            human.transform.localPosition = new Vector2(800f * ((Measurement.GlobalCOP.x + (0.5f * Measurement.Board0.Board_width)) / (Measurement.Board0.Board_width + Measurement.Board1.BoardPosition.x)),
                                                        400f * ((Measurement.GlobalCOP.y + (0.5f * Measurement.Board0.Board_length))/ (Measurement.Board0.Board_length)));
        }
        if (Measurement.WhetherStart == false)
        {
            human.transform.localPosition = new Vector2(0, 0);

        }
    }
}
