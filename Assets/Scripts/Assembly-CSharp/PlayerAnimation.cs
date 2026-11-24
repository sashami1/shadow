using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	private Rigidbody2D rb;

	private Animator anim;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponentInChildren<Animator>();
		if (anim == null)
		{
			Debug.LogError("Агов! На об'єкті 'Без назви' немає компонента Animator! Додай його.");
		}
	}

	private void Update()
	{
		if (!(anim == null) && !(rb == null))
		{
			anim.SetFloat("Speed", Mathf.Abs(rb.linearVelocity.x));
			bool value = Mathf.Abs(rb.linearVelocity.y) > 2.0f;
			anim.SetBool("IsJumping", value);
		}
	}
}
