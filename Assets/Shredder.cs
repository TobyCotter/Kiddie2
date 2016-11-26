using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {
	//Blah blah blah
	//Practicing github again
	
	void Start () {
	
	}
	

	void Update () {
	
	}

	void OnTriggerEnter (Collider collider){
		Destroy(collider.gameObject);
	}// End OnTriggerEnter ()
}
