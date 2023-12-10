using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public List<string> noItemToUnlock = new List<string>();
    public List<string> hasItemToUnlock = new List<string>();
    public GameObject doorPrefab; //will generate door to interact to change scene
    public string keyName;
    public Sprite speakerPic;

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
            openDoor();
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

    private void openDoor()
    {
        if (player == null)
            return;

        if (checkKey(player.GetComponent<inventory>().items))
        {
            dialogueManager.Instance.startDialog(hasItemToUnlock, speakerPic);
            GameObject newDoor = Instantiate(doorPrefab, transform.position, transform.rotation);
            newDoor.name = doorPrefab.name;
            Destroy(this.gameObject);
        }
        else
            dialogueManager.Instance.startDialog(noItemToUnlock, speakerPic);

    }

    private bool checkKey(List<items> playerItems)
    {
        foreach (items item in playerItems)
        {
            if (item.itemName == keyName)
                return true;
        }
        return false;
    }

}
