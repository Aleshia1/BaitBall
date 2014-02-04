using UnityEngine;
using System.Collections;

public class FishSwarm : MonoBehaviour {

	public static int numberInSwarm = 400;
	static ArrayList fishSwarm = new ArrayList(numberInSwarm);
	Fish newFish;

	// Use this for initialization
	void Start () {

		for (int i=0; i<numberInSwarm; i++) {
			Debug.Log("i = " + i);
			newFish = new Fish(i);

			if (newFish == null) {
				Debug.Log("null");
			}
			newFish.myGameObject.transform.position = Random.insideUnitSphere * 2;
			newFish.myGameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Dolphin").transform.position);
//			newFish.myGameObject.tag = System.Convert.ToString(i);

			fishSwarm.Add(newFish);

			newFish.Update();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (fishSwarm == null) {
			Debug.Log ("swarm is null");
			return;
		}

		Vector3 averageDirection;

		for (int i=0; i<numberInSwarm; i++) {

			Debug.Log("i= " + i);
			((Fish)fishSwarm[i]).Update();

		}

	}

	public static Fish getFish(int i) {
		return (Fish) fishSwarm[i];
	}


}
