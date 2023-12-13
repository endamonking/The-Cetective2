using UnityEngine;

public class CanVasController : MonoBehaviour
{
    public Canvas canvasToControl;

    // Open the canvas
    public void OpenCanvas()
    {
        if (canvasToControl != null)
        {
            canvasToControl.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Canvas is not assigned to CanvasController.");
        }
    }

    // Close the canvas
    public void CloseCanvas()
    {
        if (canvasToControl != null)
        {
            canvasToControl.gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas is not assigned to CanvasController.");
        }
    }
}
