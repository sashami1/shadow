using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Телепортація!");
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
		}
	}
}
