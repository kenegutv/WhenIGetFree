using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

		[SerializeField]
		float moveSpeed = 4f;

		Vector3 forward, right;

		void start()
		{
			forward = Camera.main.transform.forward; 
			forward.y = 0; 
			forward = Vector3.Normalize(forward); 
			right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward; 

		}

		void Update()
		{
			if (Input.anyKey)
				Move();
		if(Input.GetKey (KeyCode.W))
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.A))
		transform.Translate (Vector3.left * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.S))
		transform.Translate (Vector3.back * moveSpeed * Time.deltaTime);
		if (Input.GetKey (KeyCode.D))
		transform.Translate (Vector3.right * moveSpeed * Time.deltaTime);

		}

		void Move()
		{
			Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"); 
			Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

			Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

			transform.forward = heading;
			transform.position += rightMovement;
			transform.position += upMovement;
		}
	}