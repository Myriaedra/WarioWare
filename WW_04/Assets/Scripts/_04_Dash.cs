using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _04_Dash : MonoBehaviour {
	public _04_AimScript aimScript;
	public Rigidbody rb;
	public AnimationCurve myCurve;
	bool dashing = false;
	bool gameEnded = false;

	public AudioClip dashSound;
	public AudioSource aS;

	void Update () 
	{
		if (Input.GetMouseButtonDown (0) && !dashing && !gameEnded) //If click and not currently dashing
		{
			StartCoroutine(Dash(aimScript.GetAimingPoint ())); //Start dash
			aS.PlayOneShot(dashSound);
			dashing = true;
		}
	}

	IEnumerator Dash(Vector3 destination)
	{
		//Init vectors for Lerp
		destination = new Vector3 (destination.x, transform.position.y, destination.z);
		Vector3 start = transform.position;

		//Init time counter and increment value depending of distance
		float t = 0f;
		float dist = Vector3.Distance (start, destination);
		float increment = 1/dist;

		//Do the lerp fixedupdate frame per fixedupdate frame
		while (transform.position != destination) 
		{
			t += increment;
			transform.position = Vector3.Lerp(start, destination, myCurve.Evaluate(t));
			yield return new WaitForFixedUpdate();
		}

		dashing = false;
	}

	public void StopControl()
	{
		gameEnded = true;
	}
}
