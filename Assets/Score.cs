using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	public static int score = 0;
	public static float time = 0;

	GUITexture updown;
	GUITexture cardinal;

	void Start() {
		updown = GameObject.FindGameObjectWithTag("GUIUpDown").guiTexture;
		cardinal = GameObject.FindGameObjectWithTag("GUICardinal").guiTexture;
	}

	void OnGUI() {

		GUI.Label(new Rect(10,10,120,20), "Total Fish: " + score);
		GUI.Label(new Rect(10,60,160,20), "Time: " + Mathf.RoundToInt(time));
		GUI.Label(new Rect(10,110,200,20), "Rate: " + score/time + " per second");

	}

	void OnTouch() {
		Debug.Log("touch");
	}

	void FixedUpdate() {
		time += Time.deltaTime;
	}

}
