using System;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
	public int currentCount;

	public int requiredCount = 3;

	public Door Door;

	public static QuestManager Instance { get; private set; }

	public event Action<int, int> OnCountChanged;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		OnCountChanged?.Invoke(currentCount, requiredCount);
	}

	public void CollectItem()
	{
		currentCount++;
		OnCountChanged?.Invoke(currentCount, requiredCount);
		CheckOpenDoor();
	}

	private void CheckOpenDoor()
	{
		if (!(Door == null) && currentCount >= requiredCount)
		{
			Door.OpenDoor();
		}
	}
}
