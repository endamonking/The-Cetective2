using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class dialogueManager : MonoBehaviour
{
    public static dialogueManager Instance { get { return _instance; } }
    private static dialogueManager _instance;

    [SerializeField]
    private GameObject dialogueCanvas, dialogueCanvasPrefab;
    private TextMeshProUGUI text;
    private int _dialogueLine = 0;
    private bool isClosingDialog = false;

    public List<string> dialogList = new List<string>();
    public bool isScreenShowUp = false;
    public GameObject speakerPic;

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;//Avoid doing anything else
        }
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.FindWithTag("DialogueCanvas");
        if (dialogueCanvas != null)
            dialogueCanvas.SetActive(false);
        else
        {
            GameObject DialogScreen = Instantiate(dialogueCanvasPrefab, transform.position, transform.rotation);
            dialogueCanvas = DialogScreen;
            dialogueCanvas.SetActive(false);
        }

        text = dialogueCanvas.GetComponentInChildren<TextMeshProUGUI>();
        Transform pickTranform = dialogueCanvas.transform.Find("Pic");
        speakerPic = pickTranform.gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isScreenShowUp == true && isClosingDialog == false)
            nextLine();
    }

    private void cancelDialog()
    {
        isClosingDialog = true;
        dialogueCanvas.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(closeFlagDelay());
    }

    private void changeText(string newText)
    {
        text.text = newText;
    }

    private void changeSpeakerPic(Sprite newNPCPic)
    {
        speakerPic.GetComponent<Image>().sprite = newNPCPic;
    }

    public void startDialog(List<string> dialogString, Sprite speakerPic)
    {
        dialogList.Clear();
        dialogList.AddRange(dialogString);
        _dialogueLine = 0;
        changeSpeakerPic(speakerPic);
        changeText(dialogList[_dialogueLine]);
        dialogueCanvas.SetActive(true);
        isScreenShowUp = true;
        Time.timeScale = 0f;
    }

    public void nextLine()
    {
        _dialogueLine++;
        if (_dialogueLine >= dialogList.Count) //reach the end
        {
            cancelDialog();
            return;
        }
        changeText(dialogList[_dialogueLine]);

    }

    IEnumerator closeFlagDelay()
    {
        yield return new WaitForSeconds(0.5f);
        isScreenShowUp = false;
        isClosingDialog = false;
    }

}
