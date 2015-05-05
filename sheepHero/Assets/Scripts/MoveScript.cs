using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	/// Speed of the sheep
	public Vector2 speed = new Vector2(0.8f,0.5f);
	
	// Direction movement 
	// Sync with tempo grid
	public Vector2 direction = new Vector2 (1,0);
	
	// Store Movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
		if (direction.y == 0.4f) {
			direction.y = -0.4f;
		} else {
			direction.y = 0.4f;
		}
		// Movement per direction
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}

}
