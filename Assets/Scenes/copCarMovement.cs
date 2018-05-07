using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copCarMovement : MonoBehaviour {

	public Transform playerPosition;
	public Transform raycastCenter;
	public Transform raycastUp;

	public float speedForce;
	public Rigidbody rb;


	public float moveSpeed;
	public float rotateSpeed;

	float headingAngle = 0f;

	public bool canSeePlayer;
	public bool canGoForward;

	public AudioSource hitSoundSource;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Raycasting ();
		if (canSeePlayer) {
			rotateToPlayer ();
		} else if (!canGoForward) {
				transform.Rotate (0, 0, 5);
		}
		moveForward ();
	}


	void moveForward(){
		rb.AddForce (transform.up * speedForce);
		
	}

	void rotateToPlayer(){

		Vector3 dir = playerPosition.position-transform.position;
		float targetAngle =  Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg+270f;


		if (headingAngle - targetAngle > 180) {
			targetAngle += 360;
		} else if (targetAngle- headingAngle > 180) {
			headingAngle += 360;
		}

		if(headingAngle<targetAngle+3 && headingAngle>targetAngle-3 ){



			
		}else if (headingAngle < targetAngle) {
			headingAngle = headingAngle + rotateSpeed;

		} else {
			headingAngle = headingAngle - rotateSpeed;
		}

		transform.rotation = Quaternion.AngleAxis(headingAngle, Vector3.forward);



	}
	void Raycasting(){
		canSeePlayer = !Physics.Linecast (raycastCenter.position, playerPosition.position, 1 << LayerMask.NameToLayer ("Wall"));
		Debug.DrawLine (raycastCenter.position, playerPosition.position,Color.green);
		canGoForward = !Physics.Linecast (raycastCenter.position, raycastUp.position, 1 << LayerMask.NameToLayer ("Wall"));
	}

	void onCollisionEnter2D(Collider2D other){
		print ("collider test bbb");
		hitSoundSource.Play ();
	}
}
