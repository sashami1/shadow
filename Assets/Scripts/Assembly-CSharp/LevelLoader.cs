using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public void LoadNextLevel()
	{
		int num = SceneManager.GetActiveScene().buildIndex + 1;
		if (num < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(num);
			return;
		}
		Debug.Log("Всі рівні пройдено. Повернення до Головного меню.");
		SceneManager.LoadScene(0);
	}

	public void LoadLevelByIndex(int sceneIndex)
	{
		if (sceneIndex < SceneManager.sceneCountInBuildSettings)
		{
			SceneManager.LoadScene(sceneIndex);
		}
		else
		{
			Debug.LogError("Сцена з індексом " + sceneIndex + " не знайдена!");
		}
	}
}
