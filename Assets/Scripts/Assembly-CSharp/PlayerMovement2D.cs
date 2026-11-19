using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
	[Header("Настройки")]
	public float speed = 5f;

	public float jumpForce = 10f;

	[Header("Земля (Ground Check)")]
	public Transform groundCheck;

	public float checkRadius = 0.2f;

	public LayerMask groundLayer;

	private Rigidbody2D rb;

	private bool isGrounded;

	private float moveInput;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
		moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		Vector3 localScale = base.transform.localScale;
		if (moveInput > 0f)
		{
			localScale.x = Mathf.Abs(localScale.x);
			base.transform.localScale = localScale;
		}
		else if (moveInput < 0f)
		{
			localScale.x = 0f - Mathf.Abs(localScale.x);
			base.transform.localScale = localScale;
		}
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
		}
	}

	private void OnDrawGizmosSelected()
	{
		if (groundCheck != null)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
		}
	}
}
