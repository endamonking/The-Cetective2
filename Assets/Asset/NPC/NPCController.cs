using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField]private GameObject dialogue;
    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool Dialogactive()
    {
        return dialogue.activeInHierarchy;
    }
}
