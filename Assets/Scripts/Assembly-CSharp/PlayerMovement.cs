using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
	[Header("Movement")]
	public float moveSpeed = 5f;

	public float smoothTimeGround = 0.05f;

	public float smoothTimeAir = 0.15f;

	[Header("Jump")]
	public float jumpForce = 7f;

	[Header("Ground Check")]
	public Transform groundCheck;

	public float groundRadius = 0.15f;

	public LayerMask groundLayer;

	[Header("Debug")]
	public bool debugLogs;

	private Rigidbody2D rb;

	private Collider2D col;

	private float inputX;

	private float velXSmoothing;

	private void Awake()
	{
		rb = GetComponent<Rigidbody2D>();
		col = GetComponent<Collider2D>();
		if (col == null)
		{
			col = GetComponentInChildren<Collider2D>();
		}
		rb.constraints = RigidbodyConstraints2D.FreezeRotation;
		if (groundCheck == null)
		{
			GameObject gameObject = new GameObject("GroundCheck");
			gameObject.transform.SetParent(base.transform);
			gameObject.transform.localPosition = new Vector3(0f, -0.6f, 0f);
			groundCheck = gameObject.transform;
		}
		if ((int)groundLayer == 0)
		{
			groundLayer = -1;
		}
	}

	private void Update()
	{
		inputX = Input.GetAxis("Horizontal");
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			if (debugLogs)
			{
				Debug.Log("PlayerMovement: Jump");
			}
		}
	}

	private void FixedUpdate()
	{
		float num = inputX * moveSpeed;
		float smoothTime = (IsGrounded() ? smoothTimeGround : smoothTimeAir);
		float num2 = Mathf.SmoothDamp(rb.velocity.x, num, ref velXSmoothing, smoothTime);
		rb.velocity = new Vector2(num2, rb.velocity.y);
		if (debugLogs)
		{
			Debug.Log($"FixedUpdate: inputX={inputX:F2} targetVelX={num:F2} newVelX={num2:F2}");
		}
	}

	private bool IsGrounded()
	{
		if (groundCheck == null)
		{
			return false;
		}
		if (col == null)
		{
			col = GetComponent<Collider2D>();
			if (col == null)
			{
				col = GetComponentInChildren<Collider2D>();
			}
		}
		Collider2D[] array = Physics2D.OverlapCircleAll(groundCheck.position, groundRadius, groundLayer);
		foreach (Collider2D collider2D in array)
		{
			if (!(collider2D == null) && !(collider2D == col) && !collider2D.isTrigger)
			{
				return true;
			}
		}
		return false;
	}

	private void OnDrawGizmos()
	{
		if (groundCheck != null)
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(groundCheck.position, groundRadius);
		}
	}
}
