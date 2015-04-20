using UnityEngine;
using System.Collections;

/// <summary>
/// Sheep Object behavior
/// </summary>
public class SheepScript : MonoBehaviour {

	/// <summary>
	/// Speed of the sheep
	/// </summary>
	public Vector2 speed = new Vector2(1,1);

	// Direction movement 
	// Sync with tempo grid
	public Vector2 direction = new Vector2 (0,1);

	// Store Movement
	private Vector2 movement;
	

	// Update is called once per frame
	void Update () {
		// Retrieve axis information
		// float inputX = Input.GetAxis ("Horizontal");
		// float inputY = Input.GetAxis ("Vertical");
		// Movement per direction
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// GetComponent.rigidbody2D.velocity = movement;
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
