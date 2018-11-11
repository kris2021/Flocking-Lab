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
		if (Random.Range (0, 5) < 1)
		{
			ApplyRules ();
		}

		transform.Translate (0, 0, Time.deltaTime * speed);
	}

	void ApplyRules()
	{
		GameObject[] gos;
		gos = Flock.allFish;

		Vector3 vcenter = Vector3.zero;
		Vector3 vavoid = Vector3.zero;
		float gSpeed = 0.1f;

		//Vector3 goalPos = Flock.goalPos;

		float dist;
		int groupSize = 0;
		foreach (GameObject go in gos)
		{
			if (go != this.gameObject)
			{
				dist = Vector3.Distance (go.transform.position, this.transform.position);
				if (dist <= neighborDistance)
				{
					vcenter += go.transform.position;
					groupSize++;

					if (dist < 1.0f)
					{
						vavoid = vavoid + (this.transform.position - go.transform.position);
					}

					Bird anotherBird = go.GetComponent<Bird> ();
					gSpeed = gSpeed + anotherBird.speed;
				}
			}
		}

		if (groupSize > 0)
		{
			vcenter = vcenter / groupSize + (goalPos - this.transform.position);
			speed = gSpeed / groupSize;

			Vector3 direction = (vcenter + vavoid) - transform.position;
			if (direction != Vector3.zero)
			{
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotationSpeed * Time.deltaTime);
			}
		}
	}
}
