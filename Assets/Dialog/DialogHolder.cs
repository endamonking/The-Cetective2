using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogHolder : MonoBehaviour
    {
         public Canvas canvasToControlclose;
         public Canvas canvasToControlopen;
        private void Awake()
        {
            StartCoroutine(dialogSequence());
        }
        private IEnumerator dialogSequence()
        {
            for(int i = 0; i < transform.childCount; i++)
            {
                Deactivate();
                transform.GetChild(i).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<Dialogline>().finished);
            }
            canvasToControlclose.gameObject.SetActive(false);
            
            if (canvasToControlopen != null)
                {
                    canvasToControlopen.gameObject.SetActive(true);
                }
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

