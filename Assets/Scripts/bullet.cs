using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
	public float speed;
	public float maxDistance;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
		//maxDistance + -1 * Time.deltaTime;

		if (maxDistance >= 5)
			Destroy (this.gameObject);
	}
}
