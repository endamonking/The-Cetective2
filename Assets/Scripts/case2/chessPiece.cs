using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class chessPiece : MonoBehaviour
{
    [SerializeField]
    private Sprite _pawn, _bishop, _queen;
    private Image image;
    private Vector3 originalPosition;
   
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        Color newColor = image.color;
        newColor.a = 0;
        image.color = newColor;
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeChessSprite(int number)
    {
        transform.position = originalPosition;
        Color newColor = image.color;
        newColor.a = 100;
        image.color = newColor;
        switch (number)
        {
            case 1:
                image.sprite = _pawn;
                break;
            case 2:
                image.sprite = _bishop;
                break;
            case 3:
                image.sprite = _queen;
                break;
            default:
                break;
        }
    }

    public void changePosition(Transform newTranform)
    {
        transform.position = newTranform.position;
    }

}
