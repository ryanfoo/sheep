using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {

	/// Speed of the sheep
	public Vector2 speed = new Vector2(1,0.8f);
	
	// Direction movement 
	// Sync with tempo grid
	public Vector2 direction = new Vector2 (0,1);
	
	// Store Movement
	private Vector2 movement;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		// Movement per direction
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		GetComponent<Rigidbody2D> ().velocity = movement;
	}

}
