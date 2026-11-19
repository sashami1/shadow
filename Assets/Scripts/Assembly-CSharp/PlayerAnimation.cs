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
			anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
			bool value = Mathf.Abs(rb.velocity.y) > 0.1f;
			anim.SetBool("IsJumping", value);
		}
	}
}
