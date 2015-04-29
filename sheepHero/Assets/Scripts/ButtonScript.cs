using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {

	public static ButtonScript Instance;

	// Insert Key Input 
	public KeyCode keyInput = KeyCode.T;
	// Sounds
	public AudioClip sheepSound;

	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	// Initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		bool buttonPressed = Input.GetKeyDown (keyInput);

		if (buttonPressed) {
			GenerateSheepScript sheep = GetComponent<GenerateSheepScript> ();
			if (sheep != null)
			{
				sheep.generateSheep();
		    }
			SoundHelperScript.Instance.MakeSheepSound (sheepSound);
		}
	}
}
