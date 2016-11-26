using UnityEngine;
using System.Collections;

public class Dummy : MonoBehaviour {
	private float xSpeed;
	private float totalTimeSinceCollision;
	private Player player;
	public float playerSpeedOffset;
	public float xGear;

	void Start () {
		player = GameObject.FindObjectOfType<Player> ();
	}


	void Update () {
		if(player.raceHasBegun == true){
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

			MovePlayerForward ();
			//ChangeLanes();			//TODO We would like to lerp when changing lanes, problem is lerping changes our forward translate movement, we need to fix this so we have a smooth lane change but also continue moving forward
		}
	}


	private void MovePlayerForward (){
		xSpeed = (playerSpeedOffset * Time.deltaTime) * xGear;
		transform.Translate(xSpeed,0,0);
	}// End MovePlayerForward


	public void ResetCollisionTimer (){
		totalTimeSinceCollision = 0;
	}// End ResetCollisionTimer
}
