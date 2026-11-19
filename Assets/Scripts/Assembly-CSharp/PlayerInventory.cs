using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
	public bool hasCrystal;

	private LevelManager levelManager;

	private void Start()
	{
		levelManager = Object.FindObjectOfType<LevelManager>();
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Crystal") && !hasCrystal)
		{
			hasCrystal = true;
			Object.Destroy(other.gameObject);
			Debug.Log("Кристал у кишені!");
		}
		if (!other.CompareTag("Socket") || !hasCrystal)
		{
			return;
		}
		Transform child = other.transform.GetChild(0);
		if (child != null)
		{
			child.gameObject.SetActive(value: true);
			hasCrystal = false;
			other.GetComponent<Collider2D>().enabled = false;
			if (levelManager != null)
			{
				levelManager.AddCrystal();
			}
		}
	}
}
