using UnityEngine;
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

	// Timing variables
	public float duration = 60.0f;
	private float t;
	private float lerpTime = 1f;

	// Start at morning color
	void Start () 
	{
		colorArray [0] = morningColor;
		colorArray [1] = afternoonColor;
		colorArray [2] = sunsetColor;
		colorArray [3] = nightColor;
		colorArray [4] = eveningColor;

		GetComponent<Renderer> ().material.color = morningColor;
		currentColor = morningColor;
		nextColor = afternoonColor;
	}
	
	void Update () 
	{
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
		// Set next color
		nextColor = colorArray[colorIdx];
		// Lerp colors
		currentColor = Color.Lerp (currentColor, nextColor, (t/lerpTime)/duration);
		// Set new color
		GetComponent<Renderer> ().material.color = currentColor;
	}
}
