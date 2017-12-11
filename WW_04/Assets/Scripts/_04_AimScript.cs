using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_AimScript: MonoBehaviour {
	public GameObject aimTarget;
	Vector3 aimingPoint;

	void Update () {
		AimUpdate ();
	}

	void AimUpdate()
	{
		Ray myRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Physics.Raycast (myRay, out hit)) 
		{
			Vector3 aim = hit.point;
			transform.LookAt(new Vector3 (aim.x, transform.position.y, aim.z));
			aimingPoint = new Vector3 (aim.x, aimTarget.transform.position.y, aim.z); //updates aiming point
			aimTarget.transform.position = aimingPoint; //update aim target position
		}
	}

	public Vector3 GetAimingPoint() //Accessing the aiming point from another script
	{
		return aimingPoint;
	}
}
