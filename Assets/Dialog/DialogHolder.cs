using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        private bool dialogFinished;
         public Canvas canvasToControlclose;
         public Canvas canvasToControlopen;
        private void OnEnable()
        {
            dialogueSeq = dialogSequence();
            StartCoroutine(dialogueSeq);
        }
        private void Update()
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                Deactivate();
                gameObject.SetActive(false);
                StopCoroutine(dialogueSeq);
            }
        }
        private IEnumerator dialogSequence()
        {
            if(!dialogFinished)
            {
            for(int i = 0; i < transform.childCount-1; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<Dialogline>().finished);
            }
            }
            else
            {
                int index = transform.childCount -1;
                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(()=> transform.GetChild(index).GetComponent<Dialogline>().finished);
            }
            
            
            if (canvasToControlopen != null)
                {
                    canvasToControlopen.gameObject.SetActive(true);
                    canvasToControlclose.gameObject.SetActive(false);
                }
            dialogFinished = true;
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            for(int i = 0 ; i < transform.childCount;i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);

            }
        }

    }   

}

