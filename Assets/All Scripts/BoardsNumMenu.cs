using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardsNumMenu : GenericBoard
{
    public Dropdown BoardsNumberDropdown;
    public GameObject oneBoard;
    public GameObject TwoBoards1;
    public GameObject TwoBoards2;
    public string BoardNumString;

    void Start()
    {
       /* oneBoard = GameObject.Find("Canvas/BoardsNumMenu/OneBoard");
        TwoBoards1 = GameObject.Find("Canvas/BoardsNumMenu/TwoBoards1");
        TwoBoards2 = GameObject.Find("Canvas/BoardsNumMenu/TwoBoards2");*/
        oneBoard.SetActive(false);
        TwoBoards1.SetActive(false);
        TwoBoards2.SetActive(false);
    }
  
   

    void Update()
    {
        BoardNumString = BoardsNumberDropdown.options[BoardsNumberDropdown.value].text;
        if (BoardNumString == "Single Board")
        {
            oneBoard.SetActive(true);
            TwoBoards1.SetActive(false);
            TwoBoards2.SetActive(false);
            BoardNumber = 1;
        }
        else if (BoardNumString == "Double Boards")
        {
            oneBoard.SetActive(false);
            TwoBoards1.SetActive(true);
            TwoBoards2.SetActive(true);
            BoardNumber = 2;
        }
    }
}
