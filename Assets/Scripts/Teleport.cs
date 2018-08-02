using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport : MonoBehaviour {

	public Vector2 Destination;

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			SceneManager.LoadScene("Main");
		}
		if (other.gameObject.CompareTag ("Ground")) {
			Destroy (other.gameObject);
		}
	}
}
