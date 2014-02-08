using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
	
	public float distanceForceMultiplier;

	GameObject water;

	// Use this for initialization
	void Start () {
		water = GameObject.FindGameObjectWithTag("Water");
	}


	void LateUpdate() {
		// reorient yourself
		Camera.main.transform.LookAt(transform.position + transform.forward);
		Camera.main.transform.position = transform.position - transform.forward + transform.up;

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {

				//	Don't move above water level
				if (transform.position.y > water.transform.position.y) {
						transform.position = 
						new Vector3 (
							transform.position.x,
							water.transform.position.y,
							transform.position.z
							);
					Debug.Log ("here");
				} else {
					transform.rigidbody.AddForce(10000 * transform.up);
				}
			} else {
				transform.rigidbody.AddForce(10000 * transform.forward);
			}
		} 
		if (Input.GetKey(KeyCode.DownArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {
				transform.rigidbody.AddForce(- 10000 * transform.up);
			} else {
				transform.rigidbody.AddForce(- 10000 * transform.forward);
			}
		} 
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.RotateAround(
				transform.position,transform.up,10);
		} 
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.RotateAround(
				transform.position,transform.up,-10);
		}



		rigidbody.transform.LookAt( transform.position + transform.forward );


		
	}

}
