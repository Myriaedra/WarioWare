using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_SatRotation : MonoBehaviour {
	float orbit;
	public float orbitSpeed;
	bool canMove = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (canMove) 
		{
			if (Input.GetMouseButton (0)) {
				orbit += orbitSpeed;
				transform.rotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, orbit);
			} 

			if (Input.GetMouseButton (1)) {
				orbit -= orbitSpeed;
				transform.rotation = Quaternion.Euler (transform.eulerAngles.x, transform.eulerAngles.y, orbit);
			}
		}
	}

	public void StopOrbit()
	{
		canMove = false;
	}
}
