using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystems
{
    public class DialogSound : Dialogbase2
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


        private void Awake()
        {
            textholder = GetComponent<Text>();
            textholder.text = "";

            
            imageholder.sprite = charactersprite;
            imageholder.preserveAspect = true;
        }
        private void Start()
        {
            StartCoroutine(WriteText(input, textholder, textColor, textFont,delay,sound,DelaybetweenDialog));
        }
        
    }
}