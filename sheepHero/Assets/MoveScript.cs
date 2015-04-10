using UnityEngine;
using System.Collections;

/// <summary>
/// Moves a sheep game object (woo!!!)
/// </summary>
public class MoveScript : MonoBehaviour {

	/// <summary>
	/// Object Speed
	/// We can have user input decide what this is
	/// </summary>
	public Vector2 speed = new Vector2(10,10);

	/// <summary>
	/// Moving Direction
	/// Going down 1 space
	/// </summary>
	public Vector2 direction = new Vector2(0, -1);

	private Vector2 movement;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Movement
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// Apply movement to rigidbody
		// Rigidbody2D.velocity = movement;
	}
}
