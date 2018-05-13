using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	public float speed = 5f;
	public float jumpSpeed = 8f;

	private Rigidbody2D rb;

	private bool facingRight = true;

	// Used for jumping
	private float jumpButtonPressTime;
	private float maxJumpTime = 0.2f;
	private bool onGround = true;

	//Used for Raycasts
	public LayerMask groundLayer;



	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate() {
		
		// Horizontal Movement
		float horzMove = Input.GetAxisRaw ("Horizontal");

		Vector2 vect = rb.velocity;

		rb.velocity = new Vector2 (horzMove * speed, vect.y);

		if (horzMove > 0 && !facingRight) {
			FlipCat ();
		} else if (horzMove < 0 && facingRight) {
			FlipCat ();
		}
			
		// Vertical Movement
		if (Input.GetKeyDown ("space") && IsGrounded ()) {
			rb.AddForce(new Vector2(0, 9), ForceMode2D.Impulse);
        } 
	}
		

	// Requires that all ground object are in the same "ground" layer
	bool IsGrounded() {
		Vector2 position = transform.position;
		Vector2 direction = Vector2.down;
		float distance = 2.0f;

		Debug.DrawRay (position, direction, Color.green);
		RaycastHit2D hit = Physics2D.Raycast (position, direction, distance, groundLayer);

		if (hit.collider != null) {
			return true;
		}

		return false;
	}

	void FlipCat() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1;
		transform.localScale = scale;
	}
		
}
