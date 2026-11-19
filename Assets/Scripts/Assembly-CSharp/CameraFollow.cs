using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public Vector3 offset;

	private void Start()
	{
		GameObject gameObject = GameObject.FindWithTag("Player");
		if (gameObject != null)
		{
			target = gameObject.transform;
		}
	}

	private void LateUpdate()
	{
		if (target != null)
		{
			base.transform.position = target.position + offset;
		}
	}
}
