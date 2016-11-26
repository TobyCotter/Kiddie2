using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	// Variables
	public Rigidbody bulletPrefab;
	public Transform gun;
	public int bulletSpeed;
	private GameObject bulletParent;
	
	void Start () {
		// Creates Bullets parent object if it doesn't exist
		bulletParent = GameObject.Find("Bullets");
		if(!bulletParent){
			bulletParent = new GameObject("Bullets");
		}
	}
	

	void Update () {
	
	}


	void FixedUpdate (){
		if(Input.GetKeyDown(KeyCode.Space)){
			Rigidbody bulletInstance;
			bulletInstance = Instantiate(bulletPrefab, gun.position, gun.rotation) as Rigidbody;		// gun is a transform
			bulletInstance.velocity = new Vector3(bulletSpeed,0,0);
			bulletInstance.transform.parent = bulletParent.transform;
		}
	}
}
