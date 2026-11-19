using UnityEngine;

public class Door2 : MonoBehaviour
{
	public void OpenDoor()
	{
		Debug.Log("Door opened!");
		base.gameObject.SetActive(value: false);
	}
}
