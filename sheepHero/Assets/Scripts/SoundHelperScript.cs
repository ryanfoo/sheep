using UnityEngine;
using System.Collections;

public class SoundHelperScript : MonoBehaviour {

	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundHelperScript Instance;

	// Temporary, replace with sheepSound
	public AudioClip playerShotSound;
	
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SoundEffectsHelper!");
		}
		Instance = this;
	}

	// This function is called by an object
	public void MakePlayerShotSound()
	{
		MakeSound(playerShotSound);
	}
	
	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}
