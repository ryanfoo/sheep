using UnityEngine;
using System.Collections;

public class BeatSynchronizerScript : MonoBehaviour {

	public float bpm = 100f;
	public float startDelay = 1f;
	/*
	 * BPM Formula:
	float scale = 1 + Mathf.Cos(Time.time  (bpm / 60)  Mathf.PI * 2);
	transform.localScale = new Vector3(scale, scale, scale);
	*/
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
