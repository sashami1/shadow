using UnityEngine;

public class Door : MonoBehaviour
{
	public Collider2D doorCollider;

	public SpriteRenderer doorSprite;

	public float openMoveY = 2f;

	public float openTime = 0.5f;

	private bool isOpen;

	private void Start()
	{
		if (doorCollider == null)
		{
			doorCollider = GetComponent<Collider2D>();
		}
		if (doorSprite == null)
		{
			doorSprite = GetComponent<SpriteRenderer>();
		}
	}

	public void OpenDoor()
	{
		if (!isOpen)
		{
			isOpen = true;
			if (doorCollider != null)
			{
				doorCollider.enabled = false;
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}
	}
}
