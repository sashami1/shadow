using UnityEngine;

public class PlayerPersist : MonoBehaviour
{
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
