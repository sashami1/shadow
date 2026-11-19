using UnityEngine;

public class GroundDebugger : MonoBehaviour
{
	public Transform groundCheck;

	public float checkRadius = 0.2f;

	public LayerMask groundLayer;

	private void Update()
	{
		_ = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) != null;
	}

	private void OnDrawGizmos()
	{
		if (groundCheck != null)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
		}
	}
}
