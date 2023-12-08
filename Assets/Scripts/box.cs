using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class box : MonoBehaviour
{
    public Sprite closedBox, openedBox;
    public int puzzleSceneNumber;
    public GameObject keyPrefab;

    private bool _isPlayerNear = false, _isOpen = false, _iscompleted = false;
    private GameObject player;
    private SpriteRenderer spriteRender;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear && dialogueManager.Instance.isScreenShowUp == false && _isOpen == false && _iscompleted == false)
            LoadSceneAdditive();
        if (Input.GetKeyDown(KeyCode.Escape) && _isPlayerNear && _isOpen == true)
            UnloadScene();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
        {
            player = collision.gameObject;
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) ;
        {
            player = null;
            _isPlayerNear = false;
        }
    }

    public void LoadSceneAdditive()
    {
        _isOpen = true;
        Time.timeScale = 0;
        SceneManager.LoadScene(puzzleSceneNumber, LoadSceneMode.Additive);
    }
    private void UnloadScene()
    {
        _isOpen = false;
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(puzzleSceneNumber);
    }

    public void completed()
    {
        UnloadScene();
        _iscompleted = true;
        spriteRender.sprite = openedBox;

        GameObject key = Instantiate(keyPrefab, transform.position, transform.rotation);
    }

}
