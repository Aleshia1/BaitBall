using UnityEngine;
using System.Collections;

public class Fish {

	GameObject dolphin;
	public GameObject myGameObject;
	public float distanceForceMultiplier;
	Vector3 previousPosition;
	public Vector3 directionOfMovement;
	Vector3 directionDolphinToFish;
	float distanceToDolphin;
	float distanceOfLastMovement;
	public float myIndex;

	// Use this for initialization

	// Update is called once per frame
	public void Update () {

		// find directions and distances
		directionOfMovement = Vector3.Normalize(myGameObject.transform.position - previousPosition);
		distanceOfLastMovement = Vector3.Distance(myGameObject.transform.position, previousPosition);

		distanceToDolphin = Vector3.Distance(dolphin.transform.position, myGameObject.transform.position);
		directionDolphinToFish = Vector3.Normalize( 
		                                           myGameObject.transform.position - dolphin.transform.position);

		// Get away from dolphin
		if (distanceToDolphin < 3) {
			myGameObject.rigidbody.AddForce(
				distanceForceMultiplier * directionDolphinToFish
				);
		}


		// look where you're going
		if (distanceOfLastMovement > 0.1) {
			// reorient yourself
			myGameObject.transform.LookAt(myGameObject.transform.position + directionOfMovement);
			myGameObject.transform.Rotate(-90, 0, 0);

		}

		previousPosition = myGameObject.transform.position;


		// move closer to neighbors
		Collider[] hitColliders = Physics.OverlapSphere(myGameObject.transform.position, 1);
		Vector3 averagePositionOfNeighbors = myGameObject.transform.position;
		Vector3 averageDirectionOfNeighbors = directionOfMovement;
		for (int i=0; i<hitColliders.Length; i++) {
			averagePositionOfNeighbors += hitColliders[i].rigidbody.transform.position;
			directionOfMovement += hitColliders[i].rigidbody.transform.forward;
		}
		if (hitColliders.Length > 0) {
			averagePositionOfNeighbors.x /= (hitColliders.Length+1);
			averagePositionOfNeighbors.y /= (hitColliders.Length+1);
			averagePositionOfNeighbors.z /= (hitColliders.Length+1);

			directionOfMovement.x /= (hitColliders.Length+1);
			directionOfMovement.y /= (hitColliders.Length+1);
			directionOfMovement.z /= (hitColliders.Length+1);
		}

//		Debug.Log ("average position is " + averagePositionOfNeighbors + " and direction: " + averageDirectionOfNeighbors);

		// move in same direction as neighbors

		
	}

	public Fish(int i) {
		myGameObject = (GameObject) Object.Instantiate(GameObject.FindGameObjectWithTag("Fish"));
//		Debug.Log ("init Fish " + i);
//		myGameObject.tag = System.Convert.ToString(i)+1;
		myIndex = i;
		previousPosition = myGameObject.transform.position;

		dolphin = GameObject.FindGameObjectWithTag("Dolphin");
	}



}
