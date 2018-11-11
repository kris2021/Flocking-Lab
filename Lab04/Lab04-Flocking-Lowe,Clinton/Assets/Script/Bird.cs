using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour 
{
	public float speed = 0.1f;
	float rotationSpeed = 4.0f;
	Vector3 averageHeading;
	Vector3 averagePosition;
	float neighborDistance = 2.0f;
	// Use this for initialization
	void Start () {
		speed = Random.Range (0.5f, 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0, 0, Time.deltaTime * speed);
	}
}
