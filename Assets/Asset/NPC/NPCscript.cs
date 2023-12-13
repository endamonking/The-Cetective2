using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCscript : MonoBehaviour
{
    public Canvas canvasToopen;
    private bool _isPlayerNear = false;
    private GameObject player;
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear)
        {
            canvasToopen.gameObject.SetActive(true);
        }
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
