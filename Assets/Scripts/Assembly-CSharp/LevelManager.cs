using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public GameObject portalObject;

	public int totalCrystals = 3;

	private int collectedCrystals;

	public void AddCrystal()
	{
		collectedCrystals++;
		Debug.Log("Прогрес: " + collectedCrystals + "/" + totalCrystals);
		if (collectedCrystals >= totalCrystals)
		{
			Debug.Log("Портал відкрито!");
			if (portalObject != null)
			{
				portalObject.SetActive(value: true);
			}
		}
	}
}
