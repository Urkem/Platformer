using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour {

	private Rigidbody2D rb2d;
	public float FallDelay;
	/*public float mass;
	public float gravity;*/
	[SerializeField] float downScaler = 50f;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.CompareTag("Player"))
		{
			StartCoroutine(Fall());
		}
	}


	IEnumerator Fall()
	{
		yield return new WaitForSeconds(FallDelay);
		rb2d.isKinematic = false;
		rb2d.AddForce(Vector2.down * downScaler);
		yield return 0;
	}}
