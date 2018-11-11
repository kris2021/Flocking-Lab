using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Flock : MonoBehaviour {

	public GameObject BirdObject = null;

	public GameObject Leader = null;

	public int Size = 10;

	/// <summary>
	/// The cohesion identifies the maximum distance between neighboring flock members to maintain.
	/// </summary>
	public int Cohesion = 15;

	/// <summary>
	/// The alignment identifies the average heading of the neighboring flock members.
	/// </summary>
	public Quaternion Alignment = new Quaternion(0,0,0,0);

	/// <summary>
	/// The separation identifies the minimum distance between neighboring flock members.
	/// </summary>
	public int Separation = 3;

	// Use this for initialization
	private void Start () 
	{
		KillBirds ();
		CloneBirds (Size);
	}
	
	// Update is called once per frame
	private void Update () 
	{
		
	}

	private void KillBirds()
	{
		
	}

	private void CloneBirds(int Count)
	{
		for( int N=0; N < Size; N++ ) 
		{
			Vector2 v = getHexPosition (N);
			GameObject go = GameObject.Instantiate (BirdObject, this.transform);
			go.transform.position = new Vector3 (v.x,v.y,0);
			if (N == Size)
				Leader = go;
		}
	}

	private Vector2 getHexPosition(int i)
	{
		Vector2 v = Vector2.zero;

		if ( i == 0 ) { return v; }

		int layer = (int) Mathf.Round( Mathf.Sqrt( (float)(i/3.0) ) );

		int firstIdxInLayer = 3*layer*(layer-1) + 1;
		int side = (i - firstIdxInLayer) / layer; // note: this is integer division
		int idx  = (i - firstIdxInLayer) % layer;                  
		v.x =  layer * Mathf.Cos( (side - 1) * Mathf.PI/3 ) + (idx + 1) * Mathf.Cos( (side + 1) * Mathf.PI/3 );
		v.y = -layer * Mathf.Sin( (side - 1) * Mathf.PI/3 ) - (idx + 1) * Mathf.Sin( (side + 1) * Mathf.PI/3 );

		int d = Cohesion - Separation;
		v.x = Mathf.Sqrt (d) * v.x;
		v.y = Mathf.Sqrt (d) * v.y;

		return v;

	}

}
