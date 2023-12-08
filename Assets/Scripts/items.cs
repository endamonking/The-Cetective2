using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public Sprite pic;

    private bool _isPlayerNear = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear && dialogueManager.Instance.isScreenShowUp == false)
            pickup();
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

    private void pickup()
    {
        player.GetComponent<inventory>().items.Add(this);
        Destroy(this.gameObject);
    }

}
