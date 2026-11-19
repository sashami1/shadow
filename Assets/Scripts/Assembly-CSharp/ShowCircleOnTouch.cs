using UnityEngine;

public class ShowCircleOnTouch : MonoBehaviour
{
	public GameObject circle;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (circle != null)
		{
			circle.GetComponent<SpriteRenderer>().enabled = true;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (circle != null)
		{
			circle.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
}
