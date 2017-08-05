using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroller : MonoBehaviour {
	// Controls for moving the player object

	// Reference to the player rigidbody
	private Rigidbody rb;
	private int count;
	public float speed;
	public Text countText;
	public Text winText;

	void Start() {
		// Called at the start of the game to initialize rb to 
		// the object we are using.
		rb = GetComponent<Rigidbody>();
		count = 0;
		SetCountText ();
		winText.text = "";
	}

	void FixedUpdate () {
		// Updates physics ingame when we move the player object
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}
		
	void OnTriggerEnter (Collider other) {
		// Sets pickups to inactive on collision
		if (other.gameObject.CompareTag ("Pickup")) {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}
	}

	void SetCountText () {
		countText.text = "Count: " + count.ToString ();
		if (count >= 15) {
			winText.text = "You win!";
		}
	}

}
