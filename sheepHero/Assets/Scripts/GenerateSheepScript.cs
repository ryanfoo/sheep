using UnityEngine;
using System.Collections;

public class GenerateSheepScript : MonoBehaviour {

	public Transform sheepPrefab;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void generateSheep()
	{
		// Create new sheep
		var sheepTransform = Instantiate (sheepPrefab) as Transform;
		// Assign Position
		sheepTransform.position = transform.position;

		// The is sheep property
		SheepScript sheep = sheepTransform.gameObject.GetComponent<SheepScript>();
		if (sheep != null)
		{

		}
		// Destroys sheep object in 5.3 seconds
		Destroy (sheepTransform.gameObject, 5.3f);
	}
}
