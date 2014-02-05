using UnityEngine;
using System.Collections;

public class FishSwarm : MonoBehaviour {

	public static int numberInSwarm = 250;
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
			newFish.myGameObject.transform.position = Random.insideUnitSphere * 5;
//			newFish.myGameObject.transform.LookAt(GameObject.FindGameObjectWithTag("Dolphin").transform.position);

			fishSwarm.Add(newFish);

		

			newFish.Update();
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (fishSwarm == null || numberInSwarm < 1) {
			Debug.Log ("swarm is null");
			return;
		}

		for (int i=0; i<numberInSwarm; i++) {

//			Debug.Log("i= " + i);
			((Fish)fishSwarm[i]).Update();

		}

	}

	public static Fish getFish(int i) {
		return (Fish) fishSwarm[i];
	}


}
