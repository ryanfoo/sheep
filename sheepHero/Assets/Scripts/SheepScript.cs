using UnityEngine;
using System.Collections;

/// <summary>
/// Sheep Object behavior
/// </summary>
public class SheepScript : MonoBehaviour {

	//private bool hasSpawn;
	//private MoveScript moveScript;

	void Awake() {
		//moveScript = GetComponent<MoveScript> ();
	}

	void Start() {
//		hasSpawn = false;
//		GetComponent<Collider2D> ().enabled = false;
//		GetComponent<MoveScript> ().enabled = false;

	}

	// Update is called once per frame
	void Update() {
//		if (hasSpawn == false) {
//			Spawn ();
//		}
	}

	private void Spawn()
	{
		// hasSpawn = true;
		GetComponent<Collider2D> ().enabled = true;
		GetComponent<MoveScript> ().enabled = true;
	}
}
