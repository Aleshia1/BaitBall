using UnityEngine;

public class SharkScare : MonoBehaviour {
	
	GameObject shark;
	
	// Use this for initialization
	void Start () {
		shark = GameObject.FindGameObjectWithTag("Shark");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = shark.transform.position;
		transform.rotation = shark.transform.rotation;
	}


	void OnTriggerStay(Collider other) {
		if (other.tag == "Whale") {
			shark.rigidbody.AddForce(
				150000f * Vector3.Normalize(shark.rigidbody.position - other.transform.position)
				);
		}
		if (other.tag == "Island") {
			shark.rigidbody.AddForce(3000f * Vector3.up);
		}
		
		if (other.tag == "Water") {
			shark.rigidbody.AddForce(-3000f * Vector3.up);
		}
		
		if (other.tag == "Dolphin") {
			shark.rigidbody.AddForce(
				7000f * Vector3.Normalize(other.transform.position - shark.rigidbody.position)
				);
		}

		shark.rigidbody.transform.LookAt( transform.position - 
		                           Vector3.Normalize(shark.transform.rigidbody.velocity)
		                           );
		
		
	}

	
}
