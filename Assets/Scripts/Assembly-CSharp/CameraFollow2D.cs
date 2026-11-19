using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
	public Transform target;

	public float smoothSpeed = 5f;

	public float offsetZ = -10f;

	[Header("Налаштування Меж (Кордонів)")]
	public bool enableLimits = true;

	public float minX = -100f;

	public float maxX = 100f;

	public float minY = -100f;

	public float maxY = 100f;

	private void LateUpdate()
	{
		if (!(target == null))
		{
			Vector3 position = Vector3.Lerp(b: new Vector3(target.position.x, target.position.y, offsetZ), a: base.transform.position, t: smoothSpeed * Time.deltaTime);
			if (enableLimits)
			{
				position.x = Mathf.Clamp(position.x, minX, maxX);
				position.y = Mathf.Clamp(position.y, minY, maxY);
			}
			base.transform.position = position;
		}
	}
}
