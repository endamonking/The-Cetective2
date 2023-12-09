using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chessManager : MonoBehaviour
{
    public int[] correctAnswer = new int[2];
    public int[] selectedAnswer = new int[2]; // 0 for null
    public List<Transform> buttonTranform = new List<Transform>();

    public string refBoxName;
    public GameObject clueCanvas;
    public List<GameObject> chessBut = new List<GameObject>();
    public GameObject chessPiece;
    private GameObject refBox;
    // Start is called before the first frame update
    void Start()
    {
        refBox = GameObject.Find(refBoxName);
        checkPlayerChess();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseBoard(int number)
    {
        if (selectedAnswer[1] == 0)
            return;

        chessPiece.GetComponent<chessPiece>().changePosition(buttonTranform[number-1]);

        selectedAnswer[0] = number;
        checkWinCondition();
    }

    public void chooseChess(int number)
    {
        chessPiece.GetComponent<chessPiece>().changeChessSprite(number);
        selectedAnswer[1] = number;
    }

    public void openCLue()
    {
        clueCanvas.SetActive(true);
    }

    public void closeClue()
    {
        clueCanvas.SetActive(false);
    }

    private void checkPlayerChess()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        List<items> playerItems = player.GetComponent<inventory>().items;

        foreach (items item in playerItems)
        {
            switch (item.itemName)
            {
                case "Pawn":
                    chessBut[0].SetActive(true);
                    break;
                case "Bishop":
                    chessBut[1].SetActive(true);
                    break;
                case "Queen":
                    chessBut[2].SetActive(true);
                    break;
            }
        }

    }

    private void checkWinCondition()
    {
        bool isCorrect = true;
        for (int i = 0; i < correctAnswer.Length; i++)
        {
            if (correctAnswer[i] != selectedAnswer[i])
            {
                isCorrect = false;
                break;
            }

        }
    
        if (isCorrect)
        {
            refBox.GetComponent<box>().completed();
        }

    }

}
