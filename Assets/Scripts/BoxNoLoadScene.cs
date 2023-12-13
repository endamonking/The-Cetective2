using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxNoLoadScene : MonoBehaviour
{
    public Sprite closedBox, openedBox;
    public List<GameObject> dropItemPrefab = new List<GameObject>();
    public List<string> keyItemName = new List<string>();
    public List<string> noItemToUnlockString = new List<string>();
    public Sprite speakerPic;

    private bool _isPlayerNear = false, _isOpen = false, _iscompleted = false;
    private GameObject player;
    private SpriteRenderer spriteRender;

    public AudioClip soundEffect;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear && dialogueManager.Instance.isScreenShowUp == false && _isOpen == false && _iscompleted == false)
            dropItem();
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

    private void dropItem()
    {
        int i = 0;
        if (checkKey(player.GetComponent<inventory>().items))
        {
            foreach (GameObject itemPrefab in dropItemPrefab)
            {
                GameObject key = Instantiate(itemPrefab, transform.position + new Vector3 (i,0,0), transform.rotation);
                key.name = itemPrefab.GetComponent<items>().itemName;
                i = i + 1;
            }
            _iscompleted = true;
            spriteRender.sprite = openedBox;
            audioSource.PlayOneShot(soundEffect);
        }
        else
        {
            dialogueManager.Instance.startDialog(noItemToUnlockString, speakerPic);
        }
    }

    private bool checkKey(List<items> playerItems)
    {
        int count = 0;

        foreach (items item in playerItems)
        {
            if (keyItemName.Contains(item.itemName))
            {
                count++;
            }
        }
        
        if (count == keyItemName.Count)
            return true;
        else
            return false;

    }

}
