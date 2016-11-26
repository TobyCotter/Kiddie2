using UnityEngine;
using System.Collections;

public class MyCamera : MonoBehaviour {
	// Variables
	public Transform lookAt;
	public float lerpSpeed;
	public float xOffset;
	public float yOffset;
	public float zOffset;


	void Start () {
		
	}
	

	void LateUpdate () {
		//Vector3 offset = new Vector3(xOffset, yOffset, zOffset);
		//Vector3 desiredPos = lookAt.transform.position + offset;
		//transform.position = Vector3.Lerp(transform.position, desiredPos, (lerpSpeed * Time.deltaTime));
		Vector3 desiredPos = new Vector3((lookAt.transform.position.x + xOffset), yOffset, zOffset);
		transform.position = desiredPos;
	}// End LateUpdate
}
