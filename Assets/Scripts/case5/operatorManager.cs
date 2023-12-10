using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class operatorManager : MonoBehaviour
{

    public GameObject gameCanvas;

    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    public List<string> firstQuestionString = new List<string>();
    public List<string> secondQuestionString = new List<string>();
    public List<string> answerQuestionString = new List<string>();
    public List<int> questionAnswer = new List<int>();

    public string refBoxName;
    private int questionIndex = 0;
    private GameObject refBox;
    // Start is called before the first frame update
    void Start()
    {
        refBox = GameObject.Find(refBoxName);
        startQuestion();
        questionIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void chooseAnswer(int answer)
    {
        checkAnswer(answer);
    }

    private void checkAnswer(int answer)
    {
        if (answer == questionAnswer[questionIndex])
        {
            questionIndex++;
            if (questionIndex >= 4)
            {
                refBox.GetComponent<box>().completed();
                return;
            }
            textList[0].text = firstQuestionString[questionIndex];
            textList[1].text = secondQuestionString[questionIndex];
            textList[2].text = answerQuestionString[questionIndex];
        }

    }

    private void startQuestion()
    {
        textList[0].text = firstQuestionString[questionIndex];
        textList[1].text = secondQuestionString[questionIndex];
        textList[2].text = answerQuestionString[questionIndex];
    }

}
