using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class casr4Manager : MonoBehaviour
{

    public int[,] correctAnswer = new int[7, 3];
    public int[] selectedAnswer = new int[3];
    public List<GameObject> answerText = new List<GameObject>();
    public string refBoxName;

    private GameObject refBox;
    private int questionIndex = 0;
    private int answerIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        refBox = GameObject.Find(refBoxName);
        correctAnswer = new int[,] 
        {
            { 1,2,3},{ 0,0,0},
            { 0,0,0},{ 0,0,0},
            { 0,0,0},{ 0,0,0},
            { 0,0,0},
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseAnswer(int number)
    {
        if (answerIndex >= 3)
            return;

        selectedAnswer[answerIndex] = number;
        answerIndex++;
    }

    public void changeText(string text)
    {
        answerText[answerIndex-1].GetComponent<TextMeshProUGUI>().text = text;
    }

    public void resetAnswer()
    {
        selectedAnswer = new int[] { 9, 9, 9 };
        answerIndex = 0;
        foreach (GameObject answer in answerText)
        {
            answer.GetComponent<TextMeshProUGUI>().text = " ";
        }
    }

    public void checkAnswer()
    {
        bool isCorrect = true;

        for (int i = 0; i < 3; i++)
        {
            if (selectedAnswer[i] != correctAnswer[questionIndex,i])
            {
                isCorrect = false;
                break;
            }
        }
        if (isCorrect)
        {
            questionIndex++;
            resetAnswer();
        }
        else
            resetAnswer();

        if (questionIndex >= 7)
        {
            refBox.GetComponent<box>().completed();
        }


    }

}
