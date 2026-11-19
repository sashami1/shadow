using TMPro;
using UnityEngine;

public class CounterUI : MonoBehaviour
{
	public TextMeshProUGUI counterText;

	private void OnEnable()
	{
		if (QuestManager.Instance != null)
		{
			QuestManager.Instance.OnCountChanged += UpdateText;
		}
	}

	private void OnDisable()
	{
		if (QuestManager.Instance != null)
		{
			QuestManager.Instance.OnCountChanged -= UpdateText;
		}
	}

	private void UpdateText(int current, int required)
	{
		if (counterText != null)
		{
			counterText.text = $"Found: {current} / {required}";
		}
	}
}
