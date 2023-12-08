using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class case1Manager : MonoBehaviour
{
    public TextMeshProUGUI pinText;
    public string refBoxName;
    public string[] correctNumber = { "6", "9", "4", "2" };
    public string[] selectedNumber = new string[4];
    public int numberIndex = 0;

    private GameObject refBox;
    // Start is called before the first frame update
    void Start()
    {
        updatePIN();
        refBox = GameObject.Find(refBoxName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void resetNumber()
    {
        numberIndex = 0;
        for (int i = 0; i < selectedNumber.Length; i++)
        {
            selectedNumber[i] = "0";
        }
        updatePIN();
    }

    public void selectNumber(string number)
    {
        selectedNumber[numberIndex] = number;
        updatePIN();
        numberIndex++;
        if (numberIndex >= 4) //Reach limit
            checkNumber();
    }

    private void updatePIN()
    {
        pinText.text = selectedNumber[0] + selectedNumber[1] + selectedNumber[2] + selectedNumber[3];
    }

    private void checkNumber()
    {
        bool isCorrect = true;
        for (int i = 0; i < correctNumber.Length; i++)
        {
            if (correctNumber[i] != selectedNumber[i])
            {
                isCorrect = false;
                break;
            }

        }
        resetNumber();
        if (isCorrect)
        {
            refBox.GetComponent<box>().completed();
        }
            
    }


}
