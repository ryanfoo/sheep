using UnityEngine;
using System.Collections;

public class GenerateSheepScript : MonoBehaviour {

	// Sheep Object
	public Transform sheepPrefab;
	// Temp Object
	Transform newObject;
	// Sheep Generate status
	public static bool[] sheepCanGenerate = new bool[48];
	// Sheep Array
	public static Transform[] sheepArray = new Transform[48];
	// Sheep Index
	public static int sheepIndex = 0;
	// Generate random numbers
	private Vector3 v;
	// Random #
	private float rand;
	// Sound Interval
	private float time;
	// Source
	public AudioSource src;
	//Low-pass filter parameters
	public static int resonance = 5;
	public static int depthAmount = 1;

	// Use this for initialization
	void Start () {
		time = 5.0f;
		for (int i = 0; i < 48; i++) {
			sheepCanGenerate[i] = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (newObject == null) {

		}
		else if (newObject.position.x > 4.0f) {
			DestroyImmediate (newObject.gameObject, true);
			CancelInvoke ();
			sheepCanGenerate[sheepIndex] = true;
		}

		if (sheepIndex == 48) {
			sheepIndex = 0;
		}
		for (int i = 0; i < 48; i++) {
			if (sheepArray[i] != null) {
				if (sheepArray[i].position.x > 4.0f) {
					DestroyImmediate (sheepArray[i].gameObject, true);
					CancelInvoke ();
					sheepCanGenerate[i] = true;
				}
				else {
					sheepArray[i].GetComponent<AudioLowPassFilter> ().cutoffFrequency = BackgroundTextureScript.currentFilter;
					sheepArray[i].GetComponent<AudioLowPassFilter> ().lowpassResonanceQ = resonance;
					// Debug.Log (sheepArray[i].name + "'s cutoff hz: " + BackgroundTextureScript.currentFilter);
				}
			}
			if (sheepArray[i] == null) {
				sheepCanGenerate[i] = true;
			}
		}
	}

	public void generateSheep(AudioClip sheepSound)
	{
		if (sheepCanGenerate [sheepIndex]) {
			rand = Random.Range (-0.5f, 0.5f);
			if (rand < 0.0f)
				v = new Vector3 (0, rand, rand - 1.0f);
			else
				v = new Vector3 (0, rand, rand + 1.0f);
			// Create new sheep
			var sheepTransform = Instantiate (sheepPrefab) as Transform;
			// Assign Position
			sheepTransform.position = transform.position + v;

			// Scale the White Sheep
			if (sheepTransform.name == "sheep_cute(Clone)") {
				if (rand < 0) {
					sheepTransform.localScale += new Vector3 (transform.localScale.x * Mathf.Abs (rand), 
				                                          transform.localScale.y * Mathf.Abs (rand), 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
				} else {
					sheepTransform.localScale -= new Vector3 (transform.localScale.x * Mathf.Abs (rand), 
				                                          transform.localScale.y * Mathf.Abs (rand), 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
				}
			} 
		// Scale the Black Sheep, funky scaling because the two sheep images are totally different sizes...
		else if (sheepTransform.name == "sheep_black(Clone)") {
				if (rand < 0) {
					sheepTransform.localScale += new Vector3 (transform.localScale.x * Mathf.Abs (rand - 0.1f) * 0.1f + 0.0125f, 
				                                          transform.localScale.y * Mathf.Abs (rand - 0.1f) * 0.1f + 0.0125f, 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
				} else {
					sheepTransform.localScale -= new Vector3 (transform.localScale.x * Mathf.Abs (rand - 0.1f) * 0.1f - 0.01f, 
				                                          transform.localScale.y * Mathf.Abs (rand - 0.1f) * 0.1f - 0.01f, 
				                                          transform.localScale.z + (1.5f * Mathf.Abs (rand)));
				}
			}
		
			// Set Prefab settings
			sheepTransform.name = "sheep" + sheepIndex;
			src = sheepTransform.GetComponent<AudioSource> ();
			src.clip = sheepSound;
			sheepTransform.gameObject.AddComponent<AudioLowPassFilter> ();
			// BackgroundTextureScript background = GetComponent<BackgroundTextureScript> ();
			sheepTransform.GetComponent<AudioLowPassFilter> ().cutoffFrequency = BackgroundTextureScript.currentFilter;
			sheepTransform.GetComponent<AudioLowPassFilter> ().lowpassResonanceQ = resonance;
			// Set to new object
			newObject = sheepTransform;
			// Add to sheep array
			sheepArray [sheepIndex] = newObject;
			// Invoke repeating sounds
			InvokeRepeating ("MakeSound", 0.01f, time);
			// Make sure sheep doesn't go out of bounds
			if (sheepTransform.position.x < -4.5f) {
				Destroy (sheepTransform.gameObject);
			}
			// Set false status for generation
			sheepCanGenerate [sheepIndex] = false;
			sheepIndex++;
		} else {
			Debug.Log ("Sheep can no longer be produced!");
		}
	}

	/// Play a given sound
	private void MakeSound()
	{
		if (src != null) {
			src.transform.position = newObject.transform.position;
			src.Play ();
		} else {
			Debug.Log ("Trying to access a non-existing AudioSource I see... well that's not gonna work!");
		}
	}
}
