using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviour : MonoBehaviour
{
	private LevelLoader levelLoader;

	private void Start()
	{
		levelLoader = Object.FindObjectOfType<LevelLoader>();
		if (levelLoader == null)
		{
			Debug.LogError("LevelLoader не знайдено в сцені! Переходи не працюватимуть.");
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player") && levelLoader != null)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
