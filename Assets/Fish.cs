using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	public GameObject dolphin;
	public float distanceForceMultiplier;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance(dolphin.transform.position, this.transform.position);
		if (distance < 3) {
			rigidbody.AddForce(
				distanceForceMultiplier * 
				Vector3.Normalize(
					this.transform.position - dolphin.transform.position
				)
				);
		}
	}
}
