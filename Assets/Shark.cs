using UnityEngine;
using System.Collections;

public class Shark : MonoBehaviour {

	GameObject dolphin;

	// Use this for initialization
	void Start () {
		dolphin = GameObject.FindGameObjectWithTag("Dolphin");
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance( dolphin.transform.position, transform.position ) > 10) {

		rigidbody.AddForce(
			7000 * Vector3.Normalize(dolphin.transform.position - transform.position)
		);	

		rigidbody.transform.LookAt( transform.position - 
		                           		Vector3.Normalize(transform.rigidbody.velocity)
		                           );
		}
	}

}
