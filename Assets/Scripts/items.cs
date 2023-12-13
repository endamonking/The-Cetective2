using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class items : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public Sprite pic;

    public AudioClip soundEffect;
    private AudioSource audioSource;

    private bool _isPlayerNear = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _isPlayerNear && dialogueManager.Instance.isScreenShowUp == false)
            pickup();

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

    private void pickup()
    {
        audioSource.PlayOneShot(soundEffect);
        player.GetComponent<inventory>().items.Add(this);
        FindObjectOfType<inventory>().UpdateInventory(gameObject);
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        StartCoroutine(delay());
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

}
