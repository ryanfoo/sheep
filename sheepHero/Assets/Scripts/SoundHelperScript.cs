using UnityEngine;
using System.Collections;

public class SoundHelperScript : MonoBehaviour {

	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundHelperScript Instance;

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

	public void MakeSheepSound(AudioClip sheepSound)
	{
		MakeSound (sheepSound);
	}

	/// <summary>
	/// Play a given sound
	/// </summary>
	/// <param name="originalClip"></param>
	private void MakeSound(AudioClip originalClip)
	{
		// As it is not 3D audio clip, position doesn't matter.
		AudioSource.PlayClipAtPoint(originalClip, transform.position, 0.3f);
	}
}
