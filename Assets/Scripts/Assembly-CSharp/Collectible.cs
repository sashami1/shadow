using UnityEngine;

public class Collectible : MonoBehaviour
{
	public AudioClip pickupSfx;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (pickupSfx != null)
			{
				AudioSource.PlayClipAtPoint(pickupSfx, base.transform.position);
			}
			if (QuestManager.Instance != null)
			{
				QuestManager.Instance.CollectItem();
			}
			Object.Destroy(base.gameObject);
		}
	}
}
