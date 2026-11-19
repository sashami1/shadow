using UnityEngine;

public class AltarTrigger : MonoBehaviour
{
	public string requiredTag;

	public Level3Manager manager;

	private bool activated;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!activated && other.CompareTag(requiredTag))
		{
			activated = true;
			manager.AltarActivated();
			Debug.Log("Алтарь активовано: " + requiredTag);
		}
	}
}
