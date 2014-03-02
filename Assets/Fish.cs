using UnityEngine;

public class Fish {

	GameObject dolphin;
	public GameObject myGameObject;
	public float distanceForceMultiplier;
	Vector3 previousPosition;
	public Vector3 directionOfMovement;
	float distanceToDolphin;
	public float myIndex;

	Animator animator;

	float directionFactor = 1f;
	float positionFactor = 1f;
	float neighborhoodSize = 4f;

	// Use this for initialization

	// Update is called once per frame
	public void Update () {

		animator.SetFloat("Speed", 3);

		// find directions and distances
		directionOfMovement = Vector3.Normalize(myGameObject.transform.rigidbody.velocity);

		myGameObject.rigidbody.transform.LookAt( myGameObject.transform.position + directionOfMovement );

		// move closer to neighbors and go in the same direction
		Collider[] hitColliders = Physics.OverlapSphere(myGameObject.transform.position, 
		                                                neighborhoodSize);
		Vector3 averagePositionOfNeighbors = myGameObject.transform.position;
		Vector3 averageDirectionOfNeighbors = directionOfMovement;
		int numberOfCollidingFish = 0;
		for (int i=0; i<hitColliders.Length; i++) {
			if (hitColliders[i].tag == "Island") {
				myGameObject.rigidbody.AddForce(Vector3.up);
				continue;
			}
			if (hitColliders[i].tag == "Fish") {
				averagePositionOfNeighbors += hitColliders[i].attachedRigidbody.transform.position;
				averageDirectionOfNeighbors += hitColliders[i].attachedRigidbody.transform.forward;
				++numberOfCollidingFish;
			}
		}
		if (numberOfCollidingFish > 0) {
			averagePositionOfNeighbors.x /= (numberOfCollidingFish+1);
			averagePositionOfNeighbors.y /= (numberOfCollidingFish+1);
			averagePositionOfNeighbors.z /= (numberOfCollidingFish+1);

			averageDirectionOfNeighbors.x /= (numberOfCollidingFish+1);
			averageDirectionOfNeighbors.y /= (numberOfCollidingFish+1);
			averageDirectionOfNeighbors.z /= (numberOfCollidingFish+1);

		}

		averageDirectionOfNeighbors = Vector3.Normalize( 
		                                           averageDirectionOfNeighbors );

		myGameObject.transform.rigidbody.AddForce(
			positionFactor * 
			(averagePositionOfNeighbors - myGameObject.transform.position)
			+
			directionFactor *
			averageDirectionOfNeighbors
			);


		// Don't move above water level
		if (myGameObject.transform.position.y >
		     GameObject.FindGameObjectWithTag("Water").transform.position.y) {
			myGameObject.transform.position = 
				new Vector3 (
					myGameObject.transform.position.x,
					GameObject.FindGameObjectWithTag("Water").transform.position.y,
					myGameObject.transform.position.z
					);
		}

//		myGameObject.transform.LookAt(
//				Vector3.Cross (myGameObject.transform.position, 
//		               averageDirectionOfNeighbors)
//			);

		previousPosition = myGameObject.transform.position;

	}

	public Fish(int i) {
		myGameObject = (GameObject) Object.Instantiate(GameObject.FindGameObjectWithTag("Fish"));
//		Debug.Log ("init Fish " + i);
//		myGameObject.tag = System.Convert.ToString(i)+1;
		myIndex = i;
		previousPosition = myGameObject.transform.position;

		dolphin = GameObject.FindGameObjectWithTag("Dolphin");

		myGameObject.transform.rigidbody.velocity 
			= 1 * Random.insideUnitSphere;
//		myGameObject.transform.rotation = Quaternion.identity;

		animator = (Animator) myGameObject.GetComponent("Animator");

	}
	
}
