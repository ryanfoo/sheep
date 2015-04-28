using UnityEngine;
using System.Collections;

/// <summary>
/// Sheep Object behavior
/// </summary>
public class SheepScript : MonoBehaviour {

	/*
	 * BPM Formula:
	float scale = 1 + Mathf.Cos(Time.time  (bpm / 60)  Mathf.PI * 2);
	transform.localScale = new Vector3(scale, scale, scale);
	*/

	// BPM 100 gives us -0.5
	// private float scale = 1 + Mathf.Cos (/*Time.time * */(100 / 60) * Mathf.PI * 2);

	/// Speed of the sheep
	public Vector2 speed = new Vector2(0,0.5f);

	// Direction movement 
	// Sync with tempo grid
	public Vector2 direction = new Vector2 (0,1);

	// Store Movement
	private Vector2 movement;
	
	void Start() 
	{
		// Replace with sheep sound
		SoundHelperScript.Instance.MakeSheepSound();
		Destroy (gameObject, 5.3f);
	}

	// Update is called once per frame
	void Update()
	{
		// replace with actual input
		// Sheep Creation
		bool isCreated = Input.GetButtonDown ("key");
		isCreated = Input.GetButtonDown ("key");

		if (isCreated) {
			SoundHelperScript.Instance.MakeSheepSound();
		}

		// Movement per direction
		movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
	}

	void FixedUpdate()
	{
		// GetComponent.rigidbody2D.velocity = movement;
		GetComponent<Rigidbody2D> ().velocity = movement;
	}
}
