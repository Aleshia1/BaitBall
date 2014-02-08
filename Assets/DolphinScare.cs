using UnityEngine;

public class DolphinScare : MonoBehaviour {

	GameObject dolphin;

	// Use this for initialization
	void Start () {
		dolphin = GameObject.FindGameObjectWithTag("Dolphin");
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = dolphin.transform.position;
		transform.rotation = dolphin.transform.rotation;
	}

}
