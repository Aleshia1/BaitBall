using UnityEngine;
using System.Collections;

public class Dolphin : MonoBehaviour {
	
	public float distanceForceMultiplier;
	public Transform dolphinTransform;

	GameObject water;
	public static GameObject blood;

	// Use this for initialization
	void Start () {
		water = GameObject.FindGameObjectWithTag("Water");
		blood = GameObject.FindGameObjectWithTag("DolphinBlood");
		Dolphin.blood.SetActive(false);

		dolphinTransform = GetDolphinTransform();

	}


	void LateUpdate() {
		// reorient yourself

		dolphinTransform = GetDolphinTransform();

		Camera.main.transform.LookAt(dolphinTransform.position + dolphinTransform.forward);
		Camera.main.transform.position = dolphinTransform.position
			- dolphinTransform.forward + dolphinTransform.up;

	}

	Transform GetDolphinTransform() {
		dolphinTransform = transform;
//		dolphinTransform.forward = - transform.up;
//		dolphinTransform.up = transform.forward;
		return dolphinTransform;
	}
	
	// Update is called once per frame
	void Update () {

		dolphinTransform = GetDolphinTransform();

		if (Input.GetKey(KeyCode.UpArrow)) {
//			gameObject.GetComponent("Animator").animation = 
			if (Input.GetKey(KeyCode.LeftShift)) {

				//	Don't move above water level
				if (dolphinTransform.position.y > water.transform.position.y) {
					dolphinTransform.position = 
						new Vector3 (
							transform.position.x,
							water.transform.position.y,
							transform.position.z
							);
				} else {
					rigidbody.AddForce(10000 * dolphinTransform.up);
				}
			} else {

				rigidbody.AddForce(10000 * dolphinTransform.forward);
			}
		} 
		if (Input.GetKey(KeyCode.DownArrow)) {
			if (Input.GetKey(KeyCode.LeftShift)) {
				rigidbody.AddForce(- 10000 * dolphinTransform.up);
			} else {
				rigidbody.AddForce(- 10000 * dolphinTransform.forward);
			}
		} 
		if (Input.GetKey(KeyCode.RightArrow)) {
			dolphinTransform.RotateAround(
				dolphinTransform.position,dolphinTransform.up,10);
		} 
		if (Input.GetKey(KeyCode.LeftArrow)) {
			dolphinTransform.RotateAround(
				dolphinTransform.position,dolphinTransform.up,-10);
		}



//		dolphinTransform.LookAt( dolphinTransform.position + -dolphinTransform.up );




		
	}

}
