using System.Collections;
using UnityEngine;
using TMPro;

public class HumanImage : MonoBehaviour

{
    public GameObject human;
    

    // Start is called before the first frame update
    void Start()
    {
        human = GameObject.Find("Main Camera/Canvas/Humanimage");
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
       
       
        human.GetComponent<RectTransform>().anchoredPosition = new Vector2(500 + 400 * GenericBoard.Board_COPratio[0].x, 300 + 200 * GenericBoard.Board_COPratio[0].y);
        Debug.Log(GenericBoard.Board_COPratio[0].x);
        /*if (Board.Board_Totalforce[0] < 5)
        {
            SingleBoardTest.Singleboard_Startstatus = false;
        }
        if (Board.Board_Totalforce[0] > 5)
        {
            SingleBoardTest.Singleboard_Startstatus = true;
        }
        if (SingleBoardTest.Singleboard_Startstatus == false)
        {
            GetComponent<RectTransform>().anchoredPosition = new Vector2(500 , 300);
        }
        */
    }
}
