using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour
{
    public List<items> items = new List<items>();
    public bool isOpen;
    public GameObject ui_Window;
    public Image[] item_images;
    public GameObject ui_description_Window;
    public Image description_image;
    public Text description_Title;
    public Text description_details;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            ToggleInventory();
        }
    }
    public void UpdateInventory(GameObject item)
    {
        Update_Ui();
    }
    void ToggleInventory()
    {
        isOpen = !isOpen;
        ui_Window.SetActive(isOpen);
    }
    public void Update_Ui()
    {
        HideAll();
        for(int i=0;i<items.Count;i++)
        {
            item_images[i].sprite=items[i].GetComponent<SpriteRenderer>().sprite;
            item_images[i].gameObject.SetActive(true);
        }
    }

    void HideAll(){foreach(var i in item_images){i.gameObject.SetActive(false);}}
    
    public void ShowDescription(int id)
    {
        Debug.Log("hi");
        description_image.sprite=items[id].pic;
        description_Title.text = items[id].itemName;
        description_details.text = items[id].itemDescription;
        description_image.gameObject.SetActive(true);
        description_Title.gameObject.SetActive(true);
        description_details.gameObject.SetActive(true);
    }

    public void HideDescription()
    {
        description_image.gameObject.SetActive(false);
        description_Title.gameObject.SetActive(false);
        description_details.gameObject.SetActive(false);
    }
}
