using UnityEngine;

public class SpotTrigger : MonoBehaviour
{
	public Door2 door;

	public string requiredTag = "PuzzleObject";

	private bool doorOpened;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!doorOpened && other.CompareTag(requiredTag))
		{
			door.OpenDoor();
			doorOpened = true;
			Debug.Log("Правильний предмет вставлено — двері відкрились!");
		}
	}
}
