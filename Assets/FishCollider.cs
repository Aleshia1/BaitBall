using UnityEngine;
using System.Collections;

public class FishCollider : MonoBehaviour {

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Dolphin") {
			rigidbody.position = 10 * Random.insideUnitSphere;
			Score.score += 1;
		}	
	}

	void OnTriggerStay(Collider other) {
		if (other.tag == "Fish") {
			rigidbody.AddForce(
				3f * Vector3.Normalize(rigidbody.position - other.transform.position)
				);
		}
		if (other.tag == "Island") {
			rigidbody.AddForce(3f * Vector3.up);
		}
		if (other.tag == "Water") {
			rigidbody.AddForce(-3f * Vector3.up);
		}

		if (other.tag == "DolphinScare" || other.tag == "SharkScare") {
			rigidbody.AddForce( 
			     10 * Vector3.Normalize(
				rigidbody.position - other.transform.position
				) );
		}

				

	
	}

}
