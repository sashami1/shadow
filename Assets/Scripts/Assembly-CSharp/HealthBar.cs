using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	private Image healthbar;

	public float maxHealth = 100f;

	public float HP;

	private void Start()
	{
		healthbar = GetComponent<Image>();
		HP = maxHealth;
	}

	private void Update()
	{
		healthbar.fillAmount = HP / maxHealth;
	}
}
