using UnityEngine;
using System.Collections;

public class FishSwarm : MonoBehaviour {

	public int numberInSwarm = 10;
	ArrayList fishSwarm = new ArrayList(numberInSwarm);
	GameObject fish;

	// Use this for initialization
	void Start () {

		fish = GameObject.FindGameObjectWithTag("Fish");

		for (int i=0; i<numberInSwarm; i++) {
			Debug.Log("i = " + i);
			Rigidbody newFish;
			newFish = Instantiate(fish) as Rigidbody;
			newFish.position = Random.insideUnitSphere * 10;
			fishSwarm.Add(newFish);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
