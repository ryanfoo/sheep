using UnityEngine;
using System.Collections;

public class GenerateSheepScript : MonoBehaviour {

	// Sheep Object
	public Transform sheepPrefab;
	// Temp Object
	Transform newObject;
	// Generate random numbers
	private Vector3 v;
	// Random #
	private float rand;
	// Sound
	private AudioClip sound;	
	// Sound Interval
	private float time;
	public AudioSource src;

	// Use this for initialization
	void Start () {
		time = 5.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (newObject.position.x > 4.0f) {
			Destroy (newObject.gameObject);
			Destroy (sound);		
			CancelInvoke ();
		}
	}

	public void generateSheep(AudioClip sheepSound)
	{
		rand = Random.Range (-0.6f, 0.6f);
		if (rand < 0.0f) v = new Vector3 (0, rand, rand-2.0f);
		else v = new Vector3 (0, rand, rand+2.0f);
		// Create new sheep
		var sheepTransform = Instantiate (sheepPrefab) as Transform;
		// Assign Position
		sheepTransform.position = transform.position + v;

		// Scale the White Sheep
		if (sheepTransform.name == "sheep_cute(Clone)") {
			if (rand < 0) 
			{
				sheepTransform.localScale += new Vector3 (transform.localScale.x * Mathf.Abs (rand), 
				                                          transform.localScale.y * Mathf.Abs (rand), 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
			}
			else
			{
				sheepTransform.localScale -= new Vector3 (transform.localScale.x * Mathf.Abs (rand), 
				                                          transform.localScale.y * Mathf.Abs (rand), 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
			}
		} 
		// Scale the Black Sheep, funky scaling because the two sheep images are totally different sizes...
		else if (sheepTransform.name == "sheep_black(Clone)") {
			if (rand < 0) 
			{
				sheepTransform.localScale += new Vector3 (transform.localScale.x * Mathf.Abs (rand-0.1f) * 0.1f + 0.0125f, 
				                                          transform.localScale.y * Mathf.Abs (rand-0.1f) * 0.1f + 0.0125f, 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
			}
			else
			{
				sheepTransform.localScale -= new Vector3 (transform.localScale.x * Mathf.Abs (rand-0.1f) * 0.1f - 0.01f, 
				                                          transform.localScale.y * Mathf.Abs (rand-0.1f) * 0.1f - 0.01f, 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
			}
		}

		src = sheepTransform.GetComponent<AudioSource> ();
		src.clip = sheepSound;
		newObject = sheepTransform;
		// Set sound to be played
		sound = sheepSound;

		InvokeRepeating ("MakeSound", 0.01f, time);
		if (sheepTransform.position.x < -4.5f) {
			Destroy (sheepTransform.gameObject);
		}
	}

	/// Play a given sound
	private void MakeSound()
	{
		// As it is not 3D audio clip, position doesn't matter.
		src.transform.position = newObject.transform.position;
		src.Play ();
	}
}
