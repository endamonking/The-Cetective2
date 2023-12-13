using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _starting;
    [SerializeField] private GameObject _end;

    private void Start()
    {
        _starting.SetActive(true);
        StartCoroutine(DisableStartingAfterDelay());
    }

    private IEnumerator DisableStartingAfterDelay()
    {
        yield return new WaitForSeconds(5f);
        DisableStarting();
    }

    private void DisableStarting()
    {
        _starting.SetActive(false);
    }
    private void Update()
    {
        _end.SetActive(true);

        
    }
    private void DisableEnd()
    {
        _end.SetActive(false);
    }
    private IEnumerator DisableEndAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
    }
}
