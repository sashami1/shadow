using UnityEngine;

public class Level3Manager : MonoBehaviour
{
	public int activatedAltars;

	public int totalAltars = 3;

	public GameObject finalPortal;

	public void AltarActivated()
	{
		activatedAltars++;
		if (activatedAltars >= totalAltars)
		{
			finalPortal.SetActive(value: true);
			Debug.Log("ВСІ АЛТАРІ АКТИВОВАНІ! ПОРТАЛ ВІДКРИВСЯ!");
		}
	}
}
