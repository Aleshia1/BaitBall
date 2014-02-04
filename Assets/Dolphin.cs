using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
	
	public float distanceForceMultiplier;
	Vector3 previousPosition;
	Vector3 directionOfMovement;
	float distanceOfLastMovement;
	
	// Use this for initialization
	void Start () {
		previousPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
		directionOfMovement = Vector3.Normalize(transform.position - previousPosition);
		distanceOfLastMovement = Vector3.Distance(transform.position, previousPosition);
		
		if (distanceOfLastMovement > 0.1) {
			// reorient yourself
//			transform.LookAt(transform.position + directionOfMovement);

			Vector3 newPosition = transform.position + directionOfMovement;
			Quaternion newRotation = Quaternion.LookRotation(newPosition);
			transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 100);


			transform.Rotate(-90, 0, 0);

		}
		
		previousPosition = transform.position;
		
		
	}
}
