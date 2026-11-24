using UnityEngine;

public class HintTrigger : MonoBehaviour
{
    public GameObject hintObject;

    private void Start()
    {
        if (hintObject != null)
            hintObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.GetComponent<PlayerMovement2D>() != null)
        {
            if (hintObject != null)
                hintObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.GetComponent<PlayerMovement2D>() != null)
        {
            if (hintObject != null)
                hintObject.SetActive(false);
        }
    }
}