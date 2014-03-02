using UnityEngine;
using System.Collections;

public class FishSwarm : MonoBehaviour {

	public static int numberInSwarm = 220;
	static ArrayList fishSwarm = new ArrayList(numberInSwarm);
	static ArrayList toBeRemoved = new ArrayList();
	Fish newFish;

	int randomUpdateFish;
	float randomUpdateFishFloat;

	// Use this for initialization
	void Start () {

		for (int i=0; i<numberInSwarm; i++) {
//			Debug.Log("i = " + i);
			newFish = new Fish(i);

			if (newFish == null) {
				Debug.Log("newfish null");
			}
			newFish.myGameObject.transform.position = Random.insideUnitSphere * 20;

			fishSwarm.Add(newFish);

			newFish.Update();
		}

	}
	
	// Update is called once per frame
	void Update () {

		toBeRemoved.Clear();

		if (fishSwarm == null || numberInSwarm < 1) {
			Start ();
			Debug.Log ("swarm is null");
			return;
		}
		for (int i=0; i<numberInSwarm; i++) {

			Fish f = (Fish) fishSwarm[ i ];
			f.Update();

			if (f.myGameObject.transform.position.magnitude > 100) {
				f.myGameObject.transform.position = Vector3.zero;
			}
		}

	}

	public static Fish getFish(int i) {
		return (Fish) fishSwarm[i];
	}


}
