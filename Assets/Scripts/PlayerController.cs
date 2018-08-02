using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speedGrounded;
	public float speedAir;
	private Vector3 moveDirection = Vector3.zero;

	public float jumpPower;

	/// Gold Picked + Win Text at the End
	public Text countText;
	public Text winText;
	private int count;
	///
	public float maxSpeed;
	private bool isGrounded;
	private Rigidbody2D rb2d;

	public float timeToDestroy = 2.0F;

	void Start(){
		rb2d = GetComponent<Rigidbody2D> ();
		count = 0;
		SetCountText ();
		isGrounded = false;
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		rb2d.AddForce (movement * speedAir);

		if (isGrounded) {
			rb2d.AddForce (movement * speedGrounded);
		}

		if(rb2d.velocity.magnitude > maxSpeed)
		{
			rb2d.velocity = rb2d.velocity.normalized * maxSpeed;
		}
	}

	void Update()
	{
		if (isGrounded && Input.GetButtonDown("Jump")) {
				rb2d.AddForce (Vector2.up * jumpPower);
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Ground")) {
			transform.parent = null;
			isGrounded = true;
		}
		if (other.gameObject.CompareTag ("FallingPlatform")) {
			Destroy (other.gameObject, timeToDestroy);
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag("PlatformTag") || other.gameObject.CompareTag("FallingPlatform")) {
			isGrounded = false;
		}
	}

	void OnCollisionStay2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Ground") || other.gameObject.CompareTag("PlatformTag") || other.gameObject.CompareTag("FallingPlatform")) {
			isGrounded = true;
		}
		if (other.gameObject.CompareTag ("PlatformTag")) {
			transform.parent = other.transform;
		}
	}
	// Coin Collector via ColliderCode

	void OnTriggerEnter2D(Collider2D other)	{
		if (other.gameObject.CompareTag ("PickUp"))
		{
			other.gameObject.SetActive (false);
			count += 1;
			SetCountText ();
		}
	}

	void SetCountText(){
		countText.text = "Count: " + count.ToString ();
	}
}
