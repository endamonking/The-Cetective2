using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystems
{
    public class Dialogholder2 : MonoBehaviour
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
                yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogSound>().finished);
            }
            
            
            if (canvasToControlopen != null)
                {
                    canvasToControlopen.gameObject.SetActive(true);
                    canvasToControlclose.gameObject.SetActive(false);
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

