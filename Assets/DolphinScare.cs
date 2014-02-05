using UnityEngine;
using System.Collections;

public class DolphinScare : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GameObject.
			FindGameObjectWithTag("Dolphin").transform.position;
	}

	void OnTriggerStay(Collider fish) {

		fish.rigidbody.AddForce( 3 * 
		                        Vector3.Normalize(

			fish.transform.position - transform.position
			)

		                        );

	}
}
