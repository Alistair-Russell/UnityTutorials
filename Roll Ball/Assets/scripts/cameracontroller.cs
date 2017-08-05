using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour {

	// Reference to the player game object
	public GameObject player;

	// Offset for camera/player
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame AFTER UPDATE
	// We use LateUpdate because we know that the player has definitely
	// moved by the time this gets called.
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
