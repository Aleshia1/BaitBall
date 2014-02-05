using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
	
	public float distanceForceMultiplier;
	Vector3 previousPosition;
	Vector3 directionOfMovement;
	float distanceOfLastMovement;
	GameObject ocean;

	Vector3 Up;
	Vector3 Right;
	Vector3 Forward;
	
	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
		ocean = GameObject.FindGameObjectWithTag("Ocean");
		Up = transform.up;
		Right = transform.right;
		Forward = transform.forward;
	}
	
	// Update is called once per frame
	void Update () {

		Up = Vector3.up;
		Forward = transform.up;

		directionOfMovement = Vector3.Normalize(transform.position - previousPosition);
		distanceOfLastMovement = Vector3.Distance(transform.position, previousPosition);
		
		if (distanceOfLastMovement > 0.1) {
			// reorient yourself
//			transform.LookAt(transform.position + directionOfMovement);

//			Vector3 newPosition = transform.position + directionOfMovement;
//			Quaternion newRotation = Quaternion.LookRotation(newPosition);
//			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 100);


//			transform.Rotate(-90, 0, 0);

		}
		
		previousPosition = transform.position;

		Debug.Log ("forward is " + transform.forward);
		Debug.Log ("up is " + transform.up);
		Debug.Log ("right is " + transform.right);

		Debug.Log ("forward is " + Forward);
		Debug.Log ("up is " + Up);
		Debug.Log ("right is " + Right);

		if (Input.GetKey(KeyCode.UpArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {
				transform.rigidbody.AddForce(10000 * Up);
			} else {
				transform.rigidbody.AddForce(10000 * Forward);
			}
		} 
		if (Input.GetKey(KeyCode.DownArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {
				transform.rigidbody.AddForce(- 10000 * Up);
			} else {
				transform.rigidbody.AddForce(- 10000 * Forward);
			}
		} 
		if (Input.GetKey(KeyCode.RightArrow)) {
			transform.RotateAround(
				transform.position,Up,10);
		} 
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.RotateAround(
				transform.position,Up,-10);
		}
		
	}

}
