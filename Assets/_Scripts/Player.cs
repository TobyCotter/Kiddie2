using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	// Variables
	private float totalTimeSinceCollision;
	private float timeSinceStart;
	private float xSpeed;

	[Range(0f,100f)]
	public float playerSpeedOffset;
	public float xGear = 1.1f;						// Which gear the player car is in, 1.1 = 1st, 1.2 = 2nd
	public float lerpCarVal;
	public bool raceHasBegun = false;


	void Start () {
		
	}
	

	void Update () {
		if(raceHasBegun == false){
			WaitToStartRace ();
		}else{
			totalTimeSinceCollision = totalTimeSinceCollision + Time.deltaTime;

			if(totalTimeSinceCollision < 2){
				xGear = 1.0f;
			}else if(totalTimeSinceCollision > 2 && totalTimeSinceCollision < 4){				
				xGear = 1.1f;
			}else if(totalTimeSinceCollision > 4 && totalTimeSinceCollision < 6){
				xGear = 1.2f;
			}else if(totalTimeSinceCollision > 6){	
				xGear = 1.3f;
			}

			ChangeLanes();			//TODO We would like to lerp when changing lanes, problem is lerping changes our forward translate movement, we need to fix this so we have a smooth lane change but also continue moving forward
			MovePlayerForward ();
		}// End else
	}// End Update


	void WaitToStartRace(){
		timeSinceStart = timeSinceStart + Time.deltaTime;

		if(timeSinceStart > 2){
			raceHasBegun = true;
		}
	}// End WaitToStartRace ()


	private void ChangeLanes (){
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 4.0f);
		}

		if(Input.GetKeyDown(KeyCode.RightArrow)){
			transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 4.0f);
		}
	}// End ChangeLanes ()


	private void MovePlayerForward (){
		xSpeed = (playerSpeedOffset * Time.deltaTime) * xGear;
		transform.Translate(xSpeed,0,0);
	}// End MovePlayerForward


	void OnTriggerEnter(Collider collider) {    
		if(collider.GetComponent<Dummy>()){    								//If we collided with Dummy player, reset the dummy collision timer       
        	collider.GetComponent<Dummy>().ResetCollisionTimer();
        }
    }// End OnTriggerEnter
}
