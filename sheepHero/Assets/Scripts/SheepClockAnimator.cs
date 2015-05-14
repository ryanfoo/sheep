using UnityEngine;
using System;


public class SheepClockAnimator : MonoBehaviour {
	
	
	private const float
		hoursToDegrees = 360f / 12f,
		minutesToDegrees = 360f / 60f;


	public bool randomOn = false;
	
	//objects for clock hands
	public Transform hourHand, minuteHand;


	public int minuteIndex = 0;
	public int hourIndex = 0;
	
	public static int speed = 1;



	void Update () {
		//Time Warping
		//downspeed
		if (Input.GetKeyDown(KeyCode.Z) && speed >= 2 && speed > 64) {
			speed = speed / 2 + speed;
		}
		else if (Input.GetKeyDown(KeyCode.Z) && speed >= 2 && speed <= 64) {
			speed = speed / 2;
		}
		//upspeed
		else if (Input.GetKeyDown(KeyCode.X) && speed <= 256 && speed >= 64) {
			speed = speed * 2 - speed;
		}
		else if (Input.GetKeyDown(KeyCode.X) && speed <= 256 && speed < 64) {
			speed = speed * 2;
		}
		//Filter Stuff
		//'C' Down Resonance
		if (Input.GetKeyDown (KeyCode.C) && GenerateSheepScript.resonance >= 2) {
			GenerateSheepScript.resonance = GenerateSheepScript.resonance - 1;
			//Debug.Log (GenerateSheepScript.resonance);;
		}
		//'V' Up Resonance
		if (Input.GetKeyDown (KeyCode.V) && GenerateSheepScript.resonance <= 8) {
			GenerateSheepScript.resonance = GenerateSheepScript.resonance + 1;
			//Debug.Log (GenerateSheepScript.resonance);
		}
		//'B' Down Depth
		if (Input.GetKeyDown (KeyCode.B) && GenerateSheepScript.depthAmount >= 2) {
			GenerateSheepScript.depthAmount = GenerateSheepScript.depthAmount - 1;
			Debug.Log (GenerateSheepScript.depthAmount);
		}
		//'N' Down Depth
		if (Input.GetKeyDown (KeyCode.N) && GenerateSheepScript.depthAmount <= 9) {
			GenerateSheepScript.depthAmount = GenerateSheepScript.depthAmount + 1;
			Debug.Log (GenerateSheepScript.depthAmount);
		}

		//Random Button
		if (Input.GetKeyDown (KeyCode.M)) {
			randomOn = !randomOn;
		}


		minuteIndex++;
		
		if (minuteIndex % 59 == 0) {
			hourIndex++;
			minuteIndex = 0;
		}

		
		if (hourIndex % 23 == 0) 
			hourIndex = 0;
		
		hourHand.localRotation = Quaternion.Euler(0f, 0f,  (speed) * hourIndex *  -hoursToDegrees);
		minuteHand.localRotation = Quaternion.Euler(0f, 0f,  (speed) * minuteIndex * -minutesToDegrees);

	}
}