using UnityEngine;

public class PopupTrigger2D : MonoBehaviour
{
	public GameObject cloud;

	private void Start()
	{
		if (cloud != null)
		{
			cloud.SetActive(value: false);
		}
		else
		{
			Debug.LogWarning("PopupTrigger2D: cloud не прив'язана!");
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log("OnTriggerEnter2D with: " + other.name + " tag=" + other.tag);
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player entered trigger -> show cloud");
			cloud.SetActive(value: true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		Debug.Log("OnTriggerExit2D with: " + other.name);
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player exited trigger -> hide cloud");
			cloud.SetActive(value: false);
		}
	}
}
