using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class Dialogline : DialogBase
    {
        private Text textholder;
        [Header("Text Options")]
        [SerializeField] private string input;
        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;
        [Header("Time Options")]
        [SerializeField] private float delay;
        [SerializeField] private float DelaybetweenDialog;
        [Header("Sound Options")]
        [SerializeField] private AudioClip sound;
        [Header("Character Image Options")]
        [SerializeField] private Sprite charactersprite;
        [SerializeField] private Image imageholder;

        private IEnumerator lineAppear;


        private void Awake()
        {          
            imageholder.sprite = charactersprite;
            imageholder.preserveAspect = true;
        }
        private void OnEnable()
        {
            Time.timeScale = 0f;
            ResetLine();
            lineAppear = WriteText(input, textholder, textColor, textFont,delay,sound,DelaybetweenDialog);
            StartCoroutine(lineAppear);
        }
        private void Update()
        {
            if(Input.GetMouseButtonDown(0)){
                if(textholder.text != input)
                {
                    StopCoroutine(lineAppear);
                    textholder.text = input;
                }
                else
                    finished = true;
                    Time.timeScale = 1f;
            }
        }

        private void ResetLine()
        {
            textholder = GetComponent<Text>();
            textholder.text = "";
            finished = false;
        }
    }
}