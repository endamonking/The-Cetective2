using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarpDoor : MonoBehaviour
{
    private bool _isPlayerNear = false;
    private GameObject player;
    GameObject players;
    public Transform destination;
    public Canvas canvasToControl;
    private GameObject mainCamera;
    [SerializeField] private GameObject _starting;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear && dialogueManager.Instance.isScreenShowUp == false)
        {
            if (canvasToControl != null)
            {
                canvasToControl.gameObject.SetActive(true);
                players.transform.position = destination.transform.position;
            }
            else
            {
                
                 StartCoroutine(DisableEndAfterDelay());
            }
            
            mainCamera.transform.position = destination.position;
            
        }
    }
    private IEnumerator DisableEndAfterDelay()
    {
        _starting.SetActive(true);
        players.transform.position = destination.transform.position;
        yield return new WaitForSeconds(1f);
        
        _starting.SetActive(false);
    }
    private void Awake()
    {
        players = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            _isPlayerNear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            player = null;
            _isPlayerNear = false;
        }
    }   
}
