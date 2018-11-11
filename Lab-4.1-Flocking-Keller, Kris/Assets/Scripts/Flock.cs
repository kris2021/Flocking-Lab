using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flock : MonoBehaviour {

	public float speed = 0.1f;
	// Use this for initialization
	void Start () {
		speed = Random.Range (0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, Time.deltaTime * speed);
	}
}
