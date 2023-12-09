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
    public TextMeshProUGUI answerText;
    public List<TextMeshProUGUI> choiceText = new List<TextMeshProUGUI>();
    public string refBoxName;

    private float progressValue = 0f;
    private int correctChoice = 0;
    private GameObject refBox;
    // Start is called before the first frame update
    void Start()
    {
        progressSlider.value = progressValue;
        refBox = GameObject.Find(refBoxName);
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
    
    public void changeAnswerText(int index)
    {
        answerText.text = choiceText[index].text;
    }

    private void updateProgressBar(float value)
    {
        progressValue = progressValue + value;
        if (progressValue <= 0)
            progressValue = 0;

        progressSlider.value = progressValue;

        if (progressValue >= 1.0f)
            refBox.GetComponent<box>().completed();

    }

    private void checkAnswer(int answer)
    {
        if (answer == correctChoice)
            updateProgressBar(0.08f);
        else
            updateProgressBar(-0.03f);

    }

    

}
