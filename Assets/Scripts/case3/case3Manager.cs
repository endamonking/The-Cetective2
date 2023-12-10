using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class case3Manager : MonoBehaviour
{
    public GameObject menuCanvas;
    public GameObject gameCanvas;
    public Slider progressSlider;

    public List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    public List<string> firstQuestionString = new List<string>();
    public List<string> secondQuestionString = new List<string>();
    public List<string> answerQuestionString = new List<string>();
    public List<int> questionAnswer = new List<int>();

    public string refBoxName;

    private float progressValue = 0f;
    private int questionIndex = 0;
    private GameObject refBox;
    // Start is called before the first frame update
    void Start()
    {
        progressSlider.value = progressValue;
        refBox = GameObject.Find(refBoxName);
        startQuestion();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void startMath()
    {
        menuCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }

    public void chooseAnswer(int answer)
    { 
        checkAnswer(answer);
    }
   
    private void updateProgressBar(float value)
    {
        progressValue = progressValue + value;
        questionIndex = Random.Range(0,questionAnswer.Count);
        //Change question string
        textList[0].text = firstQuestionString[questionIndex];
        textList[1].text = secondQuestionString[questionIndex];
        textList[2].text = answerQuestionString[questionIndex];

        if (progressValue <= 0)
            progressValue = 0;

        progressSlider.value = progressValue;

        if (progressValue >= 1.0f)
            refBox.GetComponent<box>().completed();

    }

    private void checkAnswer(int answer)
    {
        if (answer == questionAnswer[questionIndex])
            updateProgressBar(0.08f);
        else
            updateProgressBar(-0.03f);

    }

    private void startQuestion()
    {
        questionIndex = Random.Range(0, questionAnswer.Count);
        textList[0].text = firstQuestionString[questionIndex];
        textList[1].text = secondQuestionString[questionIndex];
        textList[2].text = answerQuestionString[questionIndex];
    }

    

}
