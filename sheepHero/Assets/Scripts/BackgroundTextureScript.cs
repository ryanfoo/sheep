﻿using UnityEngine;
using System.Collections;

public class BackgroundTextureScript : MonoBehaviour {

	// Color variants
	public Color morningColor   = new Color (0.875f, 0.722f, 0.384f);
	public Color afternoonColor = Color.white;
	public Color sunsetColor 	= new Color (0.933f, 0.549f, 0.376f);
	public Color nightColor 	= new Color (0.447f, 0.655f, 0.898f);
	public Color eveningColor 	= new Color (0.396f, 0.42f, 0.596f);
	public Color currentColor, nextColor;

	// Array variables
	public Color[] colorArray = new Color[5];
	private int colorIdx = 0;
	public float[] filterValArray = new float[5];
	public static float currentFilter;

	// Timing variables
	public float duration = 60.0f;
	private float t;
	private float lerpTime = 1f;

	void Start () 
	{
		// Initialize color array
		colorArray [0] = morningColor;
		colorArray [1] = afternoonColor;
		colorArray [2] = sunsetColor;
		colorArray [3] = nightColor;
		colorArray [4] = eveningColor;

		// Start at morning color
		GetComponent<Renderer> ().material.color = morningColor;
		currentColor = morningColor;
		nextColor = afternoonColor;

		// Initialize filter array
		filterValArray [0] = 5000.0f;
		filterValArray [1] = 20000.0f;
		filterValArray [2] = 15000.0f;
		filterValArray [3] = 2000.0f/2;
		filterValArray [4] = 1000.0f/2;

		currentFilter = filterValArray [0];
	}
	
	void Update () 
	{
		//update time warp
		float durationUpdated = duration / SheepClockAnimator.speed;

		// If not next color, set t to 0
		if (currentColor != nextColor) 
		{
			t = 0f;
		}

		// increment t
		t += Time.time;

		// set to 1 if t is greater than 1 (lerp time is between 0 and 1)
		if (t > lerpTime) 
		{
			t = lerpTime;
		}

		// Find next color
		for (int i = 0; i < colorArray.Length; i++)
		{
			// Get the currentColor in the Array
			if (currentColor == colorArray[i])
			{
				colorIdx = i + 1 == colorArray.Length ? 0 : i + 1;
			}
		}
		// Set current filter
		currentFilter = filterValArray [colorIdx];
		//Adjust for depth of filter 
		if (colorIdx != 1 && colorIdx != 2) {
			currentFilter = currentFilter/GenerateSheepScript.depthAmount;
		}  

		// Set next color
		nextColor = colorArray[colorIdx];
		// Lerp colors
		currentColor = Color.Lerp (currentColor, nextColor, (t/lerpTime)/durationUpdated);
		// Set new color
		GetComponent<Renderer> ().material.color = currentColor;
	}

	void OnAudioFilterRead (float[] data, int channels)
	{		
		for (var i = 0; i < data.Length; i = i + channels) {
			// the absolute value of every sample
			float absInput = Mathf.Abs(data[i]);
			// smoothening filter doing its thing
			filterValArray[colorIdx] = ((0.01f * absInput) + (0.99f * filterValArray[colorIdx+1]));
			// exaggerating the amplitude
			// amp = filterValArray[colorIdx]*7;
			// it is a recursive filter, so it is doing its recursive thing
			filterValArray[colorIdx+1] = filterValArray[colorIdx];
		}
	}
}
