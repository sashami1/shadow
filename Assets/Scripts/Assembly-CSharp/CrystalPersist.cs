using UnityEngine;

public class CrystalPersist : MonoBehaviour
{
	private void Awake()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}
}
