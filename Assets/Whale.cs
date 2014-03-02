using UnityEngine;
using System.Collections;

public class Whale : MonoBehaviour {

	Vector3 oldPosition;

	// Use this for initialization
	void Start () {
		rigidbody.AddForce(
			10000 * Vector3.Normalize(transform.forward)
			);	
		oldPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		rigidbody.AddForce(
			10000 * Vector3.Normalize(transform.position - oldPosition)
			);	

		rigidbody.AddForce(
			1000 * transform.right
			);	

		rigidbody.transform.LookAt( transform.position + 
		                           Vector3.Normalize(transform.rigidbody.velocity)
		                           );
	
		oldPosition = transform.position;

	}
}
